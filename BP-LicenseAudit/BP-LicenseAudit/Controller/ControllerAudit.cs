using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BP_LicenseAudit.Model;
using BP_LicenseAudit.View;
using System.Windows.Forms;
using System.Collections;

namespace BP_LicenseAudit.Controller
{
    public class ControllerAudit : ControllerParent
    {
        //properties
        private FormAudit view;
        private SystemInventory currentSystemInventroy;
        private LicenseInventory currentLicenseInventory;
        private Audit currentAudit;

        //constructor
        public ControllerAudit(ControllerParent calling, FormAudit view, ArrayList list_customers) :base(calling)
        {
            //connect controller to its view
            this.view = view;
            this.list_customers = list_customers;
        }

        //functions
        public void Compare()
        {

        }

        public void PrintResults()
        {

        }

        public void UpdateViewResults()
        {

        }

        public void SelectedInventoryChanged()
        {

        }

        public void SortInventories()
        {

        }

        public void GetSystemInventoryFromDB()
        {

        }

        public void GetListSystemInventories()
        {

        }

        public void saveAuditToDB()
        {

        }

        public override void UpdateView()
        {
            //Customer
            foreach (Customer c in list_customers)
            {
                view.AddCustomer(c);
            }

        }

        public override void UpdateInformation()
        {

        }

    }
}
