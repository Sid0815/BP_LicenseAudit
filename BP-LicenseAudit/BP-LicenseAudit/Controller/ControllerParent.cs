using System;
using BP_LicenseAudit.Model;
using System.Collections;

namespace BP_LicenseAudit.Controller
{
    public abstract class ControllerParent
    {
        protected Customer currentCustomer;
        protected ControllerParent callingController;
        protected ArrayList list_customers;
        protected Database db;

        public ControllerParent(ControllerParent callingController, ArrayList list_customers)
        {
            this.callingController = callingController;
            if (list_customers == null) this.list_customers = new ArrayList();
            else this.list_customers = list_customers;
            this.db = new Database();
            currentCustomer = null;
        }


        public virtual void SelectedCustomerChanged(Object customer)
        {
            currentCustomer = (Customer)customer;
            UpdateView(false);
        }

        //Update the view of the calling Controller
        public abstract void UpdateView(bool customerUpdated);

        //Pass Information to the calling Controller
        public abstract void UpdateInformation();

    }
}
