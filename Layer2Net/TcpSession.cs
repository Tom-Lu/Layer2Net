using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.Transport;
using PcapDotNet.Packets;
using System.Diagnostics;

namespace Layer2Net
{
    public class TcpSession
    {
        private enum TCP_STATE
        {
            CLOSED,
            LISTEN,
            SYN_SENT,
            SYN_RCVD,
            ESTABLISHED,
            FIN_WAIT_1,
            CLOSE_WAIT,
            FIN_WAIT_2,
            LAST_ACK,
            CLOSING,
            TIME_WAIT
        }
        public delegate void TcpDataAvailableHandler(MemoryStream buffer);

        private const ushort CONNECTION_TIMEOUT = 5000;
        private TcpService _service = null;
        private VirtualAdapter _adapter = null;
        private ushort _local_port;
        private IpV4Address _remote_ip;
        private MacAddress _remote_mac;
        private ushort _remote_port;

        private TCP_STATE _current_state = TCP_STATE.CLOSED;
        private uint _current_sequence_number = 0;
        private uint _last_acknowledgment_number = 0;
        private ushort _local_tcp_window_size = 65535;
        private ushort _remote_tcp_window_size = 0;
        private ManualResetEvent _connection_wait_handle = new ManualResetEvent(false);
        private MemoryStream _input_buffer = null;

        public event TcpDataAvailableHandler TcpDataHandler;

        public string Name
        {
            get
            {
                return _remote_ip.ToString() + ":" +LocalPort.ToString() + "->" + _remote_port.ToString();
            }
        }

        public bool IsOpen
        {
            get
            {
                return _current_state == TCP_STATE.ESTABLISHED;
            }
        }

        public ushort LocalPort
        {
            get
            {
                return _local_port;
            }
        }

        public uint HashCode
        {
            get
            {
                return UtilityLib.GetTcpSessionHashCode(_adapter.IP, _local_port, _remote_ip, _remote_port);
            }
        }

        public TcpSession(TcpService Service, VirtualAdapter Adapter, ushort LocalPort, IpV4Address RemoteIP, MacAddress RemoteMac, ushort RemotePort)
        {
            this._service = Service;
            this._adapter = Adapter;
            this._local_port = LocalPort;
            this._remote_ip = RemoteIP;
            this._remote_mac = RemoteMac;
            this._remote_port = RemotePort;
            _current_state = TCP_STATE.CLOSED;
        }

        public void Open()
        {
            VirtualNetwork.Instance.PostTraceMessage("TCP OPEN: " + _remote_ip.ToString() + " " + _local_port.ToString() + "->" + _remote_port.ToString());
            _input_buffer = new MemoryStream(4096);
            _connection_wait_handle.Reset();
            SendTcpCtrlPacket(0, TcpControlBits.Synchronize);    // ACK = false, SYNC = true, FIN = false
            _current_state = TCP_STATE.SYN_SENT;
            _connection_wait_handle.WaitOne(CONNECTION_TIMEOUT, true); // wait for connection process finish
            if (_current_state == TCP_STATE.ESTABLISHED)
            {
                VirtualNetwork.Instance.PostTraceMessage("TCP OPEN: " + _remote_ip.ToString() + " " + _local_port.ToString() + "->" + _remote_port.ToString() + " - SUCCESSFUL");
            }
            else
            {
                VirtualNetwork.Instance.PostTraceMessage("TCP OPEN: " + _remote_ip.ToString() + " " + _local_port.ToString() + "->" + _remote_port.ToString() + " - FAILED");
            }
        }

        public void Close()
        {
            if (IsOpen)
            {
                VirtualNetwork.Instance.PostTraceMessage("TCP CLOSE: " + _remote_ip.ToString() + " " + _local_port.ToString() + "->" + _remote_port.ToString());
                _connection_wait_handle.Reset();
                SendTcpCtrlPacket(_last_acknowledgment_number, TcpControlBits.Fin | TcpControlBits.Acknowledgment);
                _current_state = TCP_STATE.FIN_WAIT_1;
                _connection_wait_handle.WaitOne(CONNECTION_TIMEOUT, true); // wait for connection process finish

                if (_current_state == TCP_STATE.CLOSED)
                {
                    VirtualNetwork.Instance.PostTraceMessage("TCP CLOSE: " + _remote_ip.ToString() + " " + _local_port.ToString() + "->" + _remote_port.ToString() + " - SUCCESSFUL");
                }
                else
                {
                    VirtualNetwork.Instance.PostTraceMessage("TCP CLOSE: " + _remote_ip.ToString() + " " + _local_port.ToString() + "->" + _remote_port.ToString() + " - FAILED");
                }
            }
        }

