using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets;
using System.Xml;

namespace Layer2Net
{
    public class VirtualAdapter
    {
        private static Random random = new Random();

        private ArpService _arp_service = null;
        private IcmpService _icmp_service = null;
        private TcpService _tcp_service = null;

        public string Name { get; set; }

        public MacAddress MAC { get; set; }

        public IpV4Address IP { get; set; }

        public ushort VLAN { get; set; }

        public ArpService ArpService
        {
            get { return _arp_service; }
        }

        public IcmpService IcmpService
        {
            get { return _icmp_service; }
        }

        public TcpService TcpService
        {
            get { return _tcp_service; }
        }

        public bool ArpServiceSupport
        {
            get
            {
                return ArpService != null;
            }
            set
            {
                if (value && ArpService == null)
                {
                    _arp_service = new ArpService(this);
                }
                else if (!value && ArpService != null)
                {
                    _arp_service = null;
                }
            }
        }

        public bool IcmpServiceSupport
        {
            get
            {
                return IcmpService != null;
            }
            set
            {
                if (value && IcmpService == null)
                {
                    _icmp_service = new IcmpService(this);
                }
                else if (!value && IcmpService != null)
                {
                    _icmp_service = null;
                }
            }
        }

        public bool TcpServiceSupport
        {
            get
            {
                return TcpService != null;
            }
            set
            {
                if (value && TcpService == null)
                {
                    _tcp_service = new TcpService(this);
                }
                else if (!value && TcpService != null)
                {
                    _tcp_service = null;
                }
            }
        }

        public VirtualAdapter()
        {
        }

        public static VirtualAdapter RandomNewAdapter
        {
            get
            {
                VirtualAdapter Adapter = new VirtualAdapter();

                Adapter.MAC = new MacAddress(string.Format("00:11:22:33:44:{0:X2}", random.Next(1, 255)));
                Adapter.IP = new IpV4Address(string.Format("192.168.1.{0}", random.Next(1, 255)));
                Adapter.VLAN = 1;
                Adapter.Name = string.Format("Adapter({0}/{1}/{2})", Adapter.MAC, Adapter.VLAN, Adapter.IP);

                Adapter._arp_service = new ArpService(Adapter);
                Adapter._icmp_service = new IcmpService(Adapter);
                Adapter._tcp_service = new TcpService(Adapter);

                return Adapter;
            }
        }

        public VirtualAdapter(MacAddress MAC, IpV4Address IP, ushort VLAN)
            : this(null, MAC, IP, VLAN)
        {
        }

        public VirtualAdapter(string Name, MacAddress MAC, IpV4Address IP, ushort VLAN)
        {
            this.Name = Name ?? string.Format("Adapter({0}/{1}/{2})", MAC.ToString(), VLAN, IP.ToString());
            this.IP = IP;
            this.MAC = MAC;
            this.VLAN = VLAN;

            this._arp_service = new ArpService(this);
            this._icmp_service = new IcmpService(this);
            this._tcp_service = new TcpService(this);
        }

        public uint HashCode
        {
            get
            {
                return UtilityLib.GetVirtualAdapterHashCode(MAC, IP, VLAN);
            }
        }

        public void BoardcastLocalAddress()
        {
            _arp_service.SendGratuitus();
        }

        public bool Ping(string RemoteIP, string RemoteMac, ushort Count = 10)
        {
            return _icmp_service.Ping(new IpV4Address(RemoteIP), new MacAddress(RemoteMac), Count);
        }

        public TcpSession NewTcpSession(string RemoteIP, string RemoteMac, ushort RemotePort)
        {
            _arp_service.SendProbe(new IpV4Address(RemoteIP));
            System.Threading.Thread.Sleep(100);
            return _tcp_service.NewSession(RemoteIP, RemoteMac, RemotePort);
        }

