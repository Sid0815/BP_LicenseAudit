using System;
using BP_LicenseAudit.Model;
using BP_LicenseAudit.View;
using System.Collections;

namespace BP_LicenseAudit.Controller
{
    public abstract class ControllerParent
    {
        protected Customer currentCustomer;
        protected ControllerParent callingController;
        protected ArrayList list_customers;

        public ControllerParent (ControllerParent callingController)
        {
            this.callingController = callingController;
            this.list_customers = new ArrayList();
        }


        public virtual void SelectedCustomerChanged(Object customer)
        {
            currentCustomer = (Customer) customer;
            UpdateView(false);
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
        public abstract void UpdateView(bool customerUpdated);

        //Pass Information to the calling Controller
        public abstract void UpdateInformation();

    }
}
