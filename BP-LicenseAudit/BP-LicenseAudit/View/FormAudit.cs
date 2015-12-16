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
            cmbInventory.Text = "";
            lstClients.Items.Clear();
        }

        public void AddSystemInventory(string inventory)
        {
            cmbInventory.Items.Add(inventory);
            cmbInventory.SelectedItem = inventory;
        }

        private void cmbInventory_SelectedIndexChanged(Object sender, EventArgs e)
        {
            currentcontroller.cmbInventory_SelectedIndexChanged(cmbInventory.SelectedItem);
        }

        public void SetCmbInventorySelected(string inventory)
        {
            cmbInventory.SelectedItem= inventory;
        }


        public void AddClientSystem(ClientSystem c)
        {
            lstClients.Items.Add(c);
        }

        private void btnAudit_Click(Object sender, EventArgs e)
        {
            currentcontroller.Compare();
        }

        private void dgvResult_SelectionChanged(Object sender, EventArgs e)
        {
            dgvResult.ClearSelection();
        }

        public void ClearAudit()
        {
            dgvResult.Rows.Clear();
            dgvResult.BackgroundColor = System.Drawing.Color.White;
        }

        public void AddResult(string license, int count)
        {
            int i = dgvResult.Rows.Add();
            dgvResult.Rows[i].Cells[0].Value = license;
            dgvResult.Rows[i].Cells[1].Value = count;
            if (count < 0)
            {
                dgvResult.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
            }
            else if (count > 0)
            {
                dgvResult.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
            }
            else
            {
                dgvResult.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            currentcontroller.PrintResults();
        }
    }
}
