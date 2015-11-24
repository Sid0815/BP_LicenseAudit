using System;
using BP_LicenseAudit.Controller;

namespace BP_LicenseAudit.View
{
    public partial class FormNetwork : FormParent
    {
        private ControllerNetwork currentcontroller;
        public ControllerNetwork Currentcontroller
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
        public FormNetwork()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void AddCustomer(string customer)
        {
            cmbCustomer.Items.Add(customer);
        }
    }
}
