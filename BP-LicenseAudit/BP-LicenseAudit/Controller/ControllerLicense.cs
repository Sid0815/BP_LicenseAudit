using System;
using System.Collections;
using BP_LicenseAudit.Model;
using BP_LicenseAudit.View;
using System.Windows.Forms;

namespace BP_LicenseAudit.Controller
{
    public class ControllerLicense : ControllerParent
    {

        private ArrayList list_licenseInventories;
        private ArrayList list_allAvailableLicenses;
        private LicenseInventory currentLicenseInventory;
        private FormLicense view;

        //constructor
        public ControllerLicense(ControllerParent calling, FormLicense view, ArrayList list_customers, ArrayList list_licenses, ArrayList list_licenseInventories) : base(calling, list_customers)
        {
            //connect controller to its view
            this.view = view;
            this.list_allAvailableLicenses = list_licenses;
            this.list_licenseInventories = list_licenseInventories;

        }

        //functions
        public void AddLicenseToInventory(Object license, decimal count)
        {
            //Check if all values are available
            License l = (License)license;
            if (currentCustomer == null)
            {
                MessageBox.Show("Bitte einen Kunden auswählen und Lizenz erneut hinzufügen.", "Kein Kunde ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (license == null)
            {
                MessageBox.Show("Bitte einen Lizenztyp auswählen und Lizenz erneut hinzufügen.", "Kein Lizenztyp ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
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
                            dr = MessageBox.Show(String.Format("Lizenz bereits im Inventar vorhanden. Soll die Lizenz von {0} auf {1} aktualisiert werden.", t.Item2, count), "Lizenz aktualisiert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                    }
                }
                //License doubled and update yes --> remove old status
                if (dr == DialogResult.Yes && !(x == -1))
                {
                    currentLicenseInventory.RemoveLicenseFromInventory(l.LicenseNumber);
                }
                //License doubled and update false --> exit
                else if (dr == DialogResult.No && !(x == -1))
                {
                    return;
                }
                //Add license to inventory (new license or updated status after removing old one)
                currentLicenseInventory.AddLicenseToInventory(l.LicenseNumber, (int)count);
            }
            UpdateView(false);
            callingController.UpdateInformation();
            db.UpdateLicenseInventory(currentLicenseInventory, l, (int)count);
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
            //License Types (only updated if a the number of diplayed types and the number of types is different)
            if (!(list_allAvailableLicenses.Count == view.CountLicenseTypes()))
            {
                Log.WriteLog("ViewUpdate Licensetypes");
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


        }

        public override void UpdateInformation()
        {//Updates all neccesary properties of the controller (could be caled by a controller who self was caled by this)
        }

        //Called if Customer in DropDown Menu is changed, check if a NetworkInventory exist, get it or create a new one and update the view
        public override void SelectedCustomerChanged(Object customer)
        {
            base.SelectedCustomerChanged(customer);
            currentLicenseInventory = null;
            Log.WriteLog(string.Format("Customer changed successfully: New Customer: {0}", currentCustomer.Name));
            //Get Licenseinventory of the customer or create a new one
            foreach (LicenseInventory li in list_licenseInventories)
            {
                if (li.Customernumber == currentCustomer.Cnumber)
                {
                    currentLicenseInventory = li;
                    Log.WriteLog(string.Format("Licenseinventory for customer {0} found", currentCustomer.Name));
                }
            }
            if (currentLicenseInventory == null)
            {
                currentLicenseInventory = CreateLicenseInventory(currentCustomer.Cnumber);
                Log.WriteLog("new inventory created");
            }
            UpdateView(false);
        }

        //Create a new Licenseinventory
        public LicenseInventory CreateLicenseInventory(int customerNumber)
        {
            currentLicenseInventory = new LicenseInventory(customerNumber, list_licenseInventories.Count);
            list_licenseInventories.Add(currentLicenseInventory);
            db.SaveLicenseInventory(currentLicenseInventory);
            return currentLicenseInventory;
        }

    }
}
