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
            this.lstLicenses = new System.Windows.Forms.ListBox();
            this.lblLicenses = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstLicenses
            // 
            this.lstLicenses.FormattingEnabled = true;
            this.lstLicenses.Items.AddRange(new object[] {
            "(leer)"});
            this.lstLicenses.Location = new System.Drawing.Point(9, 54);
            this.lstLicenses.Name = "lstLicenses";
            this.lstLicenses.Size = new System.Drawing.Size(120, 173);
            this.lstLicenses.TabIndex = 5;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Lizenz:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(181, 51);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(124, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Anzahl:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(183, 89);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(122, 20);
            this.numericUpDown1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 39);
            this.button1.TabIndex = 10;
            this.button1.Text = "Lizenzen hinzufügen";
            this.button1.UseVisualStyleBackColor = true;
            //
            //inherited Elements
            //
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Location = new System.Drawing.Point(53, 9);
            this.cmbCustomer.Size = new System.Drawing.Size(252, 21);
            this.cmbCustomer.TabIndex = 3;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(6, 12);
            this.lblCustomer.Size = new System.Drawing.Size(41, 13);
            this.lblCustomer.TabIndex = 2;
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(229, 152);
            this.btnEnd.Size = new System.Drawing.Size(76, 39);
            this.btnEnd.TabIndex = 11;
            // 
            // FormLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 239);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstLicenses);
            this.Controls.Add(this.lblLicenses);
            this.Name = "FormLicense";
            this.Text = "FormLicense";
            this.Load += new System.EventHandler(this.FormLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstLicenses;
        private System.Windows.Forms.Label lblLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
    }
}