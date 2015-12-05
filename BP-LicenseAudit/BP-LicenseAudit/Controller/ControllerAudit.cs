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
        private SystemInventory currentSystemInventory;
        private LicenseInventory currentLicenseInventory;
        private Audit currentAudit;
        private ArrayList list_licenseInventories;
        private ArrayList list_systemInventories;
        private ArrayList list_audits;
        private ArrayList list_allAvailableLicenses;

        //constructor
        public ControllerAudit(ControllerParent calling, FormAudit view, ArrayList list_customers, ArrayList list_licenseinventories, ArrayList list_systeminventories, ArrayList list_audits, ArrayList list_licenses) :base(calling)
        {
            //connect controller to its view
            this.view = view;
            this.list_customers = list_customers;
            this.list_licenseInventories = list_licenseinventories;
            this.list_systemInventories = list_systeminventories;
            this.list_audits = list_audits;
            this.list_allAvailableLicenses = list_licenses;
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
            //SystemInventory
            view.ClearSystemInventory();
            if(currentSystemInventory != null)
            {
                view.AddSystemInventory(string.Format("Inventarisierung {0}", currentSystemInventory.Date));
                foreach (ClientSystem c in currentSystemInventory.List_Systems)
                {
                    if (c.Type != null && !(c.Type.Equals("")))
                    {
                        view.AddClientSystem(c);
                    }
                }
            }

        }

        public override void UpdateInformation()
        {

        }

        public override void SelectedCustomerChanged(Object customer)
        {
            base.SelectedCustomerChanged(customer);
            currentLicenseInventory = null;
            currentSystemInventory = null;
            Console.WriteLine("Customer changed successfully: New Customer: {0}", currentCustomer.Name);
            //Get Licenseinventory of the customer or Display Message
            foreach (LicenseInventory li in list_licenseInventories)
            {
                if (li.Customernumber == currentCustomer.Cnumber)
                {
                    currentLicenseInventory = li;
                    Console.WriteLine("Licenseinventory for customer {0} found", currentCustomer.Name);
                    view.EnableAudit();
                }
            }
            if (currentLicenseInventory == null)
            {
                MessageBox.Show("Kein Lizenzinventar für diesen Kunden gefunden. Bitte erstellen Sie zuerst ein Lizenzinventar.", "Kein Lizenzinventar gefunden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                view.DisableAudit();
            }
            //Get Systeminventory of the customer or Display Message
            foreach (SystemInventory si in list_systemInventories)
            {
                if (si.Customernumber == currentCustomer.Cnumber)
                {
                    currentSystemInventory = si;
                    Console.WriteLine("Systeminventory for customer {0} found", currentCustomer.Name);
                    view.EnableAudit();
                }
            }
            if (currentSystemInventory == null)
            {
                MessageBox.Show("Kein Systeminventar für diesen Kunden gefunden. Bitte führen Sie zuerst ein Netzwerkinventarisierung durch.", "Kein Systeminventar gefunden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                view.DisableAudit();
            }
            UpdateView(false);
        }

    }
}
