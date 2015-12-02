﻿namespace BP_LicenseAudit.View
{
    partial class FormSystemInventory
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
            this.lblNetwork = new System.Windows.Forms.Label();
            this.lstNetworks = new System.Windows.Forms.ListBox();
            this.lstClients = new System.Windows.Forms.ListBox();
            this.lblClients = new System.Windows.Forms.Label();
            this.lstDetails = new System.Windows.Forms.ListBox();
            this.lblDetail = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnInventory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNetwork
            // 
            this.lblNetwork.AutoSize = true;
            this.lblNetwork.Location = new System.Drawing.Point(7, 39);
            this.lblNetwork.Name = "lblNetwork";
            this.lblNetwork.Size = new System.Drawing.Size(61, 13);
            this.lblNetwork.TabIndex = 6;
            this.lblNetwork.Text = "Netzwerke:";
            // 
            // lstNetworks
            // 
            this.lstNetworks.FormattingEnabled = true;
            this.lstNetworks.Items.AddRange(new object[] {
            "(leer)"});
            this.lstNetworks.Location = new System.Drawing.Point(10, 56);
            this.lstNetworks.Name = "lstNetworks";
            this.lstNetworks.Size = new System.Drawing.Size(120, 199);
            this.lstNetworks.TabIndex = 7;
            this.lstNetworks.DisplayMember = "Name";
            this.lstNetworks.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstNetworks.SelectedIndexChanged += new System.EventHandler(this.lstNetworks_SelectedIndexChanged);
            // 
            // lstClients
            // 
            this.lstClients.FormattingEnabled = true;
            this.lstClients.Items.AddRange(new object[] {
            "(leer)"});
            this.lstClients.Location = new System.Drawing.Point(152, 56);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(120, 199);
            this.lstClients.TabIndex = 9;
            // 
            // lblClients
            // 
            this.lblClients.AutoSize = true;
            this.lblClients.Location = new System.Drawing.Point(149, 39);
            this.lblClients.Name = "lblClients";
            this.lblClients.Size = new System.Drawing.Size(41, 13);
            this.lblClients.TabIndex = 8;
            this.lblClients.Text = "Clients:";
            // 
            // lstDetails
            // 
            this.lstDetails.FormattingEnabled = true;
            this.lstDetails.Items.AddRange(new object[] {
            "(leer)"});
            this.lstDetails.Location = new System.Drawing.Point(296, 56);
            this.lstDetails.Name = "lstDetails";
            this.lstDetails.Size = new System.Drawing.Size(120, 199);
            this.lstDetails.TabIndex = 11;
            this.lstDetails.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Location = new System.Drawing.Point(293, 39);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(42, 13);
            this.lblDetail.TabIndex = 10;
            this.lblDetail.Text = "Details:";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(12, 261);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(96, 17);
            this.chkAll.TabIndex = 12;
            this.chkAll.Text = "alle auswählen";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnInventory
            // 
            this.btnInventory.Location = new System.Drawing.Point(10, 297);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(140, 33);
            this.btnInventory.TabIndex = 13;
            this.btnInventory.Text = "Inventarisierung starten";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(btnInventory_Click);
            //
            //inherited Elements
            //
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Location = new System.Drawing.Point(54, 9);
            this.cmbCustomer.Size = new System.Drawing.Size(362, 21);
            this.cmbCustomer.TabIndex = 5;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(7, 12);
            this.lblCustomer.Size = new System.Drawing.Size(41, 13);
            this.lblCustomer.TabIndex = 4;
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(166, 297);
            this.btnEnd.Size = new System.Drawing.Size(140, 33);
            this.btnEnd.TabIndex = 14;
            // 
            // FormSystemInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 338);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.lstDetails);
            this.Controls.Add(this.lblDetail);
            this.Controls.Add(this.lstClients);
            this.Controls.Add(this.lblClients);
            this.Controls.Add(this.lstNetworks);
            this.Controls.Add(this.lblNetwork);
            this.Name = "FormSystemInventory";
            this.Text = "Inventarisierung durchführen";
            this.Load += new System.EventHandler(this.FormInventary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNetwork;
        private System.Windows.Forms.ListBox lstNetworks;
        private System.Windows.Forms.ListBox lstClients;
        private System.Windows.Forms.Label lblClients;
        private System.Windows.Forms.ListBox lstDetails;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnInventory;
    }
}