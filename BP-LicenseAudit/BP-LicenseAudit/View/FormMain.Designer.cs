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
            this.lstLicense = new System.Windows.Forms.ListBox();
            this.lblActions = new System.Windows.Forms.Label();
            this.lstActions = new System.Windows.Forms.ListBox();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnNetwork = new System.Windows.Forms.Button();
            this.btnLicense = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnAudit = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstCustomer
            // 
            this.lstCustomer.FormattingEnabled = true;
            this.lstCustomer.Items.AddRange(new object[] {
            "(leer)"});
            this.lstCustomer.Location = new System.Drawing.Point(12, 23);
            this.lstCustomer.Name = "lstCustomer";
            this.lstCustomer.Size = new System.Drawing.Size(120, 290);
            this.lstCustomer.TabIndex = 0;
            // 
            // lblNetworks
            // 
            this.lblNetworks.AutoSize = true;
            this.lblNetworks.Location = new System.Drawing.Point(147, 7);
            this.lblNetworks.Name = "lblNetworks";
            this.lblNetworks.Size = new System.Drawing.Size(61, 13);
            this.lblNetworks.TabIndex = 3;
            this.lblNetworks.Text = "Netzwerke:";
            // 
            // lstNetworks
            // 
            this.lstNetworks.FormattingEnabled = true;
            this.lstNetworks.Items.AddRange(new object[] {
            "(leer)"});
            this.lstNetworks.Location = new System.Drawing.Point(150, 23);
            this.lstNetworks.Name = "lstNetworks";
            this.lstNetworks.Size = new System.Drawing.Size(120, 290);
            this.lstNetworks.TabIndex = 2;
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Location = new System.Drawing.Point(284, 7);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(52, 13);
            this.lblLicense.TabIndex = 5;
            this.lblLicense.Text = "Lizenzen:";
            // 
            // lstLicense
            // 
            this.lstLicense.FormattingEnabled = true;
            this.lstLicense.Items.AddRange(new object[] {
            "(leer)"});
            this.lstLicense.Location = new System.Drawing.Point(287, 23);
            this.lstLicense.Name = "lstLicense";
            this.lstLicense.Size = new System.Drawing.Size(120, 290);
            this.lstLicense.TabIndex = 4;
            // 
            // lblActions
            // 
            this.lblActions.AutoSize = true;
            this.lblActions.Location = new System.Drawing.Point(426, 7);
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
            this.lstActions.Location = new System.Drawing.Point(426, 23);
            this.lstActions.Name = "lstActions";
            this.lstActions.Size = new System.Drawing.Size(120, 290);
            this.lstActions.TabIndex = 6;
            // 
            // btnCustomer
            // 
            this.btnCustomer.Location = new System.Drawing.Point(15, 332);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(117, 35);
            this.btnCustomer.TabIndex = 8;
            this.btnCustomer.Text = "Kunde hinzufügen";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnNetwork
            // 
            this.btnNetwork.Location = new System.Drawing.Point(150, 332);
            this.btnNetwork.Name = "btnNetwork";
            this.btnNetwork.Size = new System.Drawing.Size(117, 35);
            this.btnNetwork.TabIndex = 9;
            this.btnNetwork.Text = "Netzwerk hinzufügen";
            this.btnNetwork.UseVisualStyleBackColor = true;
            this.btnNetwork.Click += new System.EventHandler(this.btnNetwork_Click);
            // 
            // btnLicense
            // 
            this.btnLicense.Location = new System.Drawing.Point(290, 332);
            this.btnLicense.Name = "btnLicense";
            this.btnLicense.Size = new System.Drawing.Size(117, 35);
            this.btnLicense.TabIndex = 10;
            this.btnLicense.Text = "Lizenzen hinzufügen";
            this.btnLicense.UseVisualStyleBackColor = true;
            this.btnLicense.Click += new System.EventHandler(this.btnLicense_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Location = new System.Drawing.Point(426, 332);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(117, 35);
            this.btnInventory.TabIndex = 11;
            this.btnInventory.Text = "Inventarisierung durchführen";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnAudit
            // 
            this.btnAudit.Location = new System.Drawing.Point(426, 373);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(117, 35);
            this.btnAudit.TabIndex = 12;
            this.btnAudit.Text = "Audit durchführen";
            this.btnAudit.UseVisualStyleBackColor = true;
            this.btnAudit.Click += new System.EventHandler(this.btnAudit_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(586, 23);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(117, 35);
            this.btnChange.TabIndex = 13;
            this.btnChange.Text = "Daten ändern";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            //
            //inherited elements            
            //
            //btnEnde
            //
            this.btnEnd.Location = new System.Drawing.Point(586, 61);
            this.btnEnd.Size = new System.Drawing.Size(117, 35);
            //
            //lblCustomer
            //
            this.lblCustomer.Location = new System.Drawing.Point(12, 7);
            this.lblCustomer.Size = new System.Drawing.Size(47, 13);
            //cmbCustomer
            this.cmbCustomer.Visible = false;
            this.cmbCustomer.Enabled = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 421);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnAudit);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnLicense);
            this.Controls.Add(this.btnNetwork);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.lblActions);
            this.Controls.Add(this.lstActions);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.lstLicense);
            this.Controls.Add(this.lblNetworks);
            this.Controls.Add(this.lstNetworks);
            this.Controls.Add(this.lstCustomer);
            this.Name = "FormMain";
            this.Text = "Hauptfenster";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCustomer;
        private System.Windows.Forms.Label lblNetworks;
        private System.Windows.Forms.ListBox lstNetworks;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.ListBox lstLicense;
        private System.Windows.Forms.Label lblActions;
        private System.Windows.Forms.ListBox lstActions;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnNetwork;
        private System.Windows.Forms.Button btnLicense;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnAudit;
        private System.Windows.Forms.Button btnChange;
    }
}

