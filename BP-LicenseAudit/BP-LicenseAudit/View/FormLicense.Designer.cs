namespace BP_LicenseAudit.View
{
    partial class FormLicense
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
            this.lblLicenses = new System.Windows.Forms.Label();
            this.lblLicense = new System.Windows.Forms.Label();
            this.cmbLicense = new System.Windows.Forms.ComboBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.numCount = new System.Windows.Forms.NumericUpDown();
            this.btnLicense = new System.Windows.Forms.Button();
            this.dgvLicense = new System.Windows.Forms.DataGridView();
            this.clmLicense = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicense)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLicenses
            // 
            this.lblLicenses.AutoSize = true;
            this.lblLicenses.Location = new System.Drawing.Point(6, 37);
            this.lblLicenses.Name = "lblLicenses";
            this.lblLicenses.Size = new System.Drawing.Size(52, 13);
            this.lblLicenses.TabIndex = 4;
            this.lblLicenses.Text = "Lizenzen:";
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Location = new System.Drawing.Point(6, 276);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(40, 13);
            this.lblLicense.TabIndex = 6;
            this.lblLicense.Text = "Lizenz:";
            // 
            // cmbLicense
            // 
            this.cmbLicense.DisplayMember = "Name";
            this.cmbLicense.FormattingEnabled = true;
            this.cmbLicense.Location = new System.Drawing.Point(52, 273);
            this.cmbLicense.Name = "cmbLicense";
            this.cmbLicense.Size = new System.Drawing.Size(310, 21);
            this.cmbLicense.TabIndex = 7;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(6, 313);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(42, 13);
            this.lblCount.TabIndex = 8;
            this.lblCount.Text = "Anzahl:";
            // 
            // numCount
            // 
            this.numCount.Location = new System.Drawing.Point(52, 311);
            this.numCount.Name = "numCount";
            this.numCount.Size = new System.Drawing.Size(310, 20);
            this.numCount.TabIndex = 9;
            // 
            // btnLicense
            // 
            this.btnLicense.Location = new System.Drawing.Point(9, 347);
            this.btnLicense.Name = "btnLicense";
            this.btnLicense.Size = new System.Drawing.Size(170, 39);
            this.btnLicense.TabIndex = 10;
            this.btnLicense.Text = "Lizenzen hinzufügen";
            this.btnLicense.UseVisualStyleBackColor = true;
            this.btnLicense.Click += new System.EventHandler(this.btnLicense_Click);
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
            this.dgvLicense.Location = new System.Drawing.Point(9, 58);
            this.dgvLicense.Name = "dgvLicense";
            this.dgvLicense.ReadOnly = true;
            this.dgvLicense.RowHeadersVisible = false;
            this.dgvLicense.Size = new System.Drawing.Size(353, 200);
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
            //inherited Elements
            //
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Location = new System.Drawing.Point(53, 9);
            this.cmbCustomer.Size = new System.Drawing.Size(312, 21);
            this.cmbCustomer.TabIndex = 3;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(6, 12);
            this.lblCustomer.Size = new System.Drawing.Size(41, 13);
            this.lblCustomer.TabIndex = 2;
            // 
            // btnEnd
            this.btnEnd.Location = new System.Drawing.Point(195, 347);
            this.btnEnd.Size = new System.Drawing.Size(167, 39);
            this.btnEnd.TabIndex = 11;
            // 
            // FormLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 398);
            this.Controls.Add(this.dgvLicense);
            this.Controls.Add(this.btnLicense);
            this.Controls.Add(this.numCount);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.cmbLicense);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.lblLicenses);
            this.Name = "FormLicense";
            this.Text = "FormLicense";
            this.Load += new System.EventHandler(this.FormLicense_Load);
            this.Controls.SetChildIndex(this.lblLicenses, 0);
            this.Controls.SetChildIndex(this.lblLicense, 0);
            this.Controls.SetChildIndex(this.cmbLicense, 0);
            this.Controls.SetChildIndex(this.lblCount, 0);
            this.Controls.SetChildIndex(this.numCount, 0);
            this.Controls.SetChildIndex(this.btnLicense, 0);
            this.Controls.SetChildIndex(this.dgvLicense, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicense)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblLicenses;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.ComboBox cmbLicense;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.NumericUpDown numCount;
        private System.Windows.Forms.Button btnLicense;
        private System.Windows.Forms.DataGridView dgvLicense;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLicense;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCount;
    }
}