using BP_LicenseAudit.Controller;
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

        public void SetAllCustomersToCmbCustomer()
        {

        }

        public void SetCustomer()
        {

        }

        public void GetCustomer()
        {

        }

        private void FormParent_Load(object sender, EventArgs e)
        {

        }

        public void AddCustomer(Customer customer)
        {
            cmbCustomer.Items.Add(customer);
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
