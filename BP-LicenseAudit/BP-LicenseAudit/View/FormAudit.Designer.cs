﻿namespace BP_LicenseAudit.View
{
    partial class FormAudit
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
            this.cmbInventory = new System.Windows.Forms.ComboBox();
            this.lblInventary = new System.Windows.Forms.Label();
            this.lblLicense = new System.Windows.Forms.Label();
            this.lblClients = new System.Windows.Forms.Label();
            this.lstClients = new System.Windows.Forms.ListBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnAudit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvLicense = new System.Windows.Forms.DataGridView();
            this.clmLicense = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.clmLicenseResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCountResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicense)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbInventory
            // 
            this.cmbInventory.FormattingEnabled = true;
            this.cmbInventory.Location = new System.Drawing.Point(51, 33);
            this.cmbInventory.Name = "cmbInventary";
            this.cmbInventory.Size = new System.Drawing.Size(311, 21);
            this.cmbInventory.TabIndex = 9;
            this.cmbInventory.SelectedIndexChanged += new System.EventHandler(this.cmbInventory_SelectedIndexChanged);
            // 
            // lblInventary
            // 
            this.lblInventary.AutoSize = true;
            this.lblInventary.Location = new System.Drawing.Point(4, 36);
            this.lblInventary.Name = "lblInventary";
            this.lblInventary.Size = new System.Drawing.Size(182, 13);
            this.lblInventary.TabIndex = 8;
            this.lblInventary.Text = "Inventar:";
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Location = new System.Drawing.Point(4, 65);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(52, 13);
            this.lblLicense.TabIndex = 11;
            this.lblLicense.Text = "Lizenzen:";
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
            this.dgvLicense.Location = new System.Drawing.Point(7, 81);
            this.dgvLicense.Name = "dgvLicense";
            this.dgvLicense.ReadOnly = true;
            this.dgvLicense.RowHeadersVisible = false;
            this.dgvLicense.Size = new System.Drawing.Size(353, 290);
            this.dgvLicense.TabIndex = 11;
            this.dgvLicense.SelectionChanged += new System.EventHandler(this.dgvLicense_SelectionChanged);
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
            // lblClients
            // 
            this.lblClients.AutoSize = true;
            this.lblClients.Location = new System.Drawing.Point(373, 65);
            this.lblClients.Name = "lblClients";
            this.lblClients.Size = new System.Drawing.Size(41, 13);
            this.lblClients.TabIndex = 13;
            this.lblClients.Text = "Clients:";
            // 
            // lstClients
            // 
            this.lstClients.FormattingEnabled = true;
            this.lstClients.Items.AddRange(new object[] {
            "(leer)"});
            this.lstClients.Location = new System.Drawing.Point(376, 81);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(160, 290);
            this.lstClients.TabIndex = 12;
            this.lstClients.DisplayMember = "computername";
            this.lstClients.SelectionMode = System.Windows.Forms.SelectionMode.None;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(555, 65);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(51, 13);
            this.lblResult.TabIndex = 15;
            this.lblResult.Text = "Ergebnis:";
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToResizeColumns = false;
            this.dgvResult.AllowUserToResizeRows = false;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmLicenseResult,
            this.clmCountResult});
            this.dgvResult.Location = new System.Drawing.Point(555, 81);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.Size = new System.Drawing.Size(353, 290);
            this.dgvResult.TabIndex = 14;
            this.dgvResult.SelectionChanged += new System.EventHandler(this.dgvResult_SelectionChanged);
            // 
            // clmLicenseResult
            // 
            this.clmLicenseResult.HeaderText = "Lizenz";
            this.clmLicenseResult.Name = "clmLicenseResult";
            this.clmLicenseResult.ReadOnly = true;
            this.clmLicenseResult.Width = 300;
            // 
            // clmCountResult
            // 
            this.clmCountResult.HeaderText = "Frei";
            this.clmCountResult.Name = "clmCountResult";
            this.clmCountResult.ReadOnly = true;
            this.clmCountResult.Width = 50;
            // 
            // btnAudit
            // 
            this.btnAudit.Location = new System.Drawing.Point(7, 387);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(353, 30);
            this.btnAudit.TabIndex = 16;
            this.btnAudit.Text = "Audit starten";
            this.btnAudit.UseVisualStyleBackColor = true;
            this.btnAudit.Click += new System.EventHandler(this.btnAudit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(376, 387);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(160, 30);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "Ergebnis drucken";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            //
            //inherited Elements
            //
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Location = new System.Drawing.Point(51, 6);
            this.cmbCustomer.Size = new System.Drawing.Size(311, 21);
            this.cmbCustomer.TabIndex = 7;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(4, 9);
            this.lblCustomer.Size = new System.Drawing.Size(41, 13);
            this.lblCustomer.TabIndex = 6;
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(555, 387);
            this.btnEnd.Size = new System.Drawing.Size(353, 30);
            this.btnEnd.TabIndex = 18;
            // 
            // FormAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 429);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnAudit);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblClients);
            this.Controls.Add(this.lstClients);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.cmbInventory);
            this.Controls.Add(this.lblInventary);
            this.Controls.Add(this.dgvLicense);
            this.Controls.Add(this.dgvResult);
            this.Name = "FormAudit";
            this.Text = "Audit durchführen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbInventory;
        private System.Windows.Forms.Label lblInventary;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Label lblClients;
        private System.Windows.Forms.ListBox lstClients;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnAudit;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvLicense;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLicense;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCount;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLicenseResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCountResult;
    }
}