using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using PcapDotNet.Packets.Ethernet;

namespace Layer2Net
{
    public class TcpService
    {
        Random PortRandom = new Random();
        public delegate void TcpSessionChangeHandler(TcpSession Session);
        private VirtualAdapter _adapter;
        private Hashtable _tcp_sessions = null;
        public event TcpSessionChangeHandler SessionStateHandler;

        public TcpService(VirtualAdapter Adapter)
        {
            this._adapter = Adapter;
            this._tcp_sessions = new Hashtable();
        }

        public TcpSession NewSession(string RemoteIP, string RemoteMac, ushort RemotePort)
        {
            ushort LocalPort = GetAvailableLocalPort();
            uint SessionHashCode = UtilityLib.GetTcpSessionHashCode(_adapter.IP, LocalPort, new IpV4Address(RemoteIP), RemotePort);

            if (_tcp_sessions.ContainsKey(SessionHashCode))
            {
                return (TcpSession)_tcp_sessions[SessionHashCode];
            }
            else
            {
                TcpSession session = new TcpSession(this, _adapter, LocalPort, new IpV4Address(RemoteIP), new MacAddress(RemoteMac), RemotePort);
                if (!_tcp_sessions.ContainsKey(session.HashCode))
                {
                    _tcp_sessions.Add(session.HashCode, session);
                }
                return session;
            }
        }

        internal ushort GetAvailableLocalPort()
        {
            ushort Port = 0;
            while (Port == 0)
            {
                Port = (ushort)PortRandom.Next(1, ushort.MaxValue);
                foreach (TcpSession session in _tcp_sessions.Values)
                {
                    if(Port == session.LocalPort)
                    {
                        Port = 0;
                        break;
                    }
                }
            }
            return Port;
        }

        public void AddSession(TcpSession Session)
        {
            if (!_tcp_sessions.ContainsKey(Session.HashCode))
            {
                _tcp_sessions.Add(Session.HashCode, Session);
            }
        }

        public void RemoveSession(TcpSession Session)
        {
            if (_tcp_sessions.ContainsKey(Session.HashCode))
            {
                _tcp_sessions.Remove(Session.HashCode);
            }
        }

        public void TriggerSessionStateChange(TcpSession Session)
        {
            if (Session.IsOpen)
            {
                AddSession(Session);
            }
            else
            {
                RemoveSession(Session);
            }

            if (SessionStateHandler != null)
            {
                SessionStateHandler(Session);
            }
        }

        public TcpSession[] GetSessions()
        {
            return _tcp_sessions.Values.ToArray<TcpSession>();
        }

        public void ProcessTCP(IpV4Datagram packet)
        {
            IpV4Datagram ip = packet;
            TcpDatagram tcp = packet.Tcp;

            uint TcpSessionHashCode = UtilityLib.GetTcpSessionHashCode(ip.CurrentDestination, tcp.DestinationPort, ip.Source, tcp.SourcePort);
            TcpSession session = (TcpSession)_tcp_sessions[TcpSessionHashCode];
            if (session != null)
            {
                session.ProcessTCP(packet);
            }

        }
    }
}
