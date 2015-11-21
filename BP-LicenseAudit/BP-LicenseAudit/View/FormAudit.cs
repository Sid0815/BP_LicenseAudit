using System;
using System.Windows.Forms;
using BP_LicenseAudit.Controller;

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
    }
}
