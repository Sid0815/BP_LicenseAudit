using System;
using BP_LicenseAudit.Controller;
using BP_LicenseAudit.Model;

namespace BP_LicenseAudit.View
{
    public partial class FormSystemInventory : FormParent
    {
        private ControllerSystemInventory currentcontroller;
        public ControllerSystemInventory Currentcontroller
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
        public FormSystemInventory()
        {
            InitializeComponent();
        }

        private void FormInventary_Load(object sender, EventArgs e)
        {

        }

        private void btnInventory_Click(Object sender, EventArgs e)
        {
            currentcontroller.Inventory(lstNetworks.SelectedItems);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedItem != null) currentcontroller.SelectedCustomerChanged(cmbCustomer.SelectedItem);
        }

        public void AddNetwork(Network network)
        {
            lstNetworks.Items.Add(network);
        }

        public void ClearNetworks()
        {
            lstNetworks.Items.Clear();
        }

        private void lstNetworks_SelectedIndexChanged(Object sender, EventArgs e)
        {
            currentcontroller.lstNetworksSelected(lstNetworks.SelectedItems);
        }

        //selects item if state is true or unselects item if state is false
        public void lstNetworks_selectItem(int index, bool state)
        {
            if (state)
            {
                lstNetworks.SetSelected(index, true);
            }
            else
            {
                lstNetworks.SetSelected(index, false);
            }

        }

        private void chkAll_CheckedChanged(Object sender, EventArgs e)
        {
            currentcontroller.chkAll_Changed();
        }

        public bool chkAll_State()
        {
            return chkAll.Checked;
        }

        public void SetChkAll(bool state)
        {
            chkAll.Checked = state;
        }
    }
}
