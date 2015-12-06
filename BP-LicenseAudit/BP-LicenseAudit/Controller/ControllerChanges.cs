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
        private ArrayList list_networks;
        private ArrayList list_networkinventories;
        private ArrayList list_networkInventories;

        //constrctor
        public ControllerChanges(ControllerParent calling, FormChange view, ArrayList list_customers, ArrayList list_networks, ArrayList list_networkinventories, ArrayList list_licenseInventories) :base(calling)
        {
            //connect controller to its view
            this.view = view;
            this.list_customers = list_customers;
            this.list_networks = list_networks;
            this.list_networkinventories = list_networkinventories;
            this.list_networkInventories = list_licenseInventories;
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

        public override void UpdateView(bool customerUpdated)
        {
            //Customer
            if (customerUpdated)
            {
                view.ClearCustomers();
                foreach (Customer c in list_customers)
                {
                    view.AddCustomer(c);
                }
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

        public override void SelectedCustomerChanged(Object customer)
        {
            base.SelectedCustomerChanged(customer);
            currentLicenseInventory = null;
            currentNetworkInventory = null;
            Console.WriteLine("Customer changed successfully: New Customer: {0}", currentCustomer.Name);
            //Get Licenseinventory of the customer
            foreach (LicenseInventory li in list_networkInventories)
            {
                if (li.Customernumber == currentCustomer.Cnumber)
                {
                    currentLicenseInventory = li;
                    Console.WriteLine("Licenseinventory for customer {0} found", currentCustomer.Name);
                }
            }
            if (currentLicenseInventory == null)
            {
                MessageBox.Show("Kein Lizenzinventar für diesen Kunden gefunden.", "Kein Lizenzinventar gefunden", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            //Get Networkinventory of the customer
            foreach (NetworkInventory ni in list_networkInventories)
            {
                if (ni.Customernumber == currentCustomer.Cnumber)
                {
                    currentNetworkInventory = ni;
                    Console.WriteLine("Networkinventory for customer {0} found", currentCustomer.Name);
                }
            }
            if (currentNetworkInventory == null)
            {
                MessageBox.Show("Kein Netzwerkinventar für diesen Kunden gefunden.", "Kein Netzwerkinventar gefunden", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


            UpdateView(false);
        }
    }
}
