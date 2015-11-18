using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BP_LicenseAudit.Model;

namespace BP_LicenseAudit.Controller
{
    class ControllerCustomer : Controller
    {
        ArrayList list_customers;

        //Constructor
        public ControllerCustomer()
        {

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
