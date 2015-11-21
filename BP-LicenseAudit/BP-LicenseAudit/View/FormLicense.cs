using System;
using BP_LicenseAudit.Controller;

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

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
