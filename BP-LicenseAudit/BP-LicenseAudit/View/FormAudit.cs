using System;
using System.Windows.Forms;
using BP_LicenseAudit.Controller;
using BP_LicenseAudit.Model;

namespace BP_LicenseAudit.View
{
    public partial class FormAudit : FormParent
    {
        private ControllerAudit currentcontroller;
        public ControllerAudit Currentcontroller
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
        public FormAudit()
        {
            InitializeComponent();
        }

        protected override void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedItem != null) currentcontroller.SelectedCustomerChanged(cmbCustomer.SelectedItem);
        }

        public void DisableAudit()
        {
            btnAudit.Enabled = false;
        }

        public void EnableAudit()
        {
            btnAudit.Enabled = true;
        }

        public void ClearLicenses()
        {
            dgvLicense.Rows.Clear();
        }

        private void dgvLicense_SelectionChanged(Object sender, EventArgs e)
        {
            dgvLicense.ClearSelection();
        }

        public void AddLicense(string license, int count)
        {
            int i = dgvLicense.Rows.Add();
            dgvLicense.Rows[i].Cells[0].Value = license;
            dgvLicense.Rows[i].Cells[1].Value = count;
        }

        public void ClearSystemInventory()
        {
            cmbInventory.Items.Clear();
            lstClients.Items.Clear();
        }

        public void AddSystemInventory(string inventory)
        {
            cmbInventory.Items.Add(inventory);
            cmbInventory.SelectedItem = inventory;
        }

        public void AddClientSystem(ClientSystem c)
        {
            lstClients.Items.Add(c);
        }
    }
}
