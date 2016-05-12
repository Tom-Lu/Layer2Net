namespace Layer2Net.Workshop
{
    partial class TcpSessionPanel
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
            this.TcpSessionName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InputText = new System.Windows.Forms.TextBox();
            this.SendLineBtn = new System.Windows.Forms.Button();
            this.SendBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TcpDataText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TcpSessionName
            // 
            this.TcpSessionName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TcpSessionName.Dock = System.Windows.Forms.DockStyle.Top;
            this.TcpSessionName.Location = new System.Drawing.Point(0, 0);
            this.TcpSessionName.Name = "TcpSessionName";
            this.TcpSessionName.Size = new System.Drawing.Size(335, 19);
            this.TcpSessionName.TabIndex = 15;
            this.TcpSessionName.Text = "TCP Session";
            this.TcpSessionName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.InputText);
            this.panel1.Controls.Add(this.SendLineBtn);
            this.panel1.Controls.Add(this.SendBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 249);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 21);
            this.panel1.TabIndex = 17;
            // 
            // InputText
            // 
            this.InputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputText.Location = new System.Drawing.Point(0, 0);
            this.InputText.Name = "InputText";
            this.InputText.Size = new System.Drawing.Size(185, 21);
            this.InputText.TabIndex = 0;
            // 
            // SendLineBtn
            // 
            this.SendLineBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.SendLineBtn.Location = new System.Drawing.Point(185, 0);
            this.SendLineBtn.Name = "SendLineBtn";
            this.SendLineBtn.Size = new System.Drawing.Size(75, 21);
            this.SendLineBtn.TabIndex = 0;
            this.SendLineBtn.Text = "SendLine";
            this.SendLineBtn.UseVisualStyleBackColor = true;
            this.SendLineBtn.Click += new System.EventHandler(this.SendLineBtn_Click);
            // 
            // SendBtn
            // 
            this.SendBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.SendBtn.Location = new System.Drawing.Point(260, 0);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(75, 21);
            this.SendBtn.TabIndex = 0;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 246);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 3);
            this.panel2.TabIndex = 18;
            // 
            // TcpDataText
            // 
            this.TcpDataText.BackColor = System.Drawing.Color.White;
            this.TcpDataText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TcpDataText.Location = new System.Drawing.Point(0, 19);
            this.TcpDataText.Multiline = true;
            this.TcpDataText.Name = "TcpDataText";
            this.TcpDataText.ReadOnly = true;
            this.TcpDataText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TcpDataText.Size = new System.Drawing.Size(335, 227);
            this.TcpDataText.TabIndex = 19;
            this.TcpDataText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TcpDataText_KeyPress);
            // 
            // TcpSessionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.TcpDataText);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TcpSessionName);
            this.Name = "TcpSessionPanel";
            this.Size = new System.Drawing.Size(335, 270);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TcpSessionName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox InputText;
        private System.Windows.Forms.Button SendLineBtn;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TcpDataText;
    }
}
