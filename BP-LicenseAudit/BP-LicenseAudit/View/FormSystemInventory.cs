using System;
using BP_LicenseAudit.Controller;

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

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
