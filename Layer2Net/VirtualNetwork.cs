using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;
using System.Threading;
using System.Xml;
using System.IO;
using PcapDotNet.Base;
using PcapDotNet.Core;
using PcapDotNet.Core.Extensions;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.IpV4;

namespace Layer2Net
{
    public class VirtualNetwork
    {
        public delegate void TraceMessageHandler(string Message);

        private const uint SEND_BUFFER_SIZE = 4096;
        public string Filename { get; set; }
        private static VirtualNetwork _instance = null;
        private NetworkInterface _physical_insterface = null;
        private LivePacketDevice _live_packet_device = null;
        private PacketCommunicator _packet_communicator = null;
        private List<VirtualAdapter> _adapters = null;
        private Hashtable _adapter_hashtable = null;
        private Thread _packet_process_thread = null;
        private PacketSendBuffer _send_buffer = null;
        public event TraceMessageHandler TraceHandler;

        public static VirtualNetwork Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VirtualNetwork();
                }

                return _instance;
            }
        }

        public static VirtualNetwork NewInstance
        {
            get
            {
                _instance = new VirtualNetwork();
                return _instance;
            }
        }

        public string PhysicalAdapter { get; set; }

        public bool IsRunning
        {
            get 
            {
                return _packet_process_thread != null && _packet_process_thread.IsAlive;
            }
        }

        private VirtualNetwork()
        {
            _adapters = new List<VirtualAdapter>();
            _send_buffer = new PacketSendBuffer(SEND_BUFFER_SIZE);
            Filename = string.Empty;
            PhysicalAdapter = string.Empty;
        }

        ~VirtualNetwork()
        {
            if (IsRunning)
            {
                Stop();
            }
            _send_buffer.Dispose();
            _send_buffer = null;
        }

        public VirtualAdapter[] GetAllAdapters()
        {
            return _adapters.ToArray<VirtualAdapter>();
        }

        public void Start()
        {
            if (!string.IsNullOrEmpty(PhysicalAdapter))
            {
                _physical_insterface = GetNetworkInterfaceByAdapterName(PhysicalAdapter);
                if (_physical_insterface != null)
                {
                    _live_packet_device = _physical_insterface.GetLivePacketDevice();
                    if (_instance._live_packet_device != null)
                    {
                        _instance._packet_communicator = _instance._live_packet_device.Open(65536, PacketDeviceOpenAttributes.Promiscuous | PacketDeviceOpenAttributes.MaximumResponsiveness | PacketDeviceOpenAttributes.NoCaptureLocal, 50);
                        if (_instance._packet_communicator != null)
                        {
                            StringBuilder filter = new StringBuilder();
                            filter.Append(@"arp");
                            _adapter_hashtable = new Hashtable();
                            foreach (VirtualAdapter Adapter in _adapters)
                            {
                                _adapter_hashtable.Add(Adapter.HashCode, Adapter);
                                filter.AppendFormat(" or ether dst {0}", Adapter.MAC.ToString());
                            }
                            _packet_communicator.SetFilter(filter.ToString());

                            _instance._packet_process_thread = new Thread(new System.Threading.ParameterizedThreadStart(delegate(object obj)
                            {
                                _instance._packet_communicator.ReceivePackets(0, _instance.PacketProcess);
                            }));
                            _instance._packet_process_thread.Name = "PacketProcessThread";
                            _instance._packet_process_thread.Start();
                        }
                        else
                        {
                            throw new Exception(String.Format("Failed to open live packet device: {0}", _instance._live_packet_device.Name));
                        }
                    }
                    else
                    {
                        throw new Exception(String.Format("Unable open network adapter: {0}", PhysicalAdapter));
                    }
                }
                else
                {
                    throw new Exception(string.Format("Invalid PhysicalAdapter setting: {0}\r\nThis device may not exist in current system!", PhysicalAdapter));
                }
            }
            else
            {
                throw new Exception("PhysicalAdapter cannot be empty!");
            }
        }

        public void Stop()
        {
            if (_packet_process_thread != null && _packet_process_thread.IsAlive)
            {
                _packet_communicator.Break();
                _packet_process_thread.Join();
                _packet_process_thread = null;

                _adapter_hashtable.Clear();
                _adapter_hashtable = null;
            }
        }

        private void PacketProcess(Packet packet)
        {
            // Debug.WriteLine(packet.Ethernet.EtherType.ToString() + " : " + packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff") + " length:" + packet.Length);
            ushort VLAN = 1;

            if (packet.Ethernet.EtherType == EthernetType.VLanTaggedFrame)
            {
                VLAN = packet.Ethernet.VLanTaggedFrame.VLanIdentifier;
            }

            if (packet.Ethernet.Destination.Equals(UtilityLib.BroadcastMac))
            {
                foreach (VirtualAdapter Adapter in _adapter_hashtable.Values)
                {
                    if (Adapter.VLAN.Equals(VLAN))  // 若为广播包，则交给相应VLAN下所有虚拟适配器处理
                    {
                        Adapter.PacketProcess(packet);
                    }
                }
            }
            else
            {
                if (VLAN != 1)
                {
                    if (packet.Ethernet.VLanTaggedFrame.EtherType == EthernetType.Arp)
                    {
                        VirtualAdapter[] Adapters = GetAdapterByMac(packet.Ethernet.Destination);
                        foreach (VirtualAdapter Adapter in Adapters)
                        {
                            if (Adapter.VLAN.Equals(VLAN))
                            {
                                Adapter.PacketProcess(packet);
                            }
                        }
                    }
                    else if (packet.Ethernet.VLanTaggedFrame.EtherType == EthernetType.IpV4) // 处理IPv4包
                    {
                        uint AdapterHashCode = UtilityLib.GetVirtualAdapterHashCode(packet.Ethernet.Destination, packet.Ethernet.VLanTaggedFrame.IpV4.CurrentDestination, VLAN);
                        VirtualAdapter Adapter = (VirtualAdapter)_adapter_hashtable[AdapterHashCode];
                        if (Adapter != null)
                        {
                            Adapter.PacketProcess(packet);
                        }
                    }
                }
                else
                {
                    if (packet.Ethernet.EtherType == EthernetType.Arp)
                    {
                        VirtualAdapter[] Adapters = GetAdapterByMac(packet.Ethernet.Destination);
                        foreach (VirtualAdapter Adapter in Adapters)
                        {
                            if (Adapter.VLAN.Equals(VLAN))
                            {
                                Adapter.PacketProcess(packet);
                            }
                        }
                    }
                    else if (packet.Ethernet.EtherType == EthernetType.IpV4)  // 处理IPv4包
                    {
                        uint AdapterHashCode = UtilityLib.GetVirtualAdapterHashCode(packet.Ethernet.Destination, packet.Ethernet.IpV4.CurrentDestination, VLAN);
                        VirtualAdapter Adapter = (VirtualAdapter)_adapter_hashtable[AdapterHashCode];
                        if (Adapter != null)
                        {
                            Adapter.PacketProcess(packet);
                        }
                    }
                }

            }
        }

        public void SendPacket(Packet packet)
        {
            _packet_communicator.SendPacket(packet);
        }

        public void TransmitPacket(Packet packet)
        {
            _send_buffer.Enqueue(packet);
            _packet_communicator.Transmit(_send_buffer, false);
        }

        public void PostTraceMessage(string Message, bool AppendLineFeed = true)
        {
            if (TraceHandler != null)
            {
                if (AppendLineFeed)
                {
                    TraceHandler(Message + System.Environment.NewLine);
                }
                else
                {
                    TraceHandler(Message);
                }
            }
        }

        public VirtualAdapter NewAdapter()
        {
            VirtualAdapter Adapter = VirtualAdapter.RandomNewAdapter;
            _adapters.Add(Adapter);
            return Adapter;
        }

        public VirtualAdapter NewAdapter(string MAC, string IP, ushort VLAN)
        {
            return NewAdapter(new MacAddress(MAC), new IpV4Address(IP), VLAN);
        }

        public VirtualAdapter NewAdapter(MacAddress MAC, IpV4Address IP, ushort VLAN)
        {
            if (GetAdapter(MAC, IP, VLAN) != null)
            {
                throw new Exception("Cannot add virtual adatper, already exist!");
            }

            VirtualAdapter Adapter = new VirtualAdapter(MAC, IP, VLAN);
            _adapters.Add(Adapter);
            return Adapter;
        }

        public void RemoveInterface(string MAC, string IP, ushort VLAN)
        {
            VirtualAdapter Adapter = GetAdapter(MAC, IP, VLAN);
            if (Adapter != null)
            {
                _adapters.Remove(Adapter);
            }
        }

        public void RemoveInterface(VirtualAdapter Adapter)
        {
            _adapters.Remove(Adapter);
        }

        public void RemoveInterface(int Index)
        {
            _adapters.RemoveAt(Index);
        }

        public VirtualAdapter[] GetAdapterByMac(MacAddress MAC)
        {
            ArrayList AdapterList = new ArrayList();

            foreach (VirtualAdapter Adapter in _adapters)
            {
                if (Adapter.MAC.Equals(MAC))
                {
                    AdapterList.Add(Adapter);
                }
            }

            return AdapterList.ToArray<VirtualAdapter>();
        }

        public VirtualAdapter GetAdapter(string MAC, string IP, ushort VLAN)
        {
            return GetAdapter(new MacAddress(MAC), new IpV4Address(IP), VLAN);
        }

        public VirtualAdapter GetAdapter(MacAddress MAC, IpV4Address IP,  ushort VLAN)
        {
            foreach (VirtualAdapter Adapter in _adapters)
            {
                if (Adapter.MAC.Equals(MAC) && Adapter.IP.Equals(IP) && Adapter.VLAN.Equals(VLAN))
                {
                    return Adapter;
                }
            }
            return null;
        }

        static NetworkInterface GetNetworkInterfaceByLinkName(string LinkName)
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.Name.Equals(LinkName))
                {
                    return nic;
                }
            }
            return null;
        }

        static NetworkInterface GetNetworkInterfaceByAdapterName(string AdapterName)
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.Description.Equals(AdapterName))
                {
                    return nic;
                }
            }
            return null;
        }

        public static VirtualNetwork Load(string Filename)
        {
            if (!File.Exists(Filename))
            {
                throw new FileNotFoundException("File not exist!", Filename);
            }

            VirtualNetwork NetworkInstance = VirtualNetwork.NewInstance;
            NetworkInstance.Filename = Filename;
            XmlDocument ConfigXml = new XmlDocument();
            ConfigXml.Load(Filename);

            XmlNode NetworkNode = ConfigXml.SelectSingleNode("/Network");
            if (NetworkNode != null)
            {
                XmlNode PhysicalAdapterNode = NetworkNode.SelectSingleNode("PhysicalAdapter");
                if (PhysicalAdapterNode != null)
                {
                    NetworkInstance.PhysicalAdapter = PhysicalAdapterNode.InnerText;
                }

                XmlNodeList AdapterNodeList = NetworkNode.SelectNodes("Adapters/VirtualAdapter");
                if (AdapterNodeList != null && AdapterNodeList.Count > 0)
                {
                    foreach (XmlNode AdapterNode in AdapterNodeList)
                    {
                        VirtualAdapter Adapter = VirtualAdapter.Load(AdapterNode);
                        if(Adapter != null)
                        {
                            NetworkInstance._adapters.Add(Adapter);
                        }
                    }
                }
                NetworkNode = null;
            }
            ConfigXml = null;
            return NetworkInstance;
        }

        public void Save()
        {
            XmlDocument ConfigXml = new XmlDocument();

            XmlElement AdaptersElement = ConfigXml.CreateElement("Adapters");
            foreach (VirtualAdapter Adapter in _adapters)
            {
                AdaptersElement.AppendChild(Adapter.Save(ConfigXml));
            }

            XmlElement PhysicalAdapterElement = ConfigXml.CreateElement("PhysicalAdapter");
            PhysicalAdapterElement.InnerText = PhysicalAdapter;

            XmlElement NetworkElement = ConfigXml.CreateElement("Network");
            NetworkElement.AppendChild(PhysicalAdapterElement);
            NetworkElement.AppendChild(AdaptersElement);

            ConfigXml.AppendChild(NetworkElement);
            ConfigXml.Save(Filename);
        }
    }
}
