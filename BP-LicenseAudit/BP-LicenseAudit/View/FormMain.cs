using System;
using BP_LicenseAudit.Controller;
using BP_LicenseAudit.Model;

namespace BP_LicenseAudit.View
{
    public partial class FormMain : FormParent
    {
        private ControllerMain currentcontroller;
        public ControllerMain Currentcontroller
        {
            private get
            {
                return currentcontroller;
            }
            set
            {
                currentcontroller = value;
            }
        }
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            currentcontroller.OpenForm("Customer");
        }

        private void btnNetwork_Click(object sender, EventArgs e)
        {
            currentcontroller.OpenForm("Network");
        }

        private void btnLicense_Click(object sender, EventArgs e)
        {
            currentcontroller.OpenForm("License");
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            currentcontroller.OpenForm("SystemInventory");
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            currentcontroller.OpenForm("Changes");
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            currentcontroller.OpenForm("Audit");
        }

        public override void AddCustomer(Customer customer)
        {
            lstCustomer.Items.Add(customer);
        }

        //DOUBLED
        public void ClearCustomerList()
        {
            lstCustomer.Items.Clear();
        }

        public override void ClearCustomers()
        {
            lstCustomer.Items.Clear();
        }

        public void AddNetwork(Network network)
        {
            lstNetworks.Items.Add(network);
        }

        public void ClearNetworks()
        {
            lstNetworks.Items.Clear();
        }

        public void lstCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentcontroller.SelectedCustomerChanged(lstCustomer.SelectedItem);
        }

        public void ClearLicenses()
        {
            dgvLicenses.Rows.Clear();
        }

        public void AddLicense(string license, int count)
        {
            int i = dgvLicenses.Rows.Add();
            dgvLicenses.Rows[i].Cells[0].Value = license;
            dgvLicenses.Rows[i].Cells[1].Value = count;
        }

        private void dgvLicenses_SelectionChanged(Object sender, EventArgs e)
        {
            dgvLicenses.ClearSelection();
        }

    }
}