        public void ProcessTCP(IpV4Datagram packet)
        {
            IpV4Datagram ip = packet;
            TcpDatagram tcp = packet.Tcp;

            if (ip.Source.Equals(_remote_ip) && tcp.SourcePort.Equals(_remote_port) && ip.Destination.Equals(_adapter.IP) && tcp.DestinationPort.Equals(_local_port))
            {
                bool SYN = tcp.IsSynchronize;
                bool ACK = tcp.IsAcknowledgment;
                bool FIN = tcp.IsFin;
                bool PSH = tcp.IsPush;
                bool RST = tcp.IsReset;
                _remote_tcp_window_size = tcp.Window;

                if (_current_state == TCP_STATE.CLOSED)
                {
                    SendTcpCtrlPacket(tcp.SequenceNumber + 1, TcpControlBits.Reset | TcpControlBits.Acknowledgment);
                }
                else if (_current_state == TCP_STATE.SYN_SENT && SYN && ACK)  // 远程主机响应连接请求
                {
                    SendTcpCtrlPacket(tcp.SequenceNumber + 1, TcpControlBits.Acknowledgment);
                    _current_state = TCP_STATE.ESTABLISHED;
                    _connection_wait_handle.Set();
                    _service.TriggerSessionStateChange(this);
                }
                else if (FIN) // 连接被将要断开
                {
                    if (_current_state == TCP_STATE.ESTABLISHED)
                    {
                        _current_state = TCP_STATE.CLOSE_WAIT;
                    }
                    else if (_current_state == TCP_STATE.FIN_WAIT_1)
                    {
                        _current_state = ACK ? TCP_STATE.TIME_WAIT : TCP_STATE.CLOSING;
                    }
                    else if (_current_state == TCP_STATE.FIN_WAIT_2)
                    {
                        _current_state = TCP_STATE.TIME_WAIT;
                    }

                    SendTcpCtrlPacket(tcp.SequenceNumber + 1, TcpControlBits.Acknowledgment);
                }
                else if (_current_state == TCP_STATE.FIN_WAIT_1 && ACK)
                {
                    _current_state = TCP_STATE.FIN_WAIT_2;
                }
                else if (_current_state == TCP_STATE.CLOSING && ACK)
                {
                    _current_state = TCP_STATE.TIME_WAIT;
                }
                else if (_current_state == TCP_STATE.LAST_ACK && ACK)
                {
                    SendTcpCtrlPacket(_last_acknowledgment_number, TcpControlBits.Reset);
                    _current_state = TCP_STATE.CLOSED;
                }
                else if (RST) // 连接被重置
                {
                    _current_state = TCP_STATE.CLOSED;
                    VirtualNetwork.Instance.PostTraceMessage("TCP RST: " + _remote_ip.ToString() + " " + _local_port.ToString() + "->" + _remote_port.ToString());
                }
                else if (PSH)   // 需处理传输数据
                {
                    if (tcp.SequenceNumber == _last_acknowledgment_number)  // 确认收到的包没有乱序
                    {
                        tcp.Payload.ToMemoryStream().WriteTo(_input_buffer);
                        if (TcpDataHandler != null)
                        {
                            TcpDataHandler(tcp.Payload.ToMemoryStream());
                        }

                        SendTcpCtrlPacket(tcp.SequenceNumber + (uint)tcp.PayloadLength, TcpControlBits.Acknowledgment);
                    }
                }
                else if (ACK && _current_state == TCP_STATE.ESTABLISHED)
                {
                    if (tcp.SequenceNumber == _last_acknowledgment_number - 1) // Keep Alive
                    {
                        SendTcpCtrlPacket(_last_acknowledgment_number, TcpControlBits.Acknowledgment);
                    }
                }

                if (_current_state == TCP_STATE.CLOSE_WAIT)
                {
                    SendTcpCtrlPacket(_last_acknowledgment_number, TcpControlBits.Fin | TcpControlBits.Acknowledgment);
                    _current_state = TCP_STATE.LAST_ACK;
                }

                if (_current_state == TCP_STATE.TIME_WAIT)
                {
                    Thread.Sleep(100);
                    SendTcpCtrlPacket(_last_acknowledgment_number, TcpControlBits.Reset);
                    _current_state = TCP_STATE.CLOSED;
                    _connection_wait_handle.Set();
                }

                if (_current_state == TCP_STATE.CLOSED)
                {
                    _service.TriggerSessionStateChange(this);
                }
            }
        }

