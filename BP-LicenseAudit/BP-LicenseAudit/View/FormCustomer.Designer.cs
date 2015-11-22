namespace BP_LicenseAudit.View
{
    partial class FormCustomer
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
            this.lblCNr = new System.Windows.Forms.Label();
            this.lblCNrShow = new System.Windows.Forms.Label();
            this.lblCName = new System.Windows.Forms.Label();
            this.lblCStreet = new System.Windows.Forms.Label();
            this.lblCStreetNr = new System.Windows.Forms.Label();
            this.lblCCity = new System.Windows.Forms.Label();
            this.lblCzip = new System.Windows.Forms.Label();
            this.txtCName = new System.Windows.Forms.TextBox();
            this.txtCStreet = new System.Windows.Forms.TextBox();
            this.txtCCity = new System.Windows.Forms.TextBox();
            this.txtCStreetNr = new System.Windows.Forms.TextBox();
            this.txtCzip = new System.Windows.Forms.TextBox();
            this.btnSaveNext = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCNr
            // 
            this.lblCNr.AutoSize = true;
            this.lblCNr.Location = new System.Drawing.Point(13, 13);
            this.lblCNr.Name = "lblCNr";
            this.lblCNr.Size = new System.Drawing.Size(84, 13);
            this.lblCNr.TabIndex = 0;
            this.lblCNr.Text = "Kundennummer:";
            // 
            // lblCNrShow
            // 
            this.lblCNrShow.AutoSize = true;
            this.lblCNrShow.Location = new System.Drawing.Point(131, 13);
            this.lblCNrShow.Name = "lblCNrShow";
            this.lblCNrShow.Size = new System.Drawing.Size(13, 13);
            this.lblCNrShow.TabIndex = 1;
            this.lblCNrShow.Text = "1";
            // 
            // lblCName
            // 
            this.lblCName.AutoSize = true;
            this.lblCName.Location = new System.Drawing.Point(12, 39);
            this.lblCName.Name = "lblCName";
            this.lblCName.Size = new System.Drawing.Size(38, 13);
            this.lblCName.TabIndex = 2;
            this.lblCName.Text = "Name:";
            // 
            // lblCStreet
            // 
            this.lblCStreet.AutoSize = true;
            this.lblCStreet.Location = new System.Drawing.Point(13, 67);
            this.lblCStreet.Name = "lblCStreet";
            this.lblCStreet.Size = new System.Drawing.Size(45, 13);
            this.lblCStreet.TabIndex = 3;
            this.lblCStreet.Text = "Strasse:";
            // 
            // lblCStreetNr
            // 
            this.lblCStreetNr.AutoSize = true;
            this.lblCStreetNr.Location = new System.Drawing.Point(248, 67);
            this.lblCStreetNr.Name = "lblCStreetNr";
            this.lblCStreetNr.Size = new System.Drawing.Size(24, 13);
            this.lblCStreetNr.TabIndex = 4;
            this.lblCStreetNr.Text = "Nr.:";
            // 
            // lblCCity
            // 
            this.lblCCity.AutoSize = true;
            this.lblCCity.Location = new System.Drawing.Point(13, 96);
            this.lblCCity.Name = "lblCCity";
            this.lblCCity.Size = new System.Drawing.Size(24, 13);
            this.lblCCity.TabIndex = 5;
            this.lblCCity.Text = "Ort:";
            // 
            // lblCzip
            // 
            this.lblCzip.AutoSize = true;
            this.lblCzip.Location = new System.Drawing.Point(248, 96);
            this.lblCzip.Name = "lblCzip";
            this.lblCzip.Size = new System.Drawing.Size(30, 13);
            this.lblCzip.TabIndex = 6;
            this.lblCzip.Text = "PLZ:";
            // 
            // txtCName
            // 
            this.txtCName.Location = new System.Drawing.Point(56, 36);
            this.txtCName.Name = "txtCName";
            this.txtCName.Size = new System.Drawing.Size(300, 20);
            this.txtCName.TabIndex = 7;
            // 
            // txtCStreet
            // 
            this.txtCStreet.Location = new System.Drawing.Point(56, 64);
            this.txtCStreet.Name = "txtCStreet";
            this.txtCStreet.Size = new System.Drawing.Size(163, 20);
            this.txtCStreet.TabIndex = 8;
            // 
            // txtCCity
            // 
            this.txtCCity.Location = new System.Drawing.Point(56, 93);
            this.txtCCity.Name = "txtCCity";
            this.txtCCity.Size = new System.Drawing.Size(163, 20);
            this.txtCCity.TabIndex = 9;
            // 
            // txtCStreetNr
            // 
            this.txtCStreetNr.Location = new System.Drawing.Point(278, 64);
            this.txtCStreetNr.Name = "txtCStreetNr";
            this.txtCStreetNr.Size = new System.Drawing.Size(78, 20);
            this.txtCStreetNr.TabIndex = 10;
            // 
            // txtCzip
            // 
            this.txtCzip.Location = new System.Drawing.Point(278, 93);
            this.txtCzip.Name = "txtCzip";
            this.txtCzip.Size = new System.Drawing.Size(78, 20);
            this.txtCzip.TabIndex = 11;
            // 
            // btnSaveNext
            // 
            this.btnSaveNext.Location = new System.Drawing.Point(15, 128);
            this.btnSaveNext.Name = "btnSaveNext";
            this.btnSaveNext.Size = new System.Drawing.Size(107, 36);
            this.btnSaveNext.TabIndex = 12;
            this.btnSaveNext.Text = "Speichern und nächster Kunde";
            this.btnSaveNext.UseVisualStyleBackColor = true;
            this.btnSaveNext.Click += new System.EventHandler(this.btnSaveNext_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(128, 128);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 36);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Speichern und Ende";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            //Inherited Elements
            //
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(251, 128);
            this.btnEnd.Size = new System.Drawing.Size(105, 36);
            this.btnEnd.TabIndex = 14;
            //
            //lblCustomer
            //
            this.lblCustomer.Visible = false;
            this.lblCustomer.Enabled = false;
            //
            //cmbCustomer
            //
            this.cmbCustomer.Visible = false;
            this.cmbCustomer.Enabled = false;
            // 
            // FormCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 178);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSaveNext);
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
            this.Controls.Add(this.lblCNrShow);
            this.Controls.Add(this.lblCNr);
            this.Name = "FormCustomer";
            this.Text = "Kundenverwaltung";
            this.Controls.SetChildIndex(this.lblCNr, 0);
            this.Controls.SetChildIndex(this.lblCNrShow, 0);
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
            this.Controls.SetChildIndex(this.btnSaveNext, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCNr;
        private System.Windows.Forms.Label lblCNrShow;
        private System.Windows.Forms.Label lblCName;
        private System.Windows.Forms.Label lblCStreet;
        private System.Windows.Forms.Label lblCStreetNr;
        private System.Windows.Forms.Label lblCCity;
        private System.Windows.Forms.Label lblCzip;
        private System.Windows.Forms.TextBox txtCName;
        private System.Windows.Forms.TextBox txtCStreet;
        private System.Windows.Forms.TextBox txtCCity;
        private System.Windows.Forms.TextBox txtCStreetNr;
        private System.Windows.Forms.TextBox txtCzip;
        private System.Windows.Forms.Button btnSaveNext;
        private System.Windows.Forms.Button btnSave;
    }
}