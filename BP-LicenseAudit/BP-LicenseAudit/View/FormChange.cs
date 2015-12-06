using System;
using BP_LicenseAudit.Controller;

namespace BP_LicenseAudit.View
{
    public partial class FormChange : FormParent
    {
        private ControllerChanges currentcontroller;
        public ControllerChanges Currentcontroller
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
        public FormChange()
        {
            InitializeComponent();
        }

        private void FormChange_Load(object sender, EventArgs e)
        {

        }

        private void dgvLicense_SelectionChanged(Object sender, EventArgs e)
        {
            //dgvLicense.ClearSelection();
        }
    }
}
