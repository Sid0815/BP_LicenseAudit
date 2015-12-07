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
        private ArrayList list_networkInventories;
        private ArrayList list_licenseInventories;
        private ArrayList list_allAvailableLicenses;

        //constrctor
        public ControllerChanges(ControllerParent calling, FormChange view, ArrayList list_customers, ArrayList list_networks, ArrayList list_networkinventories, ArrayList list_licenseInventories, ArrayList list_allAvailableLicenses) : base(calling)
        {
            //connect controller to its view
            this.view = view;
            this.list_customers = list_customers;
            this.list_networks = list_networks;
            this.list_networkInventories = list_networkinventories;
            this.list_licenseInventories = list_licenseInventories;
            this.list_allAvailableLicenses = list_allAvailableLicenses;
        }

        //functions
        public void SelectedLicenseChanged(string license, string count)
        {
            selectedlicense = null;
            int c = 0;
            try
            {
                c = int.Parse(count);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error parsing int");
            }
            foreach (License l in list_allAvailableLicenses)
            {
                if (l.Name.Equals(license))
                {
                    selectedlicense = l;
                }
            }
            if (selectedlicense != null)
            {
                view.UpdateLicense(selectedlicense, c);
            }



        }

        public void SelectedNetworkChanged()
        {

        }

        public void UpdateLicenseInventory(Object license, decimal count)
        {
            License l = (License)license;
            //Check if Licensetype is already in Licenseinventory
            int x = -1;
            DialogResult dr = DialogResult.No;
            foreach (Tuple<int, int> t in currentLicenseInventory.Inventory)
            {
                if (t.Item1 == l.LicenseNumber)
                {   //Get Index of license, in the loop deleting is not possible
                    x = currentLicenseInventory.Inventory.IndexOf(t);
                    //If the new count is the same as already in the inventory
                    if (t.Item2 == count)
                    {
                        MessageBox.Show("Lizenz bereits im Inventar vorhanden. Es wurden keine Daten geändert.", "Lizenz bereits vorhanden", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dr = MessageBox.Show(String.Format("Soll die Lizenz von {0} auf {1} aktualisiert werden.", t.Item2, count), "Lizenz aktualisiert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                }
            }
            //License doubled and update yes --> remove old status
            if (dr == DialogResult.Yes && (x != -1))
            {
                currentLicenseInventory.RemoveLicenseFromInventory(l.LicenseNumber);
            }
            //License doubled and update false --> exit
            else if (dr == DialogResult.No && (x != -1))
            {
                return;
            }
            //Add license to inventory (new license or updated status after removing old one)
            currentLicenseInventory.AddLicenseToInventory(l.LicenseNumber, (int)count);
            callingController.UpdateInformation();
            db.SaveLicenseInventories(list_licenseInventories);
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
            UpdateCustomerView();
            //License Types (only updated if a the number of diplayed types and the number of types is different)
            if (!(list_allAvailableLicenses.Count == view.CountLicenseTypes()))
            {
                Console.WriteLine("ViewUpdate Licensetypes");
                view.ClearLicenseTypes();
                foreach (License l in list_allAvailableLicenses)
                {
                    view.AddLicenseType(l);
                }
            }
            //LicenseInventory
            view.ClearLicenses();
            if (currentLicenseInventory != null)
            {
                foreach (Tuple<int, int> t in currentLicenseInventory.Inventory)
                {
                    int licensenumber = t.Item1;
                    int count = t.Item2;
                    foreach (License l in list_allAvailableLicenses)
                    {
                        if (l.LicenseNumber == licensenumber)
                        {
                            view.AddLicense(l.Name, count);
                        }
                    }

                }

            }
            //Networks
            view.ClearNetworks();
            if (currentNetworkInventory != null && currentNetworkInventory.List_networks.Count > 0)
            {
                foreach (Network n in currentNetworkInventory.List_networks)
                {
                    view.AddNetwork(n);
                }
            }


        }

        public override void UpdateInformation()
        {

        }

        //Fills textboxes with selected customer data
        public void UpdateCustomerView()
        {
            view.ClearCustomer();
            if (currentCustomer != null)
            {
                view.UpdateCustomer(currentCustomer.Name, currentCustomer.City, currentCustomer.Zip, currentCustomer.Street, currentCustomer.Streetnumber);
            }
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
            foreach (LicenseInventory li in list_licenseInventories)
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
