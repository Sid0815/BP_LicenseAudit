namespace BP_LicenseAudit.View
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstCustomer = new System.Windows.Forms.ListBox();
            this.lblNetworks = new System.Windows.Forms.Label();
            this.lstNetworks = new System.Windows.Forms.ListBox();
            this.lblLicense = new System.Windows.Forms.Label();
            this.lblActions = new System.Windows.Forms.Label();
            this.lstActions = new System.Windows.Forms.ListBox();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnNetwork = new System.Windows.Forms.Button();
            this.btnLicense = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnAudit = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.dgvLicenses = new System.Windows.Forms.DataGridView();
            this.clmLicense = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenses)).BeginInit();
            this.SuspendLayout();
            // 
            // lstCustomer
            // 
            this.lstCustomer.DisplayMember = "Name";
            this.lstCustomer.FormattingEnabled = true;
            this.lstCustomer.Items.AddRange(new object[] {
            "(leer)"});
            this.lstCustomer.Location = new System.Drawing.Point(10, 23);
            this.lstCustomer.Name = "lstCustomer";
            this.lstCustomer.Size = new System.Drawing.Size(180, 446);
            this.lstCustomer.TabIndex = 0;
            this.lstCustomer.SelectedIndexChanged += new System.EventHandler(this.lstCustomer_SelectedIndexChanged);
            // 
            // lblNetworks
            // 
            this.lblNetworks.AutoSize = true;
            this.lblNetworks.Location = new System.Drawing.Point(210, 7);
            this.lblNetworks.Name = "lblNetworks";
            this.lblNetworks.Size = new System.Drawing.Size(61, 13);
            this.lblNetworks.TabIndex = 3;
            this.lblNetworks.Text = "Netzwerke:";
            // 
            // lstNetworks
            // 
            this.lstNetworks.DisplayMember = "Name";
            this.lstNetworks.FormattingEnabled = true;
            this.lstNetworks.Items.AddRange(new object[] {
            "(leer)"});
            this.lstNetworks.Location = new System.Drawing.Point(210, 23);
            this.lstNetworks.Name = "lstNetworks";
            this.lstNetworks.Size = new System.Drawing.Size(180, 446);
            this.lstNetworks.TabIndex = 2;
            this.lstNetworks.SelectionMode = System.Windows.Forms.SelectionMode.None;
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Location = new System.Drawing.Point(410, 7);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(52, 13);
            this.lblLicense.TabIndex = 5;
            this.lblLicense.Text = "Lizenzen:";
            // 
            // lblActions
            // 
            this.lblActions.AutoSize = true;
            this.lblActions.Location = new System.Drawing.Point(780, 7);
            this.lblActions.Name = "lblActions";
            this.lblActions.Size = new System.Drawing.Size(131, 13);
            this.lblActions.TabIndex = 7;
            this.lblActions.Text = "Audits / Invetarisierungen:";
            // 
            // lstActions
            // 
            this.lstActions.FormattingEnabled = true;
            this.lstActions.Items.AddRange(new object[] {
            "(leer)"});
            this.lstActions.Location = new System.Drawing.Point(780, 23);
            this.lstActions.Name = "lstActions";
            this.lstActions.Size = new System.Drawing.Size(190, 446);
            this.lstActions.TabIndex = 6;
            this.lstActions.SelectionMode = System.Windows.Forms.SelectionMode.None;
            // 
            // btnCustomer
            // 
            this.btnCustomer.Location = new System.Drawing.Point(10, 480);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(180, 35);
            this.btnCustomer.TabIndex = 8;
            this.btnCustomer.Text = "Kunde hinzufügen";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnNetwork
            // 
            this.btnNetwork.Location = new System.Drawing.Point(210, 480);
            this.btnNetwork.Name = "btnNetwork";
            this.btnNetwork.Size = new System.Drawing.Size(180, 35);
            this.btnNetwork.TabIndex = 9;
            this.btnNetwork.Text = "Netzwerk hinzufügen";
            this.btnNetwork.UseVisualStyleBackColor = true;
            this.btnNetwork.Click += new System.EventHandler(this.btnNetwork_Click);
            // 
            // btnLicense
            // 
            this.btnLicense.Location = new System.Drawing.Point(410, 480);
            this.btnLicense.Name = "btnLicense";
            this.btnLicense.Size = new System.Drawing.Size(353, 35);
            this.btnLicense.TabIndex = 10;
            this.btnLicense.Text = "Lizenzen hinzufügen";
            this.btnLicense.UseVisualStyleBackColor = true;
            this.btnLicense.Click += new System.EventHandler(this.btnLicense_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Location = new System.Drawing.Point(780, 480);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(190, 35);
            this.btnInventory.TabIndex = 11;
            this.btnInventory.Text = "Inventarisierung durchführen";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnAudit
            // 
            this.btnAudit.Location = new System.Drawing.Point(780, 530);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(190, 35);
            this.btnAudit.TabIndex = 12;
            this.btnAudit.Text = "Audit durchführen";
            this.btnAudit.UseVisualStyleBackColor = true;
            this.btnAudit.Click += new System.EventHandler(this.btnAudit_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(990, 23);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(180, 35);
            this.btnChange.TabIndex = 13;
            this.btnChange.Text = "Daten ändern";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // dgvLicenses
            // 
            this.dgvLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLicenses.Location = new System.Drawing.Point(410, 23);
            this.dgvLicenses.Name = "dgvLicenses";
            this.dgvLicenses.Size = new System.Drawing.Size(353, 446);
            this.dgvLicenses.TabIndex = 14;
            this.dgvLicenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmLicense,
            this.clmCount});
            this.dgvLicenses.AllowUserToAddRows = false;
            this.dgvLicenses.AllowUserToDeleteRows = false;
            this.dgvLicenses.AllowUserToResizeColumns = false;
            this.dgvLicenses.AllowUserToResizeRows = false;
            this.dgvLicenses.ReadOnly = true;
            this.dgvLicenses.RowHeadersVisible = false;
            this.dgvLicenses.SelectionChanged += new System.EventHandler(this.dgvLicenses_SelectionChanged);
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
            //inherited elements            
            //
            //btnEnde
            //
            this.btnEnd.Location = new System.Drawing.Point(990, 60);
            this.btnEnd.Size = new System.Drawing.Size(180, 35);
            //
            //lblCustomer
            //
            this.lblCustomer.Location = new System.Drawing.Point(10, 7);
            this.lblCustomer.Size = new System.Drawing.Size(47, 13);
            //cmbCustomer
            this.cmbCustomer.Visible = false;
            this.cmbCustomer.Enabled = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 576);
            this.Controls.Add(this.dgvLicenses);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnAudit);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnLicense);
            this.Controls.Add(this.btnNetwork);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.lblActions);
            this.Controls.Add(this.lstActions);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.lblNetworks);
            this.Controls.Add(this.lstNetworks);
            this.Controls.Add(this.lstCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.Text = "BP-LicenseAudit";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.lstCustomer, 0);
            this.Controls.SetChildIndex(this.lstNetworks, 0);
            this.Controls.SetChildIndex(this.lblNetworks, 0);
            this.Controls.SetChildIndex(this.lblLicense, 0);
            this.Controls.SetChildIndex(this.lstActions, 0);
            this.Controls.SetChildIndex(this.lblActions, 0);
            this.Controls.SetChildIndex(this.btnCustomer, 0);
            this.Controls.SetChildIndex(this.btnNetwork, 0);
            this.Controls.SetChildIndex(this.btnLicense, 0);
            this.Controls.SetChildIndex(this.btnInventory, 0);
            this.Controls.SetChildIndex(this.btnAudit, 0);
            this.Controls.SetChildIndex(this.btnChange, 0);
            this.Controls.SetChildIndex(this.dgvLicenses, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCustomer;
        private System.Windows.Forms.Label lblNetworks;
        private System.Windows.Forms.ListBox lstNetworks;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Label lblActions;
        private System.Windows.Forms.ListBox lstActions;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnNetwork;
        private System.Windows.Forms.Button btnLicense;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnAudit;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.DataGridView dgvLicenses;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLicense;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCount;
    }
}

