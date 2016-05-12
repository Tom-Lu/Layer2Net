namespace Layer2Net.Workshop
{
    partial class AdapterPropertiesPanel
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
            this.label2 = new System.Windows.Forms.Label();
            this.NameEdit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MacEdit = new System.Windows.Forms.TextBox();
            this.IpEdit = new System.Windows.Forms.TextBox();
            this.VlanEdit = new System.Windows.Forms.TextBox();
            this.ArpCheckBox = new System.Windows.Forms.CheckBox();
            this.IcmpCheckBox = new System.Windows.Forms.CheckBox();
            this.TcpCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Virtual Adapter Properties";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Name:";
            // 
            // NameEdit
            // 
            this.NameEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameEdit.Location = new System.Drawing.Point(55, 28);
            this.NameEdit.Name = "NameEdit";
            this.NameEdit.Size = new System.Drawing.Size(188, 21);
            this.NameEdit.TabIndex = 15;
            this.NameEdit.TextChanged += new System.EventHandler(this.NameEdit_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "MAC:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "IP:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "VLAN:";
            // 
            // MacEdit
            // 
            this.MacEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MacEdit.Location = new System.Drawing.Point(55, 57);
            this.MacEdit.Name = "MacEdit";
            this.MacEdit.Size = new System.Drawing.Size(188, 21);
            this.MacEdit.TabIndex = 15;
            this.MacEdit.TextChanged += new System.EventHandler(this.MacEdit_TextChanged);
            // 
            // IpEdit
            // 
            this.IpEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IpEdit.Location = new System.Drawing.Point(55, 86);
            this.IpEdit.Name = "IpEdit";
            this.IpEdit.Size = new System.Drawing.Size(188, 21);
            this.IpEdit.TabIndex = 15;
            this.IpEdit.TextChanged += new System.EventHandler(this.IpEdit_TextChanged);
            // 
            // VlanEdit
            // 
            this.VlanEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VlanEdit.Location = new System.Drawing.Point(55, 115);
            this.VlanEdit.Name = "VlanEdit";
            this.VlanEdit.Size = new System.Drawing.Size(188, 21);
            this.VlanEdit.TabIndex = 15;
            this.VlanEdit.TextChanged += new System.EventHandler(this.VlanEdit_TextChanged);
            // 
            // ArpCheckBox
            // 
            this.ArpCheckBox.AutoSize = true;
            this.ArpCheckBox.Location = new System.Drawing.Point(10, 20);
            this.ArpCheckBox.Name = "ArpCheckBox";
            this.ArpCheckBox.Size = new System.Drawing.Size(42, 16);
            this.ArpCheckBox.TabIndex = 16;
            this.ArpCheckBox.Text = "ARP";
            this.ArpCheckBox.UseVisualStyleBackColor = true;
            this.ArpCheckBox.CheckedChanged += new System.EventHandler(this.ArpCheckBox_CheckedChanged);
            // 
            // IcmpCheckBox
            // 
            this.IcmpCheckBox.AutoSize = true;
            this.IcmpCheckBox.Location = new System.Drawing.Point(62, 20);
            this.IcmpCheckBox.Name = "IcmpCheckBox";
            this.IcmpCheckBox.Size = new System.Drawing.Size(48, 16);
            this.IcmpCheckBox.TabIndex = 16;
            this.IcmpCheckBox.Text = "ICMP";
            this.IcmpCheckBox.UseVisualStyleBackColor = true;
            this.IcmpCheckBox.CheckedChanged += new System.EventHandler(this.IcmpCheckBox_CheckedChanged);
            // 
            // TcpCheckBox
            // 
            this.TcpCheckBox.AutoSize = true;
            this.TcpCheckBox.Location = new System.Drawing.Point(116, 20);
            this.TcpCheckBox.Name = "TcpCheckBox";
            this.TcpCheckBox.Size = new System.Drawing.Size(42, 16);
            this.TcpCheckBox.TabIndex = 16;
            this.TcpCheckBox.Text = "TCP";
            this.TcpCheckBox.UseVisualStyleBackColor = true;
            this.TcpCheckBox.CheckedChanged += new System.EventHandler(this.TcpCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ArpCheckBox);
            this.groupBox1.Controls.Add(this.TcpCheckBox);
            this.groupBox1.Controls.Add(this.IcmpCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(11, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 47);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Services";
            // 
            // AdapterPropertiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.VlanEdit);
            this.Controls.Add(this.IpEdit);
            this.Controls.Add(this.MacEdit);
            this.Controls.Add(this.NameEdit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AdapterPropertiesPanel";
            this.Size = new System.Drawing.Size(254, 201);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MacEdit;
        private System.Windows.Forms.TextBox IpEdit;
        private System.Windows.Forms.TextBox VlanEdit;
        private System.Windows.Forms.CheckBox ArpCheckBox;
        private System.Windows.Forms.CheckBox IcmpCheckBox;
        private System.Windows.Forms.CheckBox TcpCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
