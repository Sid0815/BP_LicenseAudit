﻿using BP_LicenseAudit.Controller;
using BP_LicenseAudit.Model;
using System;

using System.Windows.Forms;

namespace BP_LicenseAudit.View
{
    public partial class FormParent : Form
    {

        public FormParent()
        {
            InitializeComponent();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SetCustomer(Customer customer)
        {
            cmbCustomer.SelectedItem = customer;
        }

        private void FormParent_Load(object sender, EventArgs e)
        {

        }

        public virtual void AddCustomer(Customer customer)
        {
            cmbCustomer.Items.Add(customer);
        }

        public virtual void ClearCustomers()
        {
            cmbCustomer.Items.Clear();
        }

        protected virtual void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
