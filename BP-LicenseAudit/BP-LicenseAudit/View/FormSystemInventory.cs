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
            currentcontroller.LstNetworksSelected(lstNetworks.SelectedItems);
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

        public void ClearClientSystems()
        {
            lstClients.Items.Clear();
        }

        public void AddClientSystem(ClientSystem c)
        {
            lstClients.Items.Add(c);
        }

        private void lstClients_SelectedIndexChanged(Object sender, EventArgs e)
        {
            currentcontroller.ClientSelected(lstClients.SelectedItem);
        }

        public void ClearClientDetails()
        {
            lstDetails.Items.Clear();
        }

        public void UpdateClientDetails(string computername, string ip, string os)
        {
            lstDetails.Items.Clear();
            lstDetails.Items.Add("Computername:");
            lstDetails.Items.Add(computername);
            lstDetails.Items.Add("");
            lstDetails.Items.Add("IP-Adresse:");
            lstDetails.Items.Add(ip);
            lstDetails.Items.Add("");
            lstDetails.Items.Add("Betriebssystem:");
            lstDetails.Items.Add(os);
        }

        public System.Windows.Forms.ProgressBar GetProgressBar()
        {
            return this.progressBarSI;
        }
    }
}
