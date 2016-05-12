using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Layer2Net.Workshop
{
    public partial class AdapterControlPanel : UserControl
    {
        private VirtualAdapter _CurrentAdapter = null;
        private TcpSession _CurrentTcpSession = null;
        private TcpSessionPanel _TcpSessionPanel = null;
        public AdapterControlPanel()
        {
            InitializeComponent();
        }

        public TcpSessionPanel TcpSessionPanel
        {
            get
            {
                return _TcpSessionPanel;
            }
            set
            {
                _TcpSessionPanel = value;
            }
        }

        public VirtualAdapter CurrentAdapter
        {
            get
            {
                return _CurrentAdapter;
            }
            set
            {
                if (_CurrentAdapter != null)
                {
                    if (value == null || _CurrentAdapter.HashCode != value.HashCode)
                    {
                        _CurrentAdapter.TcpService.SessionStateHandler -= new TcpService.TcpSessionChangeHandler(TcpService_SessionStateHandler);
                    }
                }

                if (value != null)
                {
                    value.TcpService.SessionStateHandler += new TcpService.TcpSessionChangeHandler(TcpService_SessionStateHandler);
                }

                _CurrentAdapter = value;
                SetupControls();
            }
        }

        void TcpService_SessionStateHandler(TcpSession Session)
        {
            if (Session.IsOpen)
            {
                TcpSessionListAdd(Session);
            }
            else
            {
                TcpSessionListRemove(Session);
            }
        }

        public delegate void TcpSessionListAddDelegate(TcpSession Session);
        public void TcpSessionListAdd(TcpSession Session)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new TcpSessionListAddDelegate(TcpSessionListAdd), Session);
            }
            else
            {
                if (!TcpSessionList.Items.Contains(Session.Name))
                {
                    TcpSessionList.Items.Add(Session.Name);
                    TcpSessionList.SelectedIndex = TcpSessionList.Items.Count - 1;
                }
            }
        }

        public delegate void TcpSessionListRemoteDelegate(TcpSession Session);
        public void TcpSessionListRemove(TcpSession Session)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new TcpSessionListRemoteDelegate(TcpSessionListRemove), Session);
            }
            else
            {
                if (TcpSessionList.Items.Contains(Session.Name))
                {
                    TcpSessionList.Items.Remove(Session.Name);
                }
            }
        }

        private void SetupControls()
        {
            if (!this.DesignMode)
            {
                TcpSessionList.Items.Clear();
                if (CurrentAdapter != null)
                {
                    this.Enabled = true;
                    ArpPanel.Enabled = (CurrentAdapter.ArpService  != null);
                    IcmpPanel.Enabled = (CurrentAdapter.IcmpService != null);
                    TcpPanel.Enabled = (CurrentAdapter.TcpService != null);

                    RemoteIP.Text = _CurrentAdapter.IP.ToString();

                    if (_CurrentAdapter.TcpService != null)
                    {
                        foreach (TcpSession session in _CurrentAdapter.TcpService.GetSessions())
                        {
                            TcpSessionList.Items.Add(session.Name);
                        }
                    }
                }
                else
                {
                    this.Enabled = false;
                }
            }
        }

        private void SendArpGratuitus(object sender, EventArgs e)
        {
            CurrentAdapter.ArpService.SendGratuitus();
        }

        private void SendArpRequest(object sender, EventArgs e)
        {
            string TargetMac = string.Empty;
            if (CurrentAdapter.ArpService.Resolve(RemoteIP.Text, out TargetMac))
            {
                RemoteMac.Text = TargetMac;
            }
        }

        private void Ping(object sender, EventArgs e)
        {
            if (PingResolveMacCheck.Checked)
            {
                string TargetMac = string.Empty;
                if (CurrentAdapter.ArpService.Resolve(RemoteIP.Text, out TargetMac))
                {
                    RemoteMac.Text = TargetMac;
                }
                else
                {
                    MessageBox.Show(string.Format("Cannot solve target mac address: {0}", RemoteIP.Text), "ARP Probe", MessageBoxButtons.OK);
                    return;
                }
            }
            new Thread(new ThreadStart(delegate()
            {
                CurrentAdapter.IcmpService.Ping(RemoteIP.Text, RemoteMac.Text, 10);
            })).Start();
        }

        private void TcpOpen(object sender, EventArgs e)
        {
            TcpSession NewTcpSession = CurrentAdapter.TcpService.NewSession(RemoteIP.Text, RemoteMac.Text, ushort.Parse(RemotePort.Text));
            NewTcpSession.Open();
            if (!NewTcpSession.IsOpen)
            {
                CurrentAdapter.TcpService.RemoveSession(NewTcpSession);
            }
        }

        private void TcpClose(object sender, EventArgs e)
        {
            if (_CurrentTcpSession != null && _CurrentTcpSession.IsOpen)
            {
                _CurrentTcpSession.TcpDataHandler -= new TcpSession.TcpDataAvailableHandler(_CurrentTcpSession_TcpDataHandler);
                _CurrentTcpSession.Close();
                _CurrentTcpSession = null;
            }
        }

        void _CurrentTcpSession_TcpDataHandler(System.IO.MemoryStream buffer)
        {
            if (_TcpSessionPanel != null)
            {
                byte[] data = new byte[buffer.Length];
                buffer.Read(data, 0, data.Length);
                _TcpSessionPanel.DisplayTcpData(Encoding.ASCII.GetString(data));
            }
        }

        private void TcpSessionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TcpSessionList.SelectedIndex >= 0)
            {
                if (_CurrentTcpSession != null)
                {
                    _CurrentTcpSession.TcpDataHandler -= new TcpSession.TcpDataAvailableHandler(_CurrentTcpSession_TcpDataHandler);
                }

                _CurrentTcpSession = _CurrentAdapter.TcpService.GetSessions()[TcpSessionList.SelectedIndex];
                _CurrentTcpSession.TcpDataHandler += new TcpSession.TcpDataAvailableHandler(_CurrentTcpSession_TcpDataHandler);
                _TcpSessionPanel.TcpSession = _CurrentTcpSession;
            }
            else
            {
                if (_CurrentTcpSession != null)
                {
                    _CurrentTcpSession.TcpDataHandler -= new TcpSession.TcpDataAvailableHandler(_CurrentTcpSession_TcpDataHandler);
                }
                _TcpSessionPanel.TcpSession = null;
                _CurrentTcpSession = null;
            }
        }
    }
}
