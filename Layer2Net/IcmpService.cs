using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Icmp;

namespace Layer2Net
{
    public class IcmpService
    {
        public enum ICMP_STATE
        {
            IDLE,
            WAIT_ECHO,
        }

        private const int PING_ECHO_TIMEOUT = 3000;
        private VirtualAdapter _adapter;
        private IpV4Address _target_ip;
        private MacAddress _target_mac;
        private ICMP_STATE _current_state = ICMP_STATE.IDLE;
        private int _current_icmp_sequence_num = 0;
        private ManualResetEvent _ping_echo_wait_handle = new ManualResetEvent(false);

        public IcmpService(VirtualAdapter Adapter)
        {
            _adapter = Adapter;
            _current_state = ICMP_STATE.IDLE;
        }

        public bool Ping(string IP, string Mac, int Count = 10)
        {
            return Ping(new IpV4Address(IP), new MacAddress(Mac), Count);
        }

        public bool Ping(IpV4Address IP, MacAddress Mac, int Count=10)
        {
            this._target_ip = IP;
            this._target_mac = Mac;
            bool Result = false;

            for (ushort SequenceNumber = 1; SequenceNumber < Count; SequenceNumber++)
            {
                _ping_echo_wait_handle.Reset();
                _current_icmp_sequence_num = SequenceNumber;
                SendIcmpEcho(_target_ip, _target_mac, SequenceNumber);
                VirtualNetwork.Instance.PostTraceMessage(string.Format("PING {0} ({1})", _target_ip.ToString(), SequenceNumber), false);
                _current_state = ICMP_STATE.WAIT_ECHO;
                if (_ping_echo_wait_handle.WaitOne(PING_ECHO_TIMEOUT))
                {
                    VirtualNetwork.Instance.PostTraceMessage(" - OK");
                    Result = true;
                }
                else
                {
                    VirtualNetwork.Instance.PostTraceMessage(" - TIMEOUT");
                }
                _current_state = ICMP_STATE.IDLE;
                Thread.Sleep(1000);
            }
            return Result;
        }

        public void SendIcmpEcho(IpV4Address TargetIP, MacAddress TargetMac, ushort SequenceNumber)
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = _adapter.MAC,
                    Destination = TargetMac,
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            VLanTaggedFrameLayer vlanLayer =
                new VLanTaggedFrameLayer
                {
                    PriorityCodePoint = ClassOfService.BestEffort,
                    CanonicalFormatIndicator = false,
                    VLanIdentifier = _adapter.VLAN,
                    EtherType = EthernetType.None,
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = _adapter.IP,
                    CurrentDestination = TargetIP,
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = SequenceNumber,
                    Options = IpV4Options.None,
                    Protocol = null, // Will be filled automatically.
                    Ttl = 100,
                    TypeOfService = 0,
                };

            IcmpEchoLayer icmpLayer = new IcmpEchoLayer
            {
                SequenceNumber = SequenceNumber,
                Identifier = SequenceNumber,
            };

            if (_adapter.VLAN > 1)
            {
                 VirtualNetwork.Instance.SendPacket(PacketBuilder.Build(DateTime.Now, ethernetLayer, vlanLayer, ipV4Layer, icmpLayer));
            }
            else
            {
                VirtualNetwork.Instance.SendPacket(PacketBuilder.Build(DateTime.Now, ethernetLayer, ipV4Layer, icmpLayer));
            }
        }

        public void SendIcmpEchoReply(IpV4Address TargetIP, MacAddress TargetMac, IcmpDatagram icmpRequest)
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = _adapter.MAC,
                    Destination = TargetMac,
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            VLanTaggedFrameLayer vlanLayer =
                new VLanTaggedFrameLayer
                {
                    PriorityCodePoint = ClassOfService.BestEffort,
                    CanonicalFormatIndicator = false,
                    VLanIdentifier = _adapter.VLAN,
                    EtherType = EthernetType.None,
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = _adapter.IP,
                    CurrentDestination = TargetIP,
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = null, // Will be filled automatically.
                    Ttl = 100,
                    TypeOfService = 0,
                };

            IcmpEchoReplyLayer icmpReplyLayer = new IcmpEchoReplyLayer
            {
                Identifier = (ushort)((icmpRequest.Variable >> 16) & 0xFFFF),
                SequenceNumber = (ushort)(icmpRequest.Variable & 0xFFFF),
            };

            PayloadLayer payloadLayer = new PayloadLayer()
            {
                Data = icmpRequest.Payload
            };


            if (_adapter.VLAN > 1)
            {
                VirtualNetwork.Instance.SendPacket(PacketBuilder.Build(DateTime.Now, ethernetLayer, vlanLayer, ipV4Layer, icmpReplyLayer, payloadLayer));
            }
            else
            {
                VirtualNetwork.Instance.SendPacket(PacketBuilder.Build(DateTime.Now, ethernetLayer, ipV4Layer, icmpReplyLayer, payloadLayer));
            }

            VirtualNetwork.Instance.PostTraceMessage("ICMP Reply: " + TargetIP.ToString());
        }

        public void ProcessICMP(EthernetDatagram packet)
        {
            IpV4Datagram ip = null;
            if (packet.EtherType == EthernetType.VLanTaggedFrame)
            {
                ip = packet.VLanTaggedFrame.IpV4;
            }
            else
            {
                ip = packet.IpV4;
            }

            IcmpDatagram icmp = ip.Icmp;

            if (icmp.MessageType == IcmpMessageType.Echo && ip.Destination.Equals(_adapter.IP))
            {
                SendIcmpEchoReply(ip.Source, packet.Source, icmp);
            }
            else if (icmp.MessageType == IcmpMessageType.EchoReply)
            {
                if (_current_state == ICMP_STATE.WAIT_ECHO && ip.Source.Equals(_target_ip) && ip.Destination.Equals(_adapter.IP))
                {
                    ushort SequenceNumber = (ushort)(icmp.Variable & 0xFFFF);
                    if (SequenceNumber == _current_icmp_sequence_num)
                    {
                        _ping_echo_wait_handle.Set();
                    }
                }
            }
        }
    }
}