        void SendTcpCtrlPacket(uint AcknowledgmentNumber, TcpControlBits CtrlBits)
        {
            _last_acknowledgment_number = AcknowledgmentNumber;
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = _adapter.MAC,
                    Destination = _remote_mac,
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            VLanTaggedFrameLayer vlanLayer =
                new VLanTaggedFrameLayer
                {
                    PriorityCodePoint = ClassOfService.Background,
                    CanonicalFormatIndicator = false,
                    VLanIdentifier = _adapter.VLAN,
                    EtherType = EthernetType.None,
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = _adapter.IP,
                    CurrentDestination = _remote_ip,
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = null, // Will be filled automatically.
                    Ttl = 100,
                    TypeOfService = 0,
                };

            TcpLayer tcpLayer =
                new TcpLayer
                {
                    SourcePort = _local_port,
                    DestinationPort = _remote_port,
                    Checksum = null, // Will be filled automatically.
                    SequenceNumber = _current_sequence_number,
                    AcknowledgmentNumber = _last_acknowledgment_number,
                    ControlBits = CtrlBits,
                    Window = _local_tcp_window_size,
                    UrgentPointer = 0,
                    Options = new TcpOptions(
                        new TcpOptionMaximumSegmentSize(1460),
                        new TcpOptionWindowScale(0)
                        )
                };

            if (_adapter.VLAN > 1)
            {
                VirtualNetwork.Instance.SendPacket(PacketBuilder.Build(DateTime.Now, ethernetLayer, vlanLayer, ipV4Layer, tcpLayer));
            }
            else
            {
                VirtualNetwork.Instance.SendPacket(PacketBuilder.Build(DateTime.Now, ethernetLayer, ipV4Layer, tcpLayer));
            }

            if (CtrlBits != TcpControlBits.Acknowledgment)
            {
                _current_sequence_number++;
            }
        }

        public void SendPacket(byte[] data)
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = _adapter.MAC,
                    Destination = _remote_mac,
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            VLanTaggedFrameLayer vlanLayer =
                new VLanTaggedFrameLayer
                {
                    PriorityCodePoint = ClassOfService.Background,
                    CanonicalFormatIndicator = false,
                    VLanIdentifier = _adapter.VLAN,
                    EtherType = EthernetType.None,
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = _adapter.IP,
                    CurrentDestination = _remote_ip,
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = null, // Will be filled automatically.
                    Ttl = 100,
                    TypeOfService = 0,
                };

            TcpLayer tcpLayer =
                new TcpLayer
                {
                    SourcePort = _local_port,
                    DestinationPort = _remote_port,
                    Checksum = null, // Will be filled automatically.
                    SequenceNumber = _current_sequence_number,
                    AcknowledgmentNumber = _last_acknowledgment_number,
                    ControlBits = TcpControlBits.Push | TcpControlBits.Acknowledgment,
                    Window = _local_tcp_window_size,
                    UrgentPointer = 0,
                    Options = new TcpOptions(
                        new TcpOptionMaximumSegmentSize(1460),
                        new TcpOptionWindowScale(0)
                        )
                };

            PayloadLayer payloadLayer = new PayloadLayer();

            if (data.Length > _remote_tcp_window_size)
            {
                uint offset = 0;
                uint data_to_send = (uint)data.Length;
                while (data_to_send > 0)
                {
                    tcpLayer.SequenceNumber = _current_sequence_number;

                    if (data_to_send > _remote_tcp_window_size)
                    {
                        byte[] send_buffer = new byte[_remote_tcp_window_size];
                        Array.Copy(data, offset, send_buffer, 0, _remote_tcp_window_size);
                        payloadLayer.Data = new Datagram(send_buffer);
                        offset += _remote_tcp_window_size;
                        _current_sequence_number += _remote_tcp_window_size;
                    }
                    else
                    {
                        byte[] send_buffer = new byte[data_to_send];
                        Array.Copy(data, offset, send_buffer, 0, data_to_send);
                        payloadLayer.Data = new Datagram(send_buffer);
                        offset += data_to_send;
                        _current_sequence_number += data_to_send;
                    }
                    data_to_send = (uint)data.Length - offset - 1;

                    if (_adapter.VLAN > 1)
                    {
                        VirtualNetwork.Instance.SendPacket(PacketBuilder.Build(DateTime.Now, ethernetLayer, vlanLayer, ipV4Layer, tcpLayer, payloadLayer));
                    }
                    else
                    {
                        VirtualNetwork.Instance.SendPacket(PacketBuilder.Build(DateTime.Now, ethernetLayer, ipV4Layer, tcpLayer, payloadLayer));
                    }
                }
            }
            else
            {
                _current_sequence_number += (uint)data.Length;
                payloadLayer.Data = new Datagram(data);

                if (_adapter.VLAN > 1)
                {
                    VirtualNetwork.Instance.SendPacket(PacketBuilder.Build(DateTime.Now, ethernetLayer, vlanLayer, ipV4Layer, tcpLayer, payloadLayer));
                }
                else
                {
                    VirtualNetwork.Instance.SendPacket(PacketBuilder.Build(DateTime.Now, ethernetLayer, ipV4Layer, tcpLayer, payloadLayer));
                }
            }
        }

    }
}
