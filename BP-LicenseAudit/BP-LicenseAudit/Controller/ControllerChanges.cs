using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BP_LicenseAudit.View;
using BP_LicenseAudit.Model;
using System.Windows.Forms;
using System.Collections;

namespace BP_LicenseAudit.Controller
{
    public class ControllerChanges : ControllerParent
    {
        //properties
        private FormChange view;
        private NetworkInventory currentNetworkInventory;
        private Network selectedNetwork;
        private LicenseInventory currentLicenseInventory;
        private License selectedlicense;

        //constrctor
        public ControllerChanges(ControllerParent calling, FormChange view, ArrayList list_customers) :base(calling)
        {
            //connect controller to its view
            this.view = view;
            this.list_customers = list_customers;
        }

        //functions
        public void SelectedLicenseChanged()
        {

        }

        public void SelectedNetworkChanged()
        {

        }

        public void UpdateLicenseInventory()
        {

        }

        public void UpdateNetworkInventory()
        {

        }

        public void UpdateCustomer()
        {

        }

        public void RemoveLicense()
        {

        }

        public void RemoveNetwork()
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
        {

        }

        public void UpdateCustomerView()
        {

        }

        public void UpdateLicenseView()
        {

        }

        public void updateNetworkView()
        {

        }

        public void GetLicenseInventoryFromDB()
        {

        }

        public void GetAllLicenseTypesFromDB()
        {

        }

        public void GetNetworkInventoryFromDB()
        {

        }
    }
}