        public void PacketProcess(Packet packet)
        {
            switch (packet.Ethernet.EtherType)
            {
                case EthernetType.VLanTaggedFrame:
                    {
                        switch (packet.Ethernet.VLanTaggedFrame.EtherType)
                        {
                            case EthernetType.Arp:
                                {
                                    _arp_service.ProcessARP(packet.Ethernet.VLanTaggedFrame.Arp);
                                    break;
                                }
                            case EthernetType.IpV4:
                                {

                                    if (packet.Ethernet.VLanTaggedFrame.IpV4.Protocol == IpV4Protocol.InternetControlMessageProtocol)
                                    {
                                        _icmp_service.ProcessICMP(packet.Ethernet);
                                    }
                                    else if (packet.Ethernet.VLanTaggedFrame.IpV4.Protocol == IpV4Protocol.Tcp)
                                    {
                                        _tcp_service.ProcessTCP(packet.Ethernet.VLanTaggedFrame.IpV4);
                                    }
                                    break;
                                }
                            default:
                                break;
                        }
                        break;
                    }
                case EthernetType.Arp:
                    {
                        _arp_service.ProcessARP(packet.Ethernet.Arp);
                        break;
                    }
                case EthernetType.IpV4:
                    {
                        if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.InternetControlMessageProtocol)
                        {
                            _icmp_service.ProcessICMP(packet.Ethernet);
                        }
                        else if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.Tcp)
                        {
                            _tcp_service.ProcessTCP(packet.Ethernet.IpV4);
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        public static VirtualAdapter Load(XmlNode AdapterNode)
        {
            if (AdapterNode == null)
            {
                throw new ArgumentNullException("Adapter XML Node", "Virtual Adapter XML node cannot be empty!");
            }

            VirtualAdapter Adapter = new VirtualAdapter();

            XmlNode NameNode = AdapterNode.SelectSingleNode("Name");
            if (NameNode != null)
            {
                Adapter.Name = NameNode.InnerText;
            }

            XmlNode IpNode = AdapterNode.SelectSingleNode("IP");
            if (IpNode != null)
            {
                Adapter.IP = new IpV4Address(IpNode.InnerText);
            }

            XmlNode MacNode = AdapterNode.SelectSingleNode("MAC");
            if (MacNode != null)
            {
                Adapter.MAC = new MacAddress(MacNode.InnerText);
            }

            XmlNode VlanNode = AdapterNode.SelectSingleNode("VLAN");
            if (VlanNode != null)
            {
                Adapter.VLAN = ushort.Parse(VlanNode.InnerText);
            }

            XmlNode ArpServiceNode = AdapterNode.SelectSingleNode("Services/ARP");
            if (ArpServiceNode != null && bool.Parse(ArpServiceNode.InnerText))
            {
                Adapter._arp_service = new ArpService(Adapter);
            }

            XmlNode IcmpServiceNode = AdapterNode.SelectSingleNode("Services/ICMP");
            if (IcmpServiceNode != null && bool.Parse(IcmpServiceNode.InnerText))
            {
                Adapter._icmp_service = new IcmpService(Adapter);
            }

            XmlNode TcpServiceNode = AdapterNode.SelectSingleNode("Services/TCP");
            if (TcpServiceNode != null && bool.Parse(TcpServiceNode.InnerText))
            {
                Adapter._tcp_service = new TcpService(Adapter);
            }

            return Adapter;
        }

        public XmlElement Save(XmlDocument XmlDoc)
        {
            XmlElement NameElement = XmlDoc.CreateElement("Name");
            NameElement.InnerText = Name;

            XmlElement IpElement = XmlDoc.CreateElement("IP");
            IpElement.InnerText = IP.ToString();

            XmlElement MacElement = XmlDoc.CreateElement("MAC");
            MacElement.InnerText = MAC.ToString();

            XmlElement VlanElement = XmlDoc.CreateElement("VLAN");
            VlanElement.InnerText = VLAN.ToString();

            XmlElement ArpServiceElement = XmlDoc.CreateElement("ARP");
            ArpServiceElement.InnerText =  ArpServiceSupport.ToString();

            XmlElement IcmpServiceElement = XmlDoc.CreateElement("ICMP");
            IcmpServiceElement.InnerText = IcmpServiceSupport.ToString();

            XmlElement TcpServiceElement = XmlDoc.CreateElement("TCP");
            TcpServiceElement.InnerText = TcpServiceSupport.ToString();

            XmlElement ServiceElement = XmlDoc.CreateElement("Services");
            ServiceElement.AppendChild(ArpServiceElement);
            ServiceElement.AppendChild(IcmpServiceElement);
            ServiceElement.AppendChild(TcpServiceElement);

            XmlElement AdapterElement = XmlDoc.CreateElement("VirtualAdapter");
            AdapterElement.AppendChild(NameElement);
            AdapterElement.AppendChild(IpElement);
            AdapterElement.AppendChild(MacElement);
            AdapterElement.AppendChild(VlanElement);
            AdapterElement.AppendChild(ServiceElement);

            return AdapterElement;
        }
    }
}
