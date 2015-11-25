namespace BP_LicenseAudit.View
{
    partial class FormNetwork
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
            this.lblNetworks = new System.Windows.Forms.Label();
            this.lstNetworks = new System.Windows.Forms.ListBox();
            this.tabNetwork = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtNetwokEAByte4 = new System.Windows.Forms.TextBox();
            this.txtNetwokEAByte3 = new System.Windows.Forms.TextBox();
            this.txtNetwokEAByte2 = new System.Windows.Forms.TextBox();
            this.txtNetwokEAByte1 = new System.Windows.Forms.TextBox();
            this.txtNetwokSAByte4 = new System.Windows.Forms.TextBox();
            this.txtNetwokSAByte3 = new System.Windows.Forms.TextBox();
            this.txtNetwokSAByte2 = new System.Windows.Forms.TextBox();
            this.txtNetwokSAByte1 = new System.Windows.Forms.TextBox();
            this.lblNetworkEndadress = new System.Windows.Forms.Label();
            this.lblNetworkStart = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtNetwokCByte4 = new System.Windows.Forms.TextBox();
            this.txtNetwokCByte3 = new System.Windows.Forms.TextBox();
            this.txtNetwokCByte2 = new System.Windows.Forms.TextBox();
            this.txtNetwokCByte1 = new System.Windows.Forms.TextBox();
            this.lblNetworkTabHost = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtNetwokCidrCidr = new System.Windows.Forms.TextBox();
            this.lblNetworkCidr2 = new System.Windows.Forms.Label();
            this.txtNetwokCidrByte4 = new System.Windows.Forms.TextBox();
            this.txtNetwokCidrByte3 = new System.Windows.Forms.TextBox();
            this.txtNetwokCidrByte2 = new System.Windows.Forms.TextBox();
            this.txtNetwokCidrByte1 = new System.Windows.Forms.TextBox();
            this.lblNetworkTabCidr = new System.Windows.Forms.Label();
            this.btnNetworkAdd = new System.Windows.Forms.Button();
            this.tabNetwork.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNetworks
            // 
            this.lblNetworks.AutoSize = true;
            this.lblNetworks.Location = new System.Drawing.Point(13, 47);
            this.lblNetworks.Name = "lblNetworks";
            this.lblNetworks.Size = new System.Drawing.Size(61, 13);
            this.lblNetworks.TabIndex = 2;
            this.lblNetworks.Text = "Netzwerke:";
            // 
            // lstNetworks
            // 
            this.lstNetworks.FormattingEnabled = true;
            this.lstNetworks.Items.AddRange(new object[] {
            "(leer)"});
            this.lstNetworks.Location = new System.Drawing.Point(16, 64);
            this.lstNetworks.Name = "lstNetworks";
            this.lstNetworks.Size = new System.Drawing.Size(120, 173);
            this.lstNetworks.TabIndex = 3;
            this.lstNetworks.DisplayMember = "Name";
            // 
            // tabNetwork
            // 
            this.tabNetwork.Controls.Add(this.tabPage1);
            this.tabNetwork.Controls.Add(this.tabPage2);
            this.tabNetwork.Controls.Add(this.tabPage3);
            this.tabNetwork.Location = new System.Drawing.Point(162, 64);
            this.tabNetwork.Name = "tabNetwork";
            this.tabNetwork.SelectedIndex = 0;
            this.tabNetwork.Size = new System.Drawing.Size(272, 117);
            this.tabNetwork.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtNetwokEAByte4);
            this.tabPage1.Controls.Add(this.txtNetwokEAByte3);
            this.tabPage1.Controls.Add(this.txtNetwokEAByte2);
            this.tabPage1.Controls.Add(this.txtNetwokEAByte1);
            this.tabPage1.Controls.Add(this.txtNetwokSAByte4);
            this.tabPage1.Controls.Add(this.txtNetwokSAByte3);
            this.tabPage1.Controls.Add(this.txtNetwokSAByte2);
            this.tabPage1.Controls.Add(this.txtNetwokSAByte1);
            this.tabPage1.Controls.Add(this.lblNetworkEndadress);
            this.tabPage1.Controls.Add(this.lblNetworkStart);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(264, 91);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Start / End";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtNetwokEAByte4
            // 
            this.txtNetwokEAByte4.Location = new System.Drawing.Point(205, 45);
            this.txtNetwokEAByte4.Name = "txtNetwokEAByte4";
            this.txtNetwokEAByte4.Size = new System.Drawing.Size(38, 20);
            this.txtNetwokEAByte4.TabIndex = 9;
            // 
            // txtNetwokEAByte3
            // 
            this.txtNetwokEAByte3.Location = new System.Drawing.Point(161, 45);
            this.txtNetwokEAByte3.Name = "txtNetwokEAByte3";
            this.txtNetwokEAByte3.Size = new System.Drawing.Size(38, 20);
            this.txtNetwokEAByte3.TabIndex = 8;
            // 
            // txtNetwokEAByte2
            // 
            this.txtNetwokEAByte2.Location = new System.Drawing.Point(117, 45);
            this.txtNetwokEAByte2.Name = "txtNetwokEAByte2";
            this.txtNetwokEAByte2.Size = new System.Drawing.Size(38, 20);
            this.txtNetwokEAByte2.TabIndex = 7;
            // 
            // txtNetwokEAByte1
            // 
            this.txtNetwokEAByte1.Location = new System.Drawing.Point(73, 45);
            this.txtNetwokEAByte1.Name = "txtNetwokEAByte1";
            this.txtNetwokEAByte1.Size = new System.Drawing.Size(38, 20);
            this.txtNetwokEAByte1.TabIndex = 6;
            // 
            // txtNetwokSAByte4
            // 
            this.txtNetwokSAByte4.Location = new System.Drawing.Point(205, 13);
            this.txtNetwokSAByte4.Name = "txtNetwokSAByte4";
            this.txtNetwokSAByte4.Size = new System.Drawing.Size(38, 20);
            this.txtNetwokSAByte4.TabIndex = 5;
            // 
            // txtNetwokSAByte3
            // 
            this.txtNetwokSAByte3.Location = new System.Drawing.Point(161, 13);
            this.txtNetwokSAByte3.Name = "txtNetwokSAByte3";
            this.txtNetwokSAByte3.Size = new System.Drawing.Size(38, 20);
            this.txtNetwokSAByte3.TabIndex = 4;
            // 
            // txtNetwokSAByte2
            // 
            this.txtNetwokSAByte2.Location = new System.Drawing.Point(117, 13);
            this.txtNetwokSAByte2.Name = "txtNetwokSAByte2";
            this.txtNetwokSAByte2.Size = new System.Drawing.Size(38, 20);
            this.txtNetwokSAByte2.TabIndex = 3;
            // 
            // txtNetwokSAByte1
            // 
            this.txtNetwokSAByte1.Location = new System.Drawing.Point(73, 13);
            this.txtNetwokSAByte1.Name = "txtNetwokSAByte1";
            this.txtNetwokSAByte1.Size = new System.Drawing.Size(38, 20);
            this.txtNetwokSAByte1.TabIndex = 2;
            // 
            // lblNetworkEndadress
            // 
            this.lblNetworkEndadress.AutoSize = true;
            this.lblNetworkEndadress.Location = new System.Drawing.Point(7, 48);
            this.lblNetworkEndadress.Name = "lblNetworkEndadress";
            this.lblNetworkEndadress.Size = new System.Drawing.Size(66, 13);
            this.lblNetworkEndadress.TabIndex = 1;
            this.lblNetworkEndadress.Text = "Endadresse:";
            // 
            // lblNetworkStart
            // 
            this.lblNetworkStart.AutoSize = true;
            this.lblNetworkStart.Location = new System.Drawing.Point(7, 16);
            this.lblNetworkStart.Name = "lblNetworkStart";
            this.lblNetworkStart.Size = new System.Drawing.Size(69, 13);
            this.lblNetworkStart.TabIndex = 0;
            this.lblNetworkStart.Text = "Startadresse:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtNetwokCByte4);
            this.tabPage2.Controls.Add(this.txtNetwokCByte3);
            this.tabPage2.Controls.Add(this.txtNetwokCByte2);
            this.tabPage2.Controls.Add(this.txtNetwokCByte1);
            this.tabPage2.Controls.Add(this.lblNetworkTabHost);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(264, 91);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Host";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtNetwokCByte4
            // 
            this.txtNetwokCByte4.Location = new System.Drawing.Point(208, 19);
            this.txtNetwokCByte4.Name = "txtNetwokCByte4";
            this.txtNetwokCByte4.Size = new System.Drawing.Size(38, 20);
            this.txtNetwokCByte4.TabIndex = 9;
            // 
            // txtNetwokCByte3
            // 
            this.txtNetwokCByte3.Location = new System.Drawing.Point(164, 19);
            this.txtNetwokCByte3.Name = "txtNetwokCByte3";
            this.txtNetwokCByte3.Size = new System.Drawing.Size(38, 20);
            this.txtNetwokCByte3.TabIndex = 8;
            // 
            // txtNetwokCByte2
            // 
            this.txtNetwokCByte2.Location = new System.Drawing.Point(120, 19);
            this.txtNetwokCByte2.Name = "txtNetwokCByte2";
            this.txtNetwokCByte2.Size = new System.Drawing.Size(38, 20);
            this.txtNetwokCByte2.TabIndex = 7;
            // 
            // txtNetwokCByte1
            // 
            this.txtNetwokCByte1.Location = new System.Drawing.Point(76, 19);
            this.txtNetwokCByte1.Name = "txtNetwokCByte1";
            this.txtNetwokCByte1.Size = new System.Drawing.Size(38, 20);
            this.txtNetwokCByte1.TabIndex = 6;
            // 
            // lblNetworkTabHost
            // 
            this.lblNetworkTabHost.AutoSize = true;
            this.lblNetworkTabHost.Location = new System.Drawing.Point(7, 22);
            this.lblNetworkTabHost.Name = "lblNetworkTabHost";
            this.lblNetworkTabHost.Size = new System.Drawing.Size(69, 13);
            this.lblNetworkTabHost.TabIndex = 0;
            this.lblNetworkTabHost.Text = "Hostadresse:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtNetwokCidrCidr);
            this.tabPage3.Controls.Add(this.lblNetworkCidr2);
            this.tabPage3.Controls.Add(this.txtNetwokCidrByte4);
            this.tabPage3.Controls.Add(this.txtNetwokCidrByte3);
            this.tabPage3.Controls.Add(this.txtNetwokCidrByte2);
            this.tabPage3.Controls.Add(this.txtNetwokCidrByte1);
            this.tabPage3.Controls.Add(this.lblNetworkTabCidr);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(264, 91);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "CIDR";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtNetwokCidrCidr
            // 
            this.txtNetwokCidrCidr.Location = new System.Drawing.Point(196, 38);
            this.txtNetwokCidrCidr.Name = "txtNetwokCidrCidr";
            this.txtNetwokCidrCidr.Size = new System.Drawing.Size(38, 20);
            this.txtNetwokCidrCidr.TabIndex = 11;
            // 
            // lblNetworkCidr2
            // 
            this.lblNetworkCidr2.AutoSize = true;
            this.lblNetworkCidr2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetworkCidr2.Location = new System.Drawing.Point(180, 35);
            this.lblNetworkCidr2.Name = "lblNetworkCidr2";
            this.lblNetworkCidr2.Size = new System.Drawing.Size(15, 24);
            this.lblNetworkCidr2.TabIndex = 10;
            this.lblNetworkCidr2.Text = "/";
            // 
            // txtNetwokCidrByte4
            // 
            this.txtNetwokCidrByte4.Location = new System.Drawing.Point(141, 38);
            this.txtNetwokCidrByte4.Name = "txtNetwokCidrByte4";
            this.txtNetwokCidrByte4.Size = new System.Drawing.Size(38, 20);
            this.txtNetwokCidrByte4.TabIndex = 9;
            // 
            // txtNetwokCidrByte3
            // 
            this.txtNetwokCidrByte3.Location = new System.Drawing.Point(97, 38);
            this.txtNetwokCidrByte3.Name = "txtNetwokCidrByte3";
            this.txtNetwokCidrByte3.Size = new System.Drawing.Size(38, 20);
            this.txtNetwokCidrByte3.TabIndex = 8;
            // 
            // txtNetwokCidrByte2
            // 
            this.txtNetwokCidrByte2.Location = new System.Drawing.Point(53, 38);
            this.txtNetwokCidrByte2.Name = "txtNetwokCidrByte2";
            this.txtNetwokCidrByte2.Size = new System.Drawing.Size(38, 20);
            this.txtNetwokCidrByte2.TabIndex = 7;
            // 
            // txtNetwokCidrByte1
            // 
            this.txtNetwokCidrByte1.Location = new System.Drawing.Point(9, 38);
            this.txtNetwokCidrByte1.Name = "txtNetwokCidrByte1";
            this.txtNetwokCidrByte1.Size = new System.Drawing.Size(38, 20);
            this.txtNetwokCidrByte1.TabIndex = 6;
            // 
            // lblNetworkTabCidr
            // 
            this.lblNetworkTabCidr.AutoSize = true;
            this.lblNetworkTabCidr.Location = new System.Drawing.Point(6, 22);
            this.lblNetworkTabCidr.Name = "lblNetworkTabCidr";
            this.lblNetworkTabCidr.Size = new System.Drawing.Size(55, 13);
            this.lblNetworkTabCidr.TabIndex = 0;
            this.lblNetworkTabCidr.Text = "Netzwerk:";
            // 
            // btnNetworkAdd
            // 
            this.btnNetworkAdd.Location = new System.Drawing.Point(166, 197);
            this.btnNetworkAdd.Name = "btnNetworkAdd";
            this.btnNetworkAdd.Size = new System.Drawing.Size(121, 40);
            this.btnNetworkAdd.TabIndex = 5;
            this.btnNetworkAdd.Text = "Netzwerk hinzufügen";
            this.btnNetworkAdd.UseVisualStyleBackColor = true;
            this.btnNetworkAdd.Click += new System.EventHandler(this.btnNetworkAdd_Click);
            //
            //inherited Elements
            //
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(13, 13);
            this.lblCustomer.Size = new System.Drawing.Size(41, 13);
            this.lblCustomer.TabIndex = 0;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Location = new System.Drawing.Point(60, 10);
            this.cmbCustomer.Size = new System.Drawing.Size(370, 21);
            this.cmbCustomer.TabIndex = 1;
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(305, 197);
            this.btnEnd.Size = new System.Drawing.Size(129, 40);
            this.btnEnd.TabIndex = 6;
            // 
            // FormNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 253);
            this.Controls.Add(this.btnNetworkAdd);
            this.Controls.Add(this.tabNetwork);
            this.Controls.Add(this.lstNetworks);
            this.Controls.Add(this.lblNetworks);
            this.Name = "FormNetwork";
            this.Text = "Netzwerke hinzufügen";
            this.Controls.SetChildIndex(this.lblNetworks, 0);
            this.Controls.SetChildIndex(this.lstNetworks, 0);
            this.Controls.SetChildIndex(this.tabNetwork, 0);
            this.Controls.SetChildIndex(this.btnNetworkAdd, 0);
            this.tabNetwork.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNetworks;
        private System.Windows.Forms.ListBox lstNetworks;
        private System.Windows.Forms.TabControl tabNetwork;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtNetwokEAByte4;
        private System.Windows.Forms.TextBox txtNetwokEAByte3;
        private System.Windows.Forms.TextBox txtNetwokEAByte2;
        private System.Windows.Forms.TextBox txtNetwokEAByte1;
        private System.Windows.Forms.TextBox txtNetwokSAByte4;
        private System.Windows.Forms.TextBox txtNetwokSAByte3;
        private System.Windows.Forms.TextBox txtNetwokSAByte2;
        private System.Windows.Forms.TextBox txtNetwokSAByte1;
        private System.Windows.Forms.Label lblNetworkEndadress;
        private System.Windows.Forms.Label lblNetworkStart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtNetwokCByte4;
        private System.Windows.Forms.TextBox txtNetwokCByte3;
        private System.Windows.Forms.TextBox txtNetwokCByte2;
        private System.Windows.Forms.TextBox txtNetwokCByte1;
        private System.Windows.Forms.Label lblNetworkTabHost;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtNetwokCidrCidr;
        private System.Windows.Forms.Label lblNetworkCidr2;
        private System.Windows.Forms.TextBox txtNetwokCidrByte4;
        private System.Windows.Forms.TextBox txtNetwokCidrByte3;
        private System.Windows.Forms.TextBox txtNetwokCidrByte2;
        private System.Windows.Forms.TextBox txtNetwokCidrByte1;
        private System.Windows.Forms.Label lblNetworkTabCidr;
        private System.Windows.Forms.Button btnNetworkAdd;
    }
}