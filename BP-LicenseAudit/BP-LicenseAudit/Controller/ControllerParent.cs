using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BP_LicenseAudit.Model;
using System.Windows.Forms;

namespace BP_LicenseAudit.Controller
{
    public abstract class ControllerParent
    {
        private Customer currentCustomer;
        protected ControllerParent callingController;

        public ControllerParent (ControllerParent callingController)
        {
            this.callingController = callingController;
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

        //Update the view of the calling Controller
        public abstract void UpdateView();

        //Pass Information to the calling Controller
        public abstract void UpdateInformation();

    }
}
