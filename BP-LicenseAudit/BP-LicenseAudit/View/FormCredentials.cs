using BP_LicenseAudit.Controller;
using System;
using System.Windows.Forms;

namespace BP_LicenseAudit.View
{
    public partial class FormCredentials : Form
    {
        private ControllerSystemInventory currentcontroller;

        public FormCredentials(ControllerSystemInventory currentcontroller)
        {
            InitializeComponent();
            this.currentcontroller = currentcontroller;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            currentcontroller.SetCredentials(txtUsername.Text, txtPassword.Text);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
