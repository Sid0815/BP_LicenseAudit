using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BP_LicenseAudit.Model;
using System.Windows.Forms;

namespace BP_LicenseAudit.Controller
{
    public class ControllerParent
    {
        private Customer currentCustomer;

        public ControllerParent ()
        {
        }


        public void SelectedCustomerChanged(String name)
        {
            //chnage the selected customer and update

        }

        public void GetCustomerFromMainForm()
        {
            //passes the selected customer from main form
        }

        public void GetAllCustomersFromDB()
        {
            //Query all customers from database
        }

    }
}
