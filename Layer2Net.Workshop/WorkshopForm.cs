using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Net.NetworkInformation;

namespace Layer2Net.Workshop
{
    public partial class WorkshopForm : Form
    {
        private const string DefaultWorkshopTitle = "Layer2Net Workshop";
        private NetworkInterface[] PhysicalInterfaces = null;
        private VirtualNetwork CurrentNetwork = null;
        private VirtualAdapter CurrentAdapter = null;
        public static bool ProfileModifyFlag = false;

        public WorkshopForm()
        {
            InitializeComponent();
            UpdatePhysicalAdapterList();
            UpdateVirtualAdapterListViewWidth();
            AdapterPropertiesPanel.CurrentAdapter = null;
            AdapterControlPanel.CurrentAdapter = null;
            AdapterControlPanel.TcpSessionPanel = TcpSessionPanel;
            VirtualAdapterListView.SmallImageList = new ImageList();
            VirtualAdapterListView.SmallImageList.Images.Add(Properties.Resources.icon_adapter);
            NewNetworkProfile(null, null);
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Close();
        }

        private void NewNetworkProfile(object sender, EventArgs e)
        {
            if (CurrentNetwork != null && ProfileModifyFlag)
            {
                DialogResult Response = MessageBox.Show("Save current network profile before proceed?", "Save Profile", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (Response == DialogResult.Cancel)
                {
                    return;
                }
                else if (Response == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!SaveCurrentNetworkProfile())
                    {
                        return;
                    }
                }
            }

            this.Text = string.Format("{0} - New Profile", DefaultWorkshopTitle);
            CurrentNetwork = VirtualNetwork.NewInstance;
            UpdateVirtualAdapterList();
            AdapterPropertiesPanel.CurrentAdapter = null;
            ProfileModifyFlag = false;
        }

        private void OpenNetworkProfile(object sender, EventArgs e)
        {
            if (CurrentNetwork != null && ProfileModifyFlag)
            {
                DialogResult Response = MessageBox.Show("Save current network profile before proceed?", "Save Profile", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (Response == DialogResult.Cancel)
                {
                    return;
                }
                else if (Response == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!SaveCurrentNetworkProfile())
                    {
                        return;
                    }
                }
               
            }

            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.CheckFileExists = true;
            openDlg.Filter = "Network Profile(*.network)|*.network|All File(*.*)|*.*";
            if (openDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CurrentNetwork = VirtualNetwork.Load(openDlg.FileName);
                AdapterPropertiesPanel.CurrentAdapter = null;
                this.Text = string.Format("{0} - {1}", DefaultWorkshopTitle, Path.GetFileName(CurrentNetwork.Filename));
            }

            UpdatePhysicalAdapterList();
            UpdateVirtualAdapterList();
            ProfileModifyFlag = false;
        }

        private void SaveConfiguraiton(object sender, EventArgs e)
        {
            SaveCurrentNetworkProfile();
            ProfileModifyFlag = false;
        }

        private bool SaveCurrentNetworkProfile()
        {
            if (CurrentNetwork != null)
            {
                if (string.IsNullOrEmpty(CurrentNetwork.Filename))
                {
                    SaveFileDialog saveDlg = new SaveFileDialog();
                    saveDlg.CheckPathExists = true;
                    saveDlg.Filter = "Network Profile(*.network)|*.network|All File(*.*)|*.*";
                    if (saveDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        CurrentNetwork.Filename = saveDlg.FileName;
                        CurrentNetwork.Save();
                        this.Text = string.Format("{0} - {1}", DefaultWorkshopTitle, Path.GetFileName(CurrentNetwork.Filename));
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    CurrentNetwork.Save();
                }
            }
            return true;
        }

        private void StartService(object sender, EventArgs e)
        {
            TraceMessageBox.Clear();
            CurrentNetwork.Start();
            CurrentNetwork.TraceHandler += new VirtualNetwork.TraceMessageHandler(Service_TraceHandler);
            UpdateAdapterPanels();
        }

        private void StopService(object sender, EventArgs e)
        {
            if (CurrentNetwork != null)
            {
                CurrentNetwork.TraceHandler -= new VirtualNetwork.TraceMessageHandler(Service_TraceHandler);
                CurrentNetwork.Stop();
                UpdateAdapterPanels();
            }
        }

        delegate void Service_TraceHandlerDelegate(string Message);
        void Service_TraceHandler(string Message)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Service_TraceHandlerDelegate(Service_TraceHandler), Message);
            }
            else
            {
                TraceMessageBox.AppendText(Message);
                TraceMessageBox.ScrollToCaret();
                TraceMessageBox.Refresh();
            }
        }

        private void UpdatePhysicalAdapterList()
        {
            PhysicalAdapterList.Items.Clear();
            PhysicalInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            for(int Index =0; Index <PhysicalInterfaces.Length; Index++)
            {
                PhysicalAdapterList.Items.Add(PhysicalInterfaces[Index].Description);
                if (CurrentNetwork != null && PhysicalInterfaces[Index].Description.Equals(CurrentNetwork.PhysicalAdapter))
                {
                    PhysicalAdapterList.SelectedIndex = Index;
                }
            }
        }

        private void PhysicalAdapterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PhysicalAdapterList.SelectedIndex >= 0)
            {
                NetworkInterface SelectedInterface = PhysicalInterfaces[PhysicalAdapterList.SelectedIndex];
                DeviceId.Text = SelectedInterface.Id;
                ConnectionName.Text = SelectedInterface.Name;
                LinkStatus.Text = SelectedInterface.OperationalStatus.ToString();

                if (CurrentNetwork != null)
                {
                    CurrentNetwork.PhysicalAdapter = SelectedInterface.Description;
                }
            }
            ProfileModifyFlag = true;
        }

        private void AddAdapter(object sender, EventArgs e)
        {
            if (CurrentNetwork != null)
            {
                CurrentNetwork.NewAdapter();

                UpdateVirtualAdapterList();
                VirtualAdapterListView.Focus();
                ListViewItem NewAdapterListItem = VirtualAdapterListView.Items[VirtualAdapterListView.Items.Count - 1];
                if (NewAdapterListItem != null)
                {
                    NewAdapterListItem.Focused = true;
                    NewAdapterListItem.Selected = true;
                }

                ProfileModifyFlag = true;
            }
        }

        private void RemoveAdapter(object sender, EventArgs e)
        {
            ProfileModifyFlag = true;
        }

        public void UpdateVirtualAdapterList()
        {
            if (CurrentNetwork != null)
            {
                VirtualAdapterListView.Items.Clear();
                IList VirtualAdapterList = CurrentNetwork.GetAllAdapters();
                foreach (VirtualAdapter Adapter in VirtualAdapterList)
                {
                    ListViewItem item = new ListViewItem(Adapter.Name);
                    item.ImageIndex = 0;
                    VirtualAdapterListView.Items.Add(item);
                }
            }
        }

        private void VirtualAdapterListView_Resize(object sender, EventArgs e)
        {
            UpdateVirtualAdapterListViewWidth();
        }

        private void UpdateVirtualAdapterListViewWidth()
        {
            if (VirtualAdapterListView.Columns.Count > 0)
            {
                VirtualAdapterListView.Columns[0].Width = VirtualAdapterListView.ClientSize.Width;
            }
        }

        private void VirtualAdapterListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VirtualAdapterListView.SelectedItems.Count > 0)
            {
                int SelectedAdapterIndex = VirtualAdapterListView.SelectedItems[0].Index;
                if (SelectedAdapterIndex >= 0)
                {
                    CurrentAdapter = CurrentNetwork.GetAllAdapters()[SelectedAdapterIndex];
                }
                else
                {
                    CurrentAdapter = null;
                }
            }
            else
            {
                CurrentAdapter = null;
            }

            UpdateAdapterPanels();
        }

        private void UpdateAdapterPanels()
        {
            if (CurrentNetwork != null && CurrentNetwork.IsRunning)
            {
                PhysicalAdapterPanel.Enabled = false;
                AdapterPropertiesPanel.Enabled = false;
                AdapterControlPanel.Enabled = true;
            }
            else
            {
                PhysicalAdapterPanel.Enabled = true;
                AdapterPropertiesPanel.Enabled = true;
                AdapterControlPanel.Enabled = false;
            }

            AdapterPropertiesPanel.CurrentAdapter = CurrentAdapter;

            if (CurrentNetwork != null && CurrentNetwork.IsRunning)
            {
                AdapterControlPanel.CurrentAdapter = CurrentAdapter;
            }
            else
            {
                AdapterControlPanel.CurrentAdapter = null;
            }
        }

        private void Workspace_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentNetwork != null && CurrentNetwork.IsRunning)
            {
                CurrentNetwork.Stop();
            }
        }
    }
}
