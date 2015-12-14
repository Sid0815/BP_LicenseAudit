using System;
using BP_LicenseAudit.Controller;
using BP_LicenseAudit.Model;

namespace BP_LicenseAudit.View
{

    public partial class FormLicense : FormParent
    {
        private ControllerLicense currentcontroller;

        public ControllerLicense Currentcontroller
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
        public FormLicense()
        {
            InitializeComponent();
        }

        private void FormLicense_Load(object sender, EventArgs e)
        {

        }


        public void AddLicenseType(License l)
        {
            cmbLicense.Items.Add(l);
        }

        public int CountLicenseTypes()
        {
            return cmbLicense.Items.Count;
        }

        public void ClearLicenseTypes()
        {
            cmbLicense.Items.Clear();
        }

        public void AddLicense(string license, int count)
        {
            int i = dgvLicense.Rows.Add();
            dgvLicense.Rows[i].Cells[0].Value = license;
            dgvLicense.Rows[i].Cells[1].Value = count;
        }

        public void ClearLicenses()
        {
            dgvLicense.Rows.Clear();
        }

        protected override void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedItem != null) currentcontroller.SelectedCustomerChanged(cmbCustomer.SelectedItem);
        }

        private void btnLicense_Click(object sender, EventArgs e)
        {
            currentcontroller.AddLicenseToInventory(cmbLicense.SelectedItem, numCount.Value);
        }

        private void dgvLicense_SelectionChanged(Object sender, EventArgs e)
        {
            dgvLicense.ClearSelection();
        }
    }
}
