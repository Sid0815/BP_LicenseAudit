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
    }
}
