namespace Layer2Net.Workshop
{
    partial class AdapterControlPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ArpPanel = new System.Windows.Forms.GroupBox();
            this.SendArpRequestBtn = new System.Windows.Forms.Button();
            this.SendArpGratuitusBtn = new System.Windows.Forms.Button();
            this.IcmpPanel = new System.Windows.Forms.GroupBox();
            this.PingResolveMacCheck = new System.Windows.Forms.CheckBox();
            this.PingBtn = new System.Windows.Forms.Button();
            this.TcpPanel = new System.Windows.Forms.GroupBox();
            this.TcpCloseBtn = new System.Windows.Forms.Button();
            this.RemotePort = new System.Windows.Forms.TextBox();
            this.TcpOpenBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.RemoteMac = new System.Windows.Forms.TextBox();
            this.RemoteIP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TcpSessionList = new System.Windows.Forms.ListBox();
            this.ArpPanel.SuspendLayout();
            this.IcmpPanel.SuspendLayout();
            this.TcpPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Virtual Adapter Control";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ArpPanel
            // 
            this.ArpPanel.Controls.Add(this.SendArpRequestBtn);
            this.ArpPanel.Controls.Add(this.SendArpGratuitusBtn);
            this.ArpPanel.Location = new System.Drawing.Point(10, 102);
            this.ArpPanel.Margin = new System.Windows.Forms.Padding(10);
            this.ArpPanel.Name = "ArpPanel";
            this.ArpPanel.Size = new System.Drawing.Size(147, 88);
            this.ArpPanel.TabIndex = 16;
            this.ArpPanel.TabStop = false;
            this.ArpPanel.Text = "ARP";
            // 
            // SendArpRequestBtn
            // 
            this.SendArpRequestBtn.Location = new System.Drawing.Point(13, 50);
            this.SendArpRequestBtn.Name = "SendArpRequestBtn";
            this.SendArpRequestBtn.Size = new System.Drawing.Size(124, 23);
            this.SendArpRequestBtn.TabIndex = 1;
            this.SendArpRequestBtn.Text = "Send ARP Request";
            this.SendArpRequestBtn.UseVisualStyleBackColor = true;
            this.SendArpRequestBtn.Click += new System.EventHandler(this.SendArpRequest);
            // 
            // SendArpGratuitusBtn
            // 
            this.SendArpGratuitusBtn.Location = new System.Drawing.Point(13, 20);
            this.SendArpGratuitusBtn.Name = "SendArpGratuitusBtn";
            this.SendArpGratuitusBtn.Size = new System.Drawing.Size(124, 23);
            this.SendArpGratuitusBtn.TabIndex = 0;
            this.SendArpGratuitusBtn.Text = "Send ARP Gratuitus";
            this.SendArpGratuitusBtn.UseVisualStyleBackColor = true;
            this.SendArpGratuitusBtn.Click += new System.EventHandler(this.SendArpGratuitus);
            // 
            // IcmpPanel
            // 
            this.IcmpPanel.Controls.Add(this.PingResolveMacCheck);
            this.IcmpPanel.Controls.Add(this.PingBtn);
            this.IcmpPanel.Location = new System.Drawing.Point(166, 102);
            this.IcmpPanel.Margin = new System.Windows.Forms.Padding(10);
            this.IcmpPanel.Name = "IcmpPanel";
            this.IcmpPanel.Size = new System.Drawing.Size(148, 88);
            this.IcmpPanel.TabIndex = 17;
            this.IcmpPanel.TabStop = false;
            this.IcmpPanel.Text = "ICMP";
            // 
            // PingResolveMacCheck
            // 
            this.PingResolveMacCheck.AutoSize = true;
            this.PingResolveMacCheck.Checked = true;
            this.PingResolveMacCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PingResolveMacCheck.Location = new System.Drawing.Point(14, 56);
            this.PingResolveMacCheck.Name = "PingResolveMacCheck";
            this.PingResolveMacCheck.Size = new System.Drawing.Size(120, 16);
            this.PingResolveMacCheck.TabIndex = 4;
            this.PingResolveMacCheck.Text = "Auto Resolve MAC";
            this.PingResolveMacCheck.UseVisualStyleBackColor = true;
            // 
            // PingBtn
            // 
            this.PingBtn.Location = new System.Drawing.Point(13, 20);
            this.PingBtn.Name = "PingBtn";
            this.PingBtn.Size = new System.Drawing.Size(121, 23);
            this.PingBtn.TabIndex = 0;
            this.PingBtn.Text = "Ping";
            this.PingBtn.UseVisualStyleBackColor = true;
            this.PingBtn.Click += new System.EventHandler(this.Ping);
            // 
            // TcpPanel
            // 
            this.TcpPanel.Controls.Add(this.TcpCloseBtn);
            this.TcpPanel.Controls.Add(this.RemotePort);
            this.TcpPanel.Controls.Add(this.TcpOpenBtn);
            this.TcpPanel.Controls.Add(this.label9);
            this.TcpPanel.Location = new System.Drawing.Point(10, 193);
            this.TcpPanel.Name = "TcpPanel";
            this.TcpPanel.Size = new System.Drawing.Size(304, 66);
            this.TcpPanel.TabIndex = 18;
            this.TcpPanel.TabStop = false;
            this.TcpPanel.Text = "TCP";
            // 
            // TcpCloseBtn
            // 
            this.TcpCloseBtn.Location = new System.Drawing.Point(231, 31);
            this.TcpCloseBtn.Name = "TcpCloseBtn";
            this.TcpCloseBtn.Size = new System.Drawing.Size(64, 23);
            this.TcpCloseBtn.TabIndex = 4;
            this.TcpCloseBtn.Text = "Close";
            this.TcpCloseBtn.UseVisualStyleBackColor = true;
            this.TcpCloseBtn.Click += new System.EventHandler(this.TcpClose);
            // 
            // RemotePort
            // 
            this.RemotePort.Location = new System.Drawing.Point(14, 33);
            this.RemotePort.Name = "RemotePort";
            this.RemotePort.Size = new System.Drawing.Size(123, 21);
            this.RemotePort.TabIndex = 3;
            this.RemotePort.Text = "23";
            // 
            // TcpOpenBtn
            // 
            this.TcpOpenBtn.Location = new System.Drawing.Point(162, 31);
            this.TcpOpenBtn.Name = "TcpOpenBtn";
            this.TcpOpenBtn.Size = new System.Drawing.Size(64, 23);
            this.TcpOpenBtn.TabIndex = 4;
            this.TcpOpenBtn.Text = "Open";
            this.TcpOpenBtn.UseVisualStyleBackColor = true;
            this.TcpOpenBtn.Click += new System.EventHandler(this.TcpOpen);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "Remote Port";
            // 
            // RemoteMac
            // 
            this.RemoteMac.Location = new System.Drawing.Point(166, 43);
            this.RemoteMac.Name = "RemoteMac";
            this.RemoteMac.Size = new System.Drawing.Size(124, 21);
            this.RemoteMac.TabIndex = 3;
            this.RemoteMac.Text = "00:00:00:00:00:00";
            // 
            // RemoteIP
            // 
            this.RemoteIP.Location = new System.Drawing.Point(13, 43);
            this.RemoteIP.Name = "RemoteIP";
            this.RemoteIP.Size = new System.Drawing.Size(124, 21);
            this.RemoteIP.TabIndex = 3;
            this.RemoteIP.Text = "192.168.100.100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(165, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "Remote MAC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "Remote IP";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RemoteMac);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.RemoteIP);
            this.groupBox1.Location = new System.Drawing.Point(10, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 73);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remote Host";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.TcpSessionList);
            this.groupBox2.Location = new System.Drawing.Point(10, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 122);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TCP Sessions";
            // 
            // TcpSessionList
            // 
            this.TcpSessionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TcpSessionList.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TcpSessionList.FormattingEnabled = true;
            this.TcpSessionList.Location = new System.Drawing.Point(3, 17);
            this.TcpSessionList.Name = "TcpSessionList";
            this.TcpSessionList.Size = new System.Drawing.Size(298, 102);
            this.TcpSessionList.TabIndex = 0;
            this.TcpSessionList.SelectedIndexChanged += new System.EventHandler(this.TcpSessionList_SelectedIndexChanged);
            // 
            // AdapterControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TcpPanel);
            this.Controls.Add(this.IcmpPanel);
            this.Controls.Add(this.ArpPanel);
            this.Controls.Add(this.label1);
            this.Name = "AdapterControlPanel";
            this.Size = new System.Drawing.Size(324, 396);
            this.ArpPanel.ResumeLayout(false);
            this.IcmpPanel.ResumeLayout(false);
            this.IcmpPanel.PerformLayout();
            this.TcpPanel.ResumeLayout(false);
            this.TcpPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox ArpPanel;
        private System.Windows.Forms.Button SendArpGratuitusBtn;
        private System.Windows.Forms.Button SendArpRequestBtn;
        private System.Windows.Forms.GroupBox IcmpPanel;
        private System.Windows.Forms.CheckBox PingResolveMacCheck;
        private System.Windows.Forms.Button PingBtn;
        private System.Windows.Forms.GroupBox TcpPanel;
        private System.Windows.Forms.Button TcpCloseBtn;
        private System.Windows.Forms.Button TcpOpenBtn;
        private System.Windows.Forms.TextBox RemoteMac;
        private System.Windows.Forms.TextBox RemotePort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox RemoteIP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox TcpSessionList;
    }
}
