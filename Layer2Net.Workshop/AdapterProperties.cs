using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Layer2Net;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Ethernet;

namespace Layer2Net.Workshop
{
    public partial class AdapterPropertiesPanel : UserControl
    {
        private VirtualAdapter _CurrentAdapter = null;

        public AdapterPropertiesPanel()
        {
            InitializeComponent();
        }

        public VirtualAdapter CurrentAdapter
        {
            get
            {
                return _CurrentAdapter;
            }
            set
            {
                _CurrentAdapter = value;
                UpdateAdapterProperties();
            }
        }

        public string AdapterName
        {
            get
            {
                return NameEdit.Text;
            }
            set
            {
                NameEdit.Text = value;
            }
        }

        public string IP
        {
            get
            {
                return IpEdit.Text;
            }
            set
            {
                IpEdit.Text = value;
            }
        }

        public string MAC
        {
            get
            {
                return MacEdit.Text;
            }
            set
            {
                MacEdit.Text = value;
            }
        }

        public string VLAN
        {
            get
            {
                return VlanEdit.Text;
            }
            set
            {
                VlanEdit.Text = value;
            }
        }

        public bool ArpService
        {
            get
            {
                return ArpCheckBox.Checked;
            }
            set
            {
                ArpCheckBox.Checked = value;
            }
        }

        public bool IcmpService
        {
            get
            {
                return IcmpCheckBox.Checked;
            }
            set
            {
                IcmpCheckBox.Checked = value;
            }
        }

        public bool TcpService
        {
            get
            {
                return TcpCheckBox.Checked;
            }
            set
            {
                TcpCheckBox.Checked = value;
            }
        }

        private void UpdateAdapterProperties()
        {
            if (!this.DesignMode)
            {
                if (CurrentAdapter != null)
                {
                    Visible = true;
                    AdapterName = CurrentAdapter.Name;
                    IP = CurrentAdapter.IP.ToString();
                    MAC = CurrentAdapter.MAC.ToString();
                    VLAN = CurrentAdapter.VLAN.ToString();
                    ArpService = CurrentAdapter.ArpServiceSupport;
                    IcmpService = CurrentAdapter.IcmpServiceSupport;
                    TcpService = CurrentAdapter.TcpServiceSupport;
                }
                else
                {
                    Visible = false;
                }
            }
        }

        private void NameEdit_TextChanged(object sender, EventArgs e)
        {
            if (CurrentAdapter != null)
            {
                CurrentAdapter.Name = NameEdit.Text;
                WorkshopForm.ProfileModifyFlag = true;
            }
        }

        private void MacEdit_TextChanged(object sender, EventArgs e)
        {
            if (CurrentAdapter != null)
            {
                CurrentAdapter.MAC = new MacAddress(MacEdit.Text);
                WorkshopForm.ProfileModifyFlag = true;
            }
        }

        private void IpEdit_TextChanged(object sender, EventArgs e)
        {
            if (CurrentAdapter != null)
            {
                CurrentAdapter.IP = new IpV4Address(IpEdit.Text);
                WorkshopForm.ProfileModifyFlag = true;
            }
        }

        private void VlanEdit_TextChanged(object sender, EventArgs e)
        {
            if (CurrentAdapter != null)
            {
                CurrentAdapter.VLAN = ushort.Parse(VlanEdit.Text);
                WorkshopForm.ProfileModifyFlag = true;
            }
        }

        private void ArpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CurrentAdapter != null)
            {
                CurrentAdapter.ArpServiceSupport = ArpCheckBox.Checked;
                WorkshopForm.ProfileModifyFlag = true;
            }
        }

        private void IcmpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CurrentAdapter != null)
            {
                CurrentAdapter.IcmpServiceSupport = IcmpCheckBox.Checked;
                WorkshopForm.ProfileModifyFlag = true;
            }
        }

        private void TcpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CurrentAdapter != null)
            {
                CurrentAdapter.TcpServiceSupport = TcpCheckBox.Checked;
                WorkshopForm.ProfileModifyFlag = true;
            }
        }
    }
}
