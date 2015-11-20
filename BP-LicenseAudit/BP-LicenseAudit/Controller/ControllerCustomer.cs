using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BP_LicenseAudit.Model;

namespace BP_LicenseAudit.Controller
{
    class ControllerCustomer : ControllerParent
    {
        ArrayList list_customers;

        //Constructor
        public ControllerCustomer(Form view):base(view)
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
