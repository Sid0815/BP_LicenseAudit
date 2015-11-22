using BP_LicenseAudit.Controller;

namespace BP_LicenseAudit.View
{
    public partial class FormCustomer : FormParent
    {
        private ControllerCustomer currentcontroller;
        public ControllerCustomer Currentcontroller
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
        public FormCustomer()
        {
            InitializeComponent();
        }

        public void UpdateCustomerNumber(string nr)
        {
            lblCNrShow.Text = nr;
        }

        public string GetCustomerName()
        {
            return txtCName.Text;
        }

        public string GetCustomerStreet()
        {
            return txtCStreet.Text;
        }

        public string GetCustomerStreetNr()
        {
            return txtCStreetNr.Text;
        }

        public string GetCustomerCity()
        {
            return txtCCity.Text;
        }

        public string GetCustomerZIP()
        {
            return txtCzip.Text;
        }

        private void btnSaveNext_Click(object sender, System.EventArgs e)
        {
            currentcontroller.SaveNext();
        }
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            currentcontroller.SaveEnd();
        }

        public void ClearInput()
        {
            txtCName.ResetText();
            txtCCity.ResetText();
            txtCStreet.ResetText();
            txtCStreetNr.ResetText();
            txtCzip.ResetText();
        }


    }
}
