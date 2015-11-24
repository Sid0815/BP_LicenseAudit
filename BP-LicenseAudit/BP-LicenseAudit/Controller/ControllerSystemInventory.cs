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
    public class ControllerSystemInventory : ControllerParent
    {
        //properties
        private FormSystemInventory view;
        private NetworkInventory currentNetworkInventory;
        private SystemInventory currentsystemInventory;
        private ClientSystem currentSystem;

        //constructor
        public ControllerSystemInventory(ControllerParent calling, FormSystemInventory view, ArrayList list_customers) :base(calling)
        {
            //connect controller to its view
            this.view = view;
            this.list_customers = list_customers;
        }
        

        //funtions
        private void scanNetwork()
        {

        }

        private void scanDetails()
        {

        }

        public void CreatesystemInventroy()
        {

        }

        public void AddSystemToInventory()
        {

        }

        public void GetSystemInventoryFromDB()
        {

        }

        public void GetNetworkInventoryFromDB()
        {

        }

        public void SaveSystemInventoryToDB()
        {

        }

        public override void UpdateView()
        {
            //Customer
            foreach (Customer c in list_customers)
            {
                view.AddCustomer(c.Name);
            }

        }

        public override void UpdateInformation()
        {//Updates all neccesary properties of the controller (could be caled by a controller who self was caled by this)
        }

    }
}
