namespace BP_LicenseAudit
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
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbInventary = new System.Windows.Forms.ComboBox();
            this.lblInventary = new System.Windows.Forms.Label();
            this.lblLicense = new System.Windows.Forms.Label();
            this.lstLicense = new System.Windows.Forms.ListBox();
            this.lblClients = new System.Windows.Forms.Label();
            this.lstClients = new System.Windows.Forms.ListBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.btnAudit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(51, 6);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(354, 21);
            this.cmbCustomer.TabIndex = 7;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(4, 9);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(41, 13);
            this.lblCustomer.TabIndex = 6;
            this.lblCustomer.Text = "Kunde:";
            // 
            // cmbInventary
            // 
            this.cmbInventary.FormattingEnabled = true;
            this.cmbInventary.Location = new System.Drawing.Point(51, 33);
            this.cmbInventary.Name = "cmbInventary";
            this.cmbInventary.Size = new System.Drawing.Size(354, 21);
            this.cmbInventary.TabIndex = 9;
            // 
            // lblInventary
            // 
            this.lblInventary.AutoSize = true;
            this.lblInventary.Location = new System.Drawing.Point(4, 36);
            this.lblInventary.Name = "lblInventary";
            this.lblInventary.Size = new System.Drawing.Size(49, 13);
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
            // lstLicense
            // 
            this.lstLicense.FormattingEnabled = true;
            this.lstLicense.Items.AddRange(new object[] {
            "(leer)"});
            this.lstLicense.Location = new System.Drawing.Point(7, 81);
            this.lstLicense.Name = "lstLicense";
            this.lstLicense.Size = new System.Drawing.Size(120, 290);
            this.lstLicense.TabIndex = 10;
            // 
            // lblClients
            // 
            this.lblClients.AutoSize = true;
            this.lblClients.Location = new System.Drawing.Point(140, 65);
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
            this.lstClients.Location = new System.Drawing.Point(143, 81);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(120, 290);
            this.lstClients.TabIndex = 12;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(282, 65);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(51, 13);
            this.lblResult.TabIndex = 15;
            this.lblResult.Text = "Ergebnis:";
            // 
            // lstResult
            // 
            this.lstResult.FormattingEnabled = true;
            this.lstResult.Items.AddRange(new object[] {
            "(leer)"});
            this.lstResult.Location = new System.Drawing.Point(285, 81);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(120, 290);
            this.lstResult.TabIndex = 14;
            // 
            // btnAudit
            // 
            this.btnAudit.Location = new System.Drawing.Point(7, 387);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(120, 30);
            this.btnAudit.TabIndex = 16;
            this.btnAudit.Text = "Audit starten";
            this.btnAudit.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(143, 387);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 30);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "Ergebnis drucken";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(285, 387);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(120, 30);
            this.btnEnd.TabIndex = 18;
            this.btnEnd.Text = "Ende";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // FormAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 429);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnAudit);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.lblClients);
            this.Controls.Add(this.lstClients);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.lstLicense);
            this.Controls.Add(this.cmbInventary);
            this.Controls.Add(this.lblInventary);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Name = "FormAudit";
            this.Text = "Audit durchführen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbInventary;
        private System.Windows.Forms.Label lblInventary;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.ListBox lstLicense;
        private System.Windows.Forms.Label lblClients;
        private System.Windows.Forms.ListBox lstClients;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Button btnAudit;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnEnd;
    }
}