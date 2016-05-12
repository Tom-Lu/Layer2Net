using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Layer2Net.Workshop
{
    public partial class TcpSessionPanel : UserControl
    {
        private TcpSession _CurrentTcpSession = null;

        public TcpSession TcpSession
        {
            get
            {
                return _CurrentTcpSession;
            }
            set
            {
                _CurrentTcpSession = value;
                if (_CurrentTcpSession != null)
                {
                    TcpSessionName.Text = string.Format("TCP Session - {0}", _CurrentTcpSession.Name);
                }
                else
                {
                    TcpSessionName.Text = "TCP Session";
                }
            }
        }

        public TcpSessionPanel()
        {
            InitializeComponent();
        }

        public delegate void DisplayTcpDataDelegate(string data);
        public void DisplayTcpData(string data)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new DisplayTcpDataDelegate(DisplayTcpData), data);
            }
            else
            {
                TcpDataText.AppendText(data);
                TcpDataText.ScrollToCaret();
                TcpDataText.Refresh();
            }
        }

        private void TcpDataText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_CurrentTcpSession != null)
            {
                _CurrentTcpSession.SendPacket(new byte[] { Convert.ToByte(e.KeyChar) });
            }
        }

        private void SendLineBtn_Click(object sender, EventArgs e)
        {
            if (_CurrentTcpSession != null)
            {
                _CurrentTcpSession.SendPacket(Encoding.Default.GetBytes(InputText.Text + Environment.NewLine));
            }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            if (_CurrentTcpSession != null)
            {
                _CurrentTcpSession.SendPacket(Encoding.Default.GetBytes(InputText.Text));
            }
        }
    }
}
