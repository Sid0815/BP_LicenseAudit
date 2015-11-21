using System;
using System.Collections;
using System.Windows.Forms;
using BP_LicenseAudit.Model;
using BP_LicenseAudit.View;

namespace BP_LicenseAudit.Controller
{
    public class ControllerCustomer : ControllerParent
    {
        private FormCustomer view;
        private ArrayList list_customers;

        //Constructor
        public ControllerCustomer(FormCustomer view)
        {
            //connect controller to its view
            this.view = view;
        }

        //Functions
        public void AddCustomer()
        {

        }

        public void UpdateCustomer()
        {

        }

        public void RemoveCustomer()
        {

        }

        public object SearchCustomer()
        {
            Customer foundCustomer = new Customer(-1);
            return foundCustomer;
        }
    }
}
