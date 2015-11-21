using System;
using BP_LicenseAudit.Controller;

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
    }
}
