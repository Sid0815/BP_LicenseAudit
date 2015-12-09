namespace BP_LicenseAudit.View
{
    partial class FormChange
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
            this.txtCzip = new System.Windows.Forms.TextBox();
            this.txtCStreetNr = new System.Windows.Forms.TextBox();
            this.txtCCity = new System.Windows.Forms.TextBox();
            this.txtCStreet = new System.Windows.Forms.TextBox();
            this.txtCName = new System.Windows.Forms.TextBox();
            this.lblCzip = new System.Windows.Forms.Label();
            this.lblCCity = new System.Windows.Forms.Label();
            this.lblCStreetNr = new System.Windows.Forms.Label();
            this.lblCStreet = new System.Windows.Forms.Label();
            this.lblCName = new System.Windows.Forms.Label();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.lblLicense = new System.Windows.Forms.Label();
            this.lstNetwork = new System.Windows.Forms.ListBox();
            this.lblNetwork = new System.Windows.Forms.Label();
            this.tabNetwork = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtEAByte4 = new System.Windows.Forms.TextBox();
            this.txtEAByte3 = new System.Windows.Forms.TextBox();
            this.txtEAByte2 = new System.Windows.Forms.TextBox();
            this.txtEAByte1 = new System.Windows.Forms.TextBox();
            this.txtSAByte4 = new System.Windows.Forms.TextBox();
            this.txtSAByte3 = new System.Windows.Forms.TextBox();
            this.txtSAByte2 = new System.Windows.Forms.TextBox();
            this.txtSAByte1 = new System.Windows.Forms.TextBox();
            this.lblNetworkEndadress = new System.Windows.Forms.Label();
            this.lblNetworkStart = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtHostByte4 = new System.Windows.Forms.TextBox();
            this.txtHostByte3 = new System.Windows.Forms.TextBox();
            this.txtHostByte2 = new System.Windows.Forms.TextBox();
            this.txtHostByte1 = new System.Windows.Forms.TextBox();
            this.lbllNetworkHost = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtCidrCidr = new System.Windows.Forms.TextBox();
            this.lblNetworkCidr2 = new System.Windows.Forms.Label();
            this.txtCidrByte4 = new System.Windows.Forms.TextBox();
            this.txtCidrByte3 = new System.Windows.Forms.TextBox();
            this.txtCidrByte2 = new System.Windows.Forms.TextBox();
            this.txtCidrByte1 = new System.Windows.Forms.TextBox();
            this.lblNetworkCidr = new System.Windows.Forms.Label();
            this.lblLicense2 = new System.Windows.Forms.Label();
            this.cmbLicense = new System.Windows.Forms.ComboBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.numCount = new System.Windows.Forms.NumericUpDown();
            this.btnLicense = new System.Windows.Forms.Button();
            this.btnNetwork = new System.Windows.Forms.Button();
            this.btnNetworkRemove = new System.Windows.Forms.Button();
            this.tabNetwork.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.dgvLicense = new System.Windows.Forms.DataGridView();
            this.clmLicense = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicense)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCzip
            // 
            this.txtCzip.Location = new System.Drawing.Point(341, 90);
            this.txtCzip.Name = "txtCzip";
            this.txtCzip.Size = new System.Drawing.Size(141, 20);
            this.txtCzip.TabIndex = 21;
            // 
            // txtCStreetNr
            // 
            this.txtCStreetNr.Location = new System.Drawing.Point(341, 61);
            this.txtCStreetNr.Name = "txtCStreetNr";
            this.txtCStreetNr.Size = new System.Drawing.Size(141, 20);
            this.txtCStreetNr.TabIndex = 20;
            // 
            // txtCCity
            // 
            this.txtCCity.Location = new System.Drawing.Point(59, 90);
            this.txtCCity.Name = "txtCCity";
            this.txtCCity.Size = new System.Drawing.Size(220, 20);
            this.txtCCity.TabIndex = 19;
            // 
            // txtCStreet
            // 
            this.txtCStreet.Location = new System.Drawing.Point(59, 61);
            this.txtCStreet.Name = "txtCStreet";
            this.txtCStreet.Size = new System.Drawing.Size(220, 20);
            this.txtCStreet.TabIndex = 18;
            // 
            // txtCName
            // 
            this.txtCName.Location = new System.Drawing.Point(59, 33);
            this.txtCName.Name = "txtCName";
            this.txtCName.Size = new System.Drawing.Size(424, 20);
            this.txtCName.TabIndex = 17;
            // 
            // lblCzip
            // 
            this.lblCzip.AutoSize = true;
            this.lblCzip.Location = new System.Drawing.Point(310, 93);
            this.lblCzip.Name = "lblCzip";
            this.lblCzip.Size = new System.Drawing.Size(30, 13);
            this.lblCzip.TabIndex = 16;
            this.lblCzip.Text = "PLZ:";
            // 
            // lblCCity
            // 
            this.lblCCity.AutoSize = true;
            this.lblCCity.Location = new System.Drawing.Point(12, 93);
            this.lblCCity.Name = "lblCCity";
            this.lblCCity.Size = new System.Drawing.Size(24, 13);
            this.lblCCity.TabIndex = 15;
            this.lblCCity.Text = "Ort:";
            // 
            // lblCStreetNr
            // 
            this.lblCStreetNr.AutoSize = true;
            this.lblCStreetNr.Location = new System.Drawing.Point(310, 64);
            this.lblCStreetNr.Name = "lblCStreetNr";
            this.lblCStreetNr.Size = new System.Drawing.Size(24, 13);
            this.lblCStreetNr.TabIndex = 14;
            this.lblCStreetNr.Text = "Nr.:";
            // 
            // lblCStreet
            // 
            this.lblCStreet.AutoSize = true;
            this.lblCStreet.Location = new System.Drawing.Point(12, 64);
            this.lblCStreet.Name = "lblCStreet";
            this.lblCStreet.Size = new System.Drawing.Size(45, 13);
            this.lblCStreet.TabIndex = 13;
            this.lblCStreet.Text = "Strasse:";
            // 
            // lblCName
            // 
            this.lblCName.AutoSize = true;
            this.lblCName.Location = new System.Drawing.Point(12, 36);
            this.lblCName.Name = "lblCName";
            this.lblCName.Size = new System.Drawing.Size(38, 13);
            this.lblCName.TabIndex = 12;
            this.lblCName.Text = "Name:";
            // 
            // btnCustomer
            // 
            this.btnCustomer.Location = new System.Drawing.Point(570, 51);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(119, 38);
            this.btnCustomer.TabIndex = 22;
            this.btnCustomer.Text = "Stammdaten ändern";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Location = new System.Drawing.Point(12, 124);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(52, 13);
            this.lblLicense.TabIndex = 23;
            this.lblLicense.Text = "Lizenzen:";
            // 
            // lstNetwork
            // 
            this.lstNetwork.FormattingEnabled = true;
            this.lstNetwork.Items.AddRange(new object[] {
            "(leer)"});
            this.lstNetwork.Location = new System.Drawing.Point(15, 333);
            this.lstNetwork.Name = "lstNetwork";
            this.lstNetwork.Size = new System.Drawing.Size(180, 160);
            this.lstNetwork.TabIndex = 26;
            this.lstNetwork.DisplayMember = "Name";
            this.lstNetwork.SelectionMode = System.Windows.Forms.SelectionMode.One;
            this.lstNetwork.SelectedIndexChanged += new System.EventHandler(this.lstNetwork_SelectedIndexChanged);
            // 
            // lblNetwork
            // 
            this.lblNetwork.AutoSize = true;
            this.lblNetwork.Location = new System.Drawing.Point(12, 317);
            this.lblNetwork.Name = "lblNetwork";
            this.lblNetwork.Size = new System.Drawing.Size(61, 13);
            this.lblNetwork.TabIndex = 25;
            this.lblNetwork.Text = "Netzwerke:";
            // 
            // tabNetwork
            // 
            this.tabNetwork.Controls.Add(this.tabPage1);
            this.tabNetwork.Controls.Add(this.tabPage2);
            this.tabNetwork.Controls.Add(this.tabPage3);
            this.tabNetwork.Location = new System.Drawing.Point(214, 333);
            this.tabNetwork.Name = "tabNetwork";
            this.tabNetwork.SelectedIndex = 0;
            this.tabNetwork.Size = new System.Drawing.Size(272, 117);
            this.tabNetwork.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtEAByte4);
            this.tabPage1.Controls.Add(this.txtEAByte3);
            this.tabPage1.Controls.Add(this.txtEAByte2);
            this.tabPage1.Controls.Add(this.txtEAByte1);
            this.tabPage1.Controls.Add(this.txtSAByte4);
            this.tabPage1.Controls.Add(this.txtSAByte3);
            this.tabPage1.Controls.Add(this.txtSAByte2);
            this.tabPage1.Controls.Add(this.txtSAByte1);
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
            // txtEAByte4
            // 
            this.txtEAByte4.Location = new System.Drawing.Point(205, 45);
            this.txtEAByte4.Name = "txtEAByte4";
            this.txtEAByte4.Size = new System.Drawing.Size(38, 20);
            this.txtEAByte4.TabIndex = 9;
            // 
            // txtEAByte3
            // 
            this.txtEAByte3.Location = new System.Drawing.Point(161, 45);
            this.txtEAByte3.Name = "txtEAByte3";
            this.txtEAByte3.Size = new System.Drawing.Size(38, 20);
            this.txtEAByte3.TabIndex = 8;
            // 
            // txtEAByte2
            // 
            this.txtEAByte2.Location = new System.Drawing.Point(117, 45);
            this.txtEAByte2.Name = "txtEAByte2";
            this.txtEAByte2.Size = new System.Drawing.Size(38, 20);
            this.txtEAByte2.TabIndex = 7;
            // 
            // txtEAByte1
            // 
            this.txtEAByte1.Location = new System.Drawing.Point(73, 45);
            this.txtEAByte1.Name = "txtEAByte1";
            this.txtEAByte1.Size = new System.Drawing.Size(38, 20);
            this.txtEAByte1.TabIndex = 6;
            // 
            // txtSAByte4
            // 
            this.txtSAByte4.Location = new System.Drawing.Point(205, 13);
            this.txtSAByte4.Name = "txtSAByte4";
            this.txtSAByte4.Size = new System.Drawing.Size(38, 20);
            this.txtSAByte4.TabIndex = 5;
            // 
            // txtSAByte3
            // 
            this.txtSAByte3.Location = new System.Drawing.Point(161, 13);
            this.txtSAByte3.Name = "txtSAByte3";
            this.txtSAByte3.Size = new System.Drawing.Size(38, 20);
            this.txtSAByte3.TabIndex = 4;
            // 
            // txtSAByte2
            // 
            this.txtSAByte2.Location = new System.Drawing.Point(117, 13);
            this.txtSAByte2.Name = "txtSAByte2";
            this.txtSAByte2.Size = new System.Drawing.Size(38, 20);
            this.txtSAByte2.TabIndex = 3;
            // 
            // txtSAByte1
            // 
            this.txtSAByte1.Location = new System.Drawing.Point(73, 13);
            this.txtSAByte1.Name = "txtSAByte1";
            this.txtSAByte1.Size = new System.Drawing.Size(38, 20);
            this.txtSAByte1.TabIndex = 2;
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
            this.tabPage2.Controls.Add(this.txtHostByte4);
            this.tabPage2.Controls.Add(this.txtHostByte3);
            this.tabPage2.Controls.Add(this.txtHostByte2);
            this.tabPage2.Controls.Add(this.txtHostByte1);
            this.tabPage2.Controls.Add(this.lbllNetworkHost);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(264, 91);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Host";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtHostByte4
            // 
            this.txtHostByte4.Location = new System.Drawing.Point(208, 19);
            this.txtHostByte4.Name = "txtHostByte4";
            this.txtHostByte4.Size = new System.Drawing.Size(38, 20);
            this.txtHostByte4.TabIndex = 9;
            // 
            // txtHostByte3
            // 
            this.txtHostByte3.Location = new System.Drawing.Point(164, 19);
            this.txtHostByte3.Name = "txtHostByte3";
            this.txtHostByte3.Size = new System.Drawing.Size(38, 20);
            this.txtHostByte3.TabIndex = 8;
            // 
            // txtHostByte2
            // 
            this.txtHostByte2.Location = new System.Drawing.Point(120, 19);
            this.txtHostByte2.Name = "txtHostByte2";
            this.txtHostByte2.Size = new System.Drawing.Size(38, 20);
            this.txtHostByte2.TabIndex = 7;
            // 
            // txtHostByte1
            // 
            this.txtHostByte1.Location = new System.Drawing.Point(76, 19);
            this.txtHostByte1.Name = "txtHostByte1";
            this.txtHostByte1.Size = new System.Drawing.Size(38, 20);
            this.txtHostByte1.TabIndex = 6;
            // 
            // lbllNetworkHost
            // 
            this.lbllNetworkHost.AutoSize = true;
            this.lbllNetworkHost.Location = new System.Drawing.Point(7, 22);
            this.lbllNetworkHost.Name = "lbllNetworkHost";
            this.lbllNetworkHost.Size = new System.Drawing.Size(69, 13);
            this.lbllNetworkHost.TabIndex = 0;
            this.lbllNetworkHost.Text = "Hostadresse:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtCidrCidr);
            this.tabPage3.Controls.Add(this.lblNetworkCidr2);
            this.tabPage3.Controls.Add(this.txtCidrByte4);
            this.tabPage3.Controls.Add(this.txtCidrByte3);
            this.tabPage3.Controls.Add(this.txtCidrByte2);
            this.tabPage3.Controls.Add(this.txtCidrByte1);
            this.tabPage3.Controls.Add(this.lblNetworkCidr);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(264, 91);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "CIDR";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtCidrCidr
            // 
            this.txtCidrCidr.Location = new System.Drawing.Point(196, 38);
            this.txtCidrCidr.Name = "txtCidrCidr";
            this.txtCidrCidr.Size = new System.Drawing.Size(38, 20);
            this.txtCidrCidr.TabIndex = 11;
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
            // txtCidrByte4
            // 
            this.txtCidrByte4.Location = new System.Drawing.Point(141, 38);
            this.txtCidrByte4.Name = "txtCidrByte4";
            this.txtCidrByte4.Size = new System.Drawing.Size(38, 20);
            this.txtCidrByte4.TabIndex = 9;
            // 
            // txtCidrByte3
            // 
            this.txtCidrByte3.Location = new System.Drawing.Point(97, 38);
            this.txtCidrByte3.Name = "txtCidrByte3";
            this.txtCidrByte3.Size = new System.Drawing.Size(38, 20);
            this.txtCidrByte3.TabIndex = 8;
            // 
            // txtCidrByte2
            // 
            this.txtCidrByte2.Location = new System.Drawing.Point(53, 38);
            this.txtCidrByte2.Name = "txtCidrByte2";
            this.txtCidrByte2.Size = new System.Drawing.Size(38, 20);
            this.txtCidrByte2.TabIndex = 7;
            // 
            // txtCidrByte1
            // 
            this.txtCidrByte1.Location = new System.Drawing.Point(9, 38);
            this.txtCidrByte1.Name = "txtCidrByte1";
            this.txtCidrByte1.Size = new System.Drawing.Size(38, 20);
            this.txtCidrByte1.TabIndex = 6;
            // 
            // lblNetworkCidr
            // 
            this.lblNetworkCidr.AutoSize = true;
            this.lblNetworkCidr.Location = new System.Drawing.Point(6, 22);
            this.lblNetworkCidr.Name = "lblNetworkCidr";
            this.lblNetworkCidr.Size = new System.Drawing.Size(55, 13);
            this.lblNetworkCidr.TabIndex = 0;
            this.lblNetworkCidr.Text = "Netzwerk:";
            // 
            // btnLicense
            // 
            this.btnLicense.Location = new System.Drawing.Point(570, 265);
            this.btnLicense.Name = "btnLicense";
            this.btnLicense.Size = new System.Drawing.Size(119, 38);
            this.btnLicense.TabIndex = 32;
            this.btnLicense.Text = "Lizenz ändern";
            this.btnLicense.UseVisualStyleBackColor = true;
            this.btnLicense.Click += new System.EventHandler(this.btnLicense_Click);
            // 
            // btnNetwork
            // 
            this.btnNetwork.Location = new System.Drawing.Point(570, 355);
            this.btnNetwork.Name = "btnNetwork";
            this.btnNetwork.Size = new System.Drawing.Size(119, 38);
            this.btnNetwork.TabIndex = 33;
            this.btnNetwork.Text = "Netzwerk ändern";
            this.btnNetwork.UseVisualStyleBackColor = true;
            this.btnNetwork.Click += new System.EventHandler(this.btnNetwork_Click);
            // 
            // btnNetworkRemove
            // 
            this.btnNetworkRemove.Location = new System.Drawing.Point(570, 400);
            this.btnNetworkRemove.Name = "btnNetworkRemov";
            this.btnNetworkRemove.Size = new System.Drawing.Size(119, 38);
            this.btnNetworkRemove.TabIndex = 34;
            this.btnNetworkRemove.Text = "Netzwerk entfernen";
            this.btnNetworkRemove.UseVisualStyleBackColor = true;
            this.btnNetworkRemove.Click += new System.EventHandler(this.btnNetworkRemove_Click);
            // 
            // lblLicense2
            // 
            this.lblLicense2.AutoSize = true;
            this.lblLicense2.Location = new System.Drawing.Point(380, 141);
            this.lblLicense2.Name = "lblLicense2";
            this.lblLicense2.Size = new System.Drawing.Size(40, 13);
            this.lblLicense2.TabIndex = 28;
            this.lblLicense2.Text = "Lizenz:";
            // 
            // cmbLicense
            // 
            this.cmbLicense.FormattingEnabled = true;
            this.cmbLicense.Location = new System.Drawing.Point(380, 161);
            this.cmbLicense.Name = "cmbLicense";
            this.cmbLicense.Size = new System.Drawing.Size(310, 21);
            this.cmbLicense.TabIndex = 29;
            this.cmbLicense.DisplayMember = "Name";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(380, 193);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(42, 13);
            this.lblCount.TabIndex = 30;
            this.lblCount.Text = "Anzahl:";
            // 
            // numCount
            // 
            this.numCount.Location = new System.Drawing.Point(380, 213);
            this.numCount.Name = "numCount";
            this.numCount.Size = new System.Drawing.Size(310, 20);
            this.numCount.TabIndex = 31;
            // 
            // dgvLicense
            // 
            this.dgvLicense.AllowUserToAddRows = false;
            this.dgvLicense.AllowUserToDeleteRows = false;
            this.dgvLicense.AllowUserToResizeColumns = false;
            this.dgvLicense.AllowUserToResizeRows = false;
            this.dgvLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLicense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmLicense,
            this.clmCount});
            this.dgvLicense.Location = new System.Drawing.Point(15, 141);
            this.dgvLicense.Name = "dgvLicense";
            this.dgvLicense.ReadOnly = true;
            this.dgvLicense.RowHeadersVisible = false;
            this.dgvLicense.Size = new System.Drawing.Size(353, 160);
            this.dgvLicense.TabIndex = 24;
            this.dgvLicense.SelectionChanged += new System.EventHandler(this.dgvLicense_SelectionChanged);
            this.dgvLicense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // clmLicense
            // 
            this.clmLicense.HeaderText = "Lizenz";
            this.clmLicense.Name = "clmLicense";
            this.clmLicense.ReadOnly = true;
            this.clmLicense.Width = 300;
            // 
            // clmCount
            // 
            this.clmCount.HeaderText = "Anzahl";
            this.clmCount.Name = "clmCount";
            this.clmCount.ReadOnly = true;
            this.clmCount.Width = 50;
            //
            //inherited Elements
            //
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Location = new System.Drawing.Point(59, 6);
            this.cmbCustomer.Size = new System.Drawing.Size(425, 21);
            this.cmbCustomer.TabIndex = 7;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(12, 9);
            this.lblCustomer.Size = new System.Drawing.Size(41, 13);
            this.lblCustomer.TabIndex = 6;
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(570, 455);
            this.btnEnd.Size = new System.Drawing.Size(119, 38);
            this.btnEnd.TabIndex = 34;
            // 
            // FormChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 505);
            this.Controls.Add(this.btnNetwork);
            this.Controls.Add(this.btnNetworkRemove);
            this.Controls.Add(this.btnLicense);
            this.Controls.Add(this.numCount);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.cmbLicense);
            this.Controls.Add(this.lblLicense2);
            this.Controls.Add(this.tabNetwork);
            this.Controls.Add(this.lstNetwork);
            this.Controls.Add(this.lblNetwork);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.txtCzip);
            this.Controls.Add(this.txtCStreetNr);
            this.Controls.Add(this.txtCCity);
            this.Controls.Add(this.txtCStreet);
            this.Controls.Add(this.txtCName);
            this.Controls.Add(this.lblCzip);
            this.Controls.Add(this.lblCCity);
            this.Controls.Add(this.lblCStreetNr);
            this.Controls.Add(this.lblCStreet);
            this.Controls.Add(this.lblCName);
            this.Controls.Add(this.dgvLicense);
            this.Name = "FormChange";
            this.Text = "Daten ändern";
            this.Load += new System.EventHandler(this.FormChange_Load);
            this.Controls.SetChildIndex(this.lblCName, 0);
            this.Controls.SetChildIndex(this.lblCStreet, 0);
            this.Controls.SetChildIndex(this.lblCStreetNr, 0);
            this.Controls.SetChildIndex(this.lblCCity, 0);
            this.Controls.SetChildIndex(this.lblCzip, 0);
            this.Controls.SetChildIndex(this.txtCName, 0);
            this.Controls.SetChildIndex(this.txtCStreet, 0);
            this.Controls.SetChildIndex(this.txtCCity, 0);
            this.Controls.SetChildIndex(this.txtCStreetNr, 0);
            this.Controls.SetChildIndex(this.txtCzip, 0);
            this.Controls.SetChildIndex(this.btnCustomer, 0);
            this.Controls.SetChildIndex(this.lblLicense, 0);
            this.Controls.SetChildIndex(this.lblNetwork, 0);
            this.Controls.SetChildIndex(this.lstNetwork, 0);
            this.Controls.SetChildIndex(this.tabNetwork, 0);
            this.Controls.SetChildIndex(this.lblLicense2, 0);
            this.Controls.SetChildIndex(this.cmbLicense, 0);
            this.Controls.SetChildIndex(this.lblCount, 0);
            this.Controls.SetChildIndex(this.numCount, 0);
            this.Controls.SetChildIndex(this.btnLicense, 0);
            this.Controls.SetChildIndex(this.btnNetwork, 0);
            this.Controls.SetChildIndex(this.btnNetworkRemove, 0);
            this.tabNetwork.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCzip;
        private System.Windows.Forms.TextBox txtCStreetNr;
        private System.Windows.Forms.TextBox txtCCity;
        private System.Windows.Forms.TextBox txtCStreet;
        private System.Windows.Forms.TextBox txtCName;
        private System.Windows.Forms.Label lblCzip;
        private System.Windows.Forms.Label lblCCity;
        private System.Windows.Forms.Label lblCStreetNr;
        private System.Windows.Forms.Label lblCStreet;
        private System.Windows.Forms.Label lblCName;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.ListBox lstNetwork;
        private System.Windows.Forms.Label lblNetwork;
        private System.Windows.Forms.TabControl tabNetwork;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtEAByte4;
        private System.Windows.Forms.TextBox txtEAByte3;
        private System.Windows.Forms.TextBox txtEAByte2;
        private System.Windows.Forms.TextBox txtEAByte1;
        private System.Windows.Forms.TextBox txtSAByte4;
        private System.Windows.Forms.TextBox txtSAByte3;
        private System.Windows.Forms.TextBox txtSAByte2;
        private System.Windows.Forms.TextBox txtSAByte1;
        private System.Windows.Forms.Label lblNetworkEndadress;
        private System.Windows.Forms.Label lblNetworkStart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtHostByte4;
        private System.Windows.Forms.TextBox txtHostByte3;
        private System.Windows.Forms.TextBox txtHostByte2;
        private System.Windows.Forms.TextBox txtHostByte1;
        private System.Windows.Forms.Label lbllNetworkHost;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtCidrCidr;
        private System.Windows.Forms.Label lblNetworkCidr2;
        private System.Windows.Forms.TextBox txtCidrByte4;
        private System.Windows.Forms.TextBox txtCidrByte3;
        private System.Windows.Forms.TextBox txtCidrByte2;
        private System.Windows.Forms.TextBox txtCidrByte1;
        private System.Windows.Forms.Label lblNetworkCidr;
        private System.Windows.Forms.Label lblLicense2;
        private System.Windows.Forms.ComboBox cmbLicense;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.NumericUpDown numCount;
        private System.Windows.Forms.Button btnLicense;
        private System.Windows.Forms.Button btnNetwork;
        private System.Windows.Forms.Button btnNetworkRemove;
        private System.Windows.Forms.DataGridView dgvLicense;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLicense;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCount;
    }
}