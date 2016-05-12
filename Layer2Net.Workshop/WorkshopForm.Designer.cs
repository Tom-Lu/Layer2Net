namespace Layer2Net.Workshop
{
    partial class WorkshopForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adapterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.addAdapterToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.startServiceToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stopServiceToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.VirtualAdapterListView = new System.Windows.Forms.ListView();
            this.AdapterName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.AdapterPropertiesPanel = new Layer2Net.Workshop.AdapterPropertiesPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.PhysicalAdapterPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.LinkStatus = new System.Windows.Forms.Label();
            this.ConnectionName = new System.Windows.Forms.Label();
            this.DeviceId = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PhysicalAdapterList = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TcpSessionPanel = new Layer2Net.Workshop.TcpSessionPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AdapterControlPanel = new Layer2Net.Workshop.AdapterControlPanel();
            this.TraceMessageBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.PhysicalAdapterPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.adapterToolStripMenuItem,
            this.networkToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(843, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openConfigToolStripMenuItem,
            this.saveConfigToolStripMenuItem,
            this.saveAsConfigToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::Layer2Net.Workshop.Properties.Resources.icon_new;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewNetworkProfile);
            // 
            // openConfigToolStripMenuItem
            // 
            this.openConfigToolStripMenuItem.Image = global::Layer2Net.Workshop.Properties.Resources.icon_open;
            this.openConfigToolStripMenuItem.Name = "openConfigToolStripMenuItem";
            this.openConfigToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.openConfigToolStripMenuItem.Text = "Open";
            this.openConfigToolStripMenuItem.Click += new System.EventHandler(this.OpenNetworkProfile);
            // 
            // saveConfigToolStripMenuItem
            // 
            this.saveConfigToolStripMenuItem.Image = global::Layer2Net.Workshop.Properties.Resources.icon_save;
            this.saveConfigToolStripMenuItem.Name = "saveConfigToolStripMenuItem";
            this.saveConfigToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveConfigToolStripMenuItem.Text = "Save";
            this.saveConfigToolStripMenuItem.Click += new System.EventHandler(this.SaveConfiguraiton);
            // 
            // saveAsConfigToolStripMenuItem
            // 
            this.saveAsConfigToolStripMenuItem.Name = "saveAsConfigToolStripMenuItem";
            this.saveAsConfigToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveAsConfigToolStripMenuItem.Text = "Save As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(118, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitApplication);
            // 
            // adapterToolStripMenuItem
            // 
            this.adapterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.adapterToolStripMenuItem.Name = "adapterToolStripMenuItem";
            this.adapterToolStripMenuItem.Size = new System.Drawing.Size(67, 21);
            this.adapterToolStripMenuItem.Text = "Adapter";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::Layer2Net.Workshop.Properties.Resources.icon_add_adapter;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.ToolTipText = "Add Virtual Adapter";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.AddAdapter);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::Layer2Net.Workshop.Properties.Resources.icon_remove_adapter;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.ToolTipText = "Remove Virtual Adatper";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveAdapter);
            // 
            // networkToolStripMenuItem
            // 
            this.networkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startServiceToolStripMenuItem,
            this.stopServiceToolStripMenuItem});
            this.networkToolStripMenuItem.Name = "networkToolStripMenuItem";
            this.networkToolStripMenuItem.Size = new System.Drawing.Size(70, 21);
            this.networkToolStripMenuItem.Text = "Network";
            // 
            // startServiceToolStripMenuItem
            // 
            this.startServiceToolStripMenuItem.Image = global::Layer2Net.Workshop.Properties.Resources.icon_run;
            this.startServiceToolStripMenuItem.Name = "startServiceToolStripMenuItem";
            this.startServiceToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.startServiceToolStripMenuItem.Text = "Start";
            this.startServiceToolStripMenuItem.Click += new System.EventHandler(this.StartService);
            // 
            // stopServiceToolStripMenuItem
            // 
            this.stopServiceToolStripMenuItem.Image = global::Layer2Net.Workshop.Properties.Resources.icon_stop;
            this.stopServiceToolStripMenuItem.Name = "stopServiceToolStripMenuItem";
            this.stopServiceToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.stopServiceToolStripMenuItem.Text = "Stop";
            this.stopServiceToolStripMenuItem.Click += new System.EventHandler(this.StopService);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newtoolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator3,
            this.addAdapterToolStripButton,
            this.toolStripButton4,
            this.toolStripSeparator4,
            this.startServiceToolStripButton,
            this.stopServiceToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(843, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newtoolStripButton
            // 
            this.newtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newtoolStripButton.Image = global::Layer2Net.Workshop.Properties.Resources.icon_new;
            this.newtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newtoolStripButton.Name = "newtoolStripButton";
            this.newtoolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newtoolStripButton.Text = "New Configuration";
            this.newtoolStripButton.Click += new System.EventHandler(this.NewNetworkProfile);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = global::Layer2Net.Workshop.Properties.Resources.icon_open;
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "Open Configuration";
            this.openToolStripButton.Click += new System.EventHandler(this.OpenNetworkProfile);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = global::Layer2Net.Workshop.Properties.Resources.icon_save;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "Save Configuration";
            this.saveToolStripButton.Click += new System.EventHandler(this.SaveConfiguraiton);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // addAdapterToolStripButton
            // 
            this.addAdapterToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addAdapterToolStripButton.Image = global::Layer2Net.Workshop.Properties.Resources.icon_add_adapter;
            this.addAdapterToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addAdapterToolStripButton.Name = "addAdapterToolStripButton";
            this.addAdapterToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addAdapterToolStripButton.Text = "Add Virtual Adapter";
            this.addAdapterToolStripButton.Click += new System.EventHandler(this.AddAdapter);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::Layer2Net.Workshop.Properties.Resources.icon_remove_adapter;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Remove Virtual Adatper";
            this.toolStripButton4.Click += new System.EventHandler(this.RemoveAdapter);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // startServiceToolStripButton
            // 
            this.startServiceToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startServiceToolStripButton.Image = global::Layer2Net.Workshop.Properties.Resources.icon_run;
            this.startServiceToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startServiceToolStripButton.Name = "startServiceToolStripButton";
            this.startServiceToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.startServiceToolStripButton.Text = "Start NetService";
            this.startServiceToolStripButton.Click += new System.EventHandler(this.StartService);
            // 
            // stopServiceToolStripButton
            // 
            this.stopServiceToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopServiceToolStripButton.Image = global::Layer2Net.Workshop.Properties.Resources.icon_stop;
            this.stopServiceToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopServiceToolStripButton.Name = "stopServiceToolStripButton";
            this.stopServiceToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.stopServiceToolStripButton.Text = "Stop NetService";
            this.stopServiceToolStripButton.Click += new System.EventHandler(this.StopService);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.PhysicalAdapterPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel6);
            this.splitContainer1.Size = new System.Drawing.Size(843, 541);
            this.splitContainer1.SplitterDistance = 236;
            this.splitContainer1.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 119);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(236, 3);
            this.panel3.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.VirtualAdapterListView);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(236, 422);
            this.panel2.TabIndex = 1;
            // 
            // VirtualAdapterListView
            // 
            this.VirtualAdapterListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AdapterName});
            this.VirtualAdapterListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VirtualAdapterListView.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VirtualAdapterListView.FullRowSelect = true;
            this.VirtualAdapterListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.VirtualAdapterListView.HideSelection = false;
            this.VirtualAdapterListView.Location = new System.Drawing.Point(0, 19);
            this.VirtualAdapterListView.MultiSelect = false;
            this.VirtualAdapterListView.Name = "VirtualAdapterListView";
            this.VirtualAdapterListView.Size = new System.Drawing.Size(234, 194);
            this.VirtualAdapterListView.TabIndex = 15;
            this.VirtualAdapterListView.UseCompatibleStateImageBehavior = false;
            this.VirtualAdapterListView.View = System.Windows.Forms.View.Details;
            this.VirtualAdapterListView.SelectedIndexChanged += new System.EventHandler(this.VirtualAdapterListView_SelectedIndexChanged);
            this.VirtualAdapterListView.Resize += new System.EventHandler(this.VirtualAdapterListView_Resize);
            // 
            // AdapterName
            // 
            this.AdapterName.Width = 100;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 213);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(234, 3);
            this.panel5.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.AdapterPropertiesPanel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 216);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(234, 204);
            this.panel4.TabIndex = 14;
            // 
            // AdapterPropertiesPanel
            // 
            this.AdapterPropertiesPanel.AdapterName = "";
            this.AdapterPropertiesPanel.ArpService = false;
            this.AdapterPropertiesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AdapterPropertiesPanel.CurrentAdapter = null;
            this.AdapterPropertiesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdapterPropertiesPanel.IcmpService = false;
            this.AdapterPropertiesPanel.IP = "";
            this.AdapterPropertiesPanel.Location = new System.Drawing.Point(0, 0);
            this.AdapterPropertiesPanel.MAC = "";
            this.AdapterPropertiesPanel.Name = "AdapterPropertiesPanel";
            this.AdapterPropertiesPanel.Size = new System.Drawing.Size(232, 202);
            this.AdapterPropertiesPanel.TabIndex = 0;
            this.AdapterPropertiesPanel.TcpService = false;
            this.AdapterPropertiesPanel.VLAN = "";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Virtual Adapters";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PhysicalAdapterPanel
            // 
            this.PhysicalAdapterPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PhysicalAdapterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PhysicalAdapterPanel.Controls.Add(this.label1);
            this.PhysicalAdapterPanel.Controls.Add(this.LinkStatus);
            this.PhysicalAdapterPanel.Controls.Add(this.ConnectionName);
            this.PhysicalAdapterPanel.Controls.Add(this.DeviceId);
            this.PhysicalAdapterPanel.Controls.Add(this.label6);
            this.PhysicalAdapterPanel.Controls.Add(this.label5);
            this.PhysicalAdapterPanel.Controls.Add(this.label4);
            this.PhysicalAdapterPanel.Controls.Add(this.PhysicalAdapterList);
            this.PhysicalAdapterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PhysicalAdapterPanel.Location = new System.Drawing.Point(0, 0);
            this.PhysicalAdapterPanel.Name = "PhysicalAdapterPanel";
            this.PhysicalAdapterPanel.Size = new System.Drawing.Size(236, 119);
            this.PhysicalAdapterPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Physical Adapter";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LinkStatus
            // 
            this.LinkStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkStatus.Location = new System.Drawing.Point(106, 93);
            this.LinkStatus.Name = "LinkStatus";
            this.LinkStatus.Size = new System.Drawing.Size(115, 12);
            this.LinkStatus.TabIndex = 8;
            // 
            // ConnectionName
            // 
            this.ConnectionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionName.AutoEllipsis = true;
            this.ConnectionName.Location = new System.Drawing.Point(106, 73);
            this.ConnectionName.Name = "ConnectionName";
            this.ConnectionName.Size = new System.Drawing.Size(115, 12);
            this.ConnectionName.TabIndex = 9;
            // 
            // DeviceId
            // 
            this.DeviceId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeviceId.AutoEllipsis = true;
            this.DeviceId.Location = new System.Drawing.Point(106, 53);
            this.DeviceId.Name = "DeviceId";
            this.DeviceId.Size = new System.Drawing.Size(115, 12);
            this.DeviceId.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "Link Status:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "Connection Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Device Id:";
            // 
            // PhysicalAdapterList
            // 
            this.PhysicalAdapterList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PhysicalAdapterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PhysicalAdapterList.FormattingEnabled = true;
            this.PhysicalAdapterList.Location = new System.Drawing.Point(3, 22);
            this.PhysicalAdapterList.Name = "PhysicalAdapterList";
            this.PhysicalAdapterList.Size = new System.Drawing.Size(228, 20);
            this.PhysicalAdapterList.TabIndex = 4;
            this.PhysicalAdapterList.SelectedIndexChanged += new System.EventHandler(this.PhysicalAdapterList_SelectedIndexChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.splitContainer2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(603, 541);
            this.panel6.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.TcpSessionPanel);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            this.splitContainer2.Panel1.Controls.Add(this.AdapterControlPanel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.TraceMessageBox);
            this.splitContainer2.Size = new System.Drawing.Size(603, 541);
            this.splitContainer2.SplitterDistance = 390;
            this.splitContainer2.TabIndex = 0;
            // 
            // TcpSessionPanel
            // 
            this.TcpSessionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TcpSessionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TcpSessionPanel.Location = new System.Drawing.Point(329, 0);
            this.TcpSessionPanel.Name = "TcpSessionPanel";
            this.TcpSessionPanel.Size = new System.Drawing.Size(274, 390);
            this.TcpSessionPanel.TabIndex = 2;
            this.TcpSessionPanel.TcpSession = null;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(326, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3, 390);
            this.panel1.TabIndex = 1;
            // 
            // AdapterControlPanel
            // 
            this.AdapterControlPanel.AutoScroll = true;
            this.AdapterControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AdapterControlPanel.CurrentAdapter = null;
            this.AdapterControlPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.AdapterControlPanel.Location = new System.Drawing.Point(0, 0);
            this.AdapterControlPanel.Name = "AdapterControlPanel";
            this.AdapterControlPanel.Size = new System.Drawing.Size(326, 390);
            this.AdapterControlPanel.TabIndex = 0;
            this.AdapterControlPanel.TcpSessionPanel = null;
            // 
            // TraceMessageBox
            // 
            this.TraceMessageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TraceMessageBox.Location = new System.Drawing.Point(0, 0);
            this.TraceMessageBox.Multiline = true;
            this.TraceMessageBox.Name = "TraceMessageBox";
            this.TraceMessageBox.ReadOnly = true;
            this.TraceMessageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TraceMessageBox.Size = new System.Drawing.Size(603, 147);
            this.TraceMessageBox.TabIndex = 0;
            // 
            // Workshop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 591);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Workshop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Layer2Net Workshop";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Workspace_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.PhysicalAdapterPanel.ResumeLayout(false);
            this.PhysicalAdapterPanel.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton addAdapterToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton startServiceToolStripButton;
        private System.Windows.Forms.ToolStripButton stopServiceToolStripButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem adapterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton newtoolStripButton;
        private System.Windows.Forms.Panel PhysicalAdapterPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LinkStatus;
        private System.Windows.Forms.Label ConnectionName;
        private System.Windows.Forms.Label DeviceId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox PhysicalAdapterList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private AdapterPropertiesPanel AdapterPropertiesPanel;
        private System.Windows.Forms.ListView VirtualAdapterListView;
        private System.Windows.Forms.ColumnHeader AdapterName;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private AdapterControlPanel AdapterControlPanel;
        private TcpSessionPanel TcpSessionPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TraceMessageBox;


    }
}