using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //properties
        public ArrayList List_allAvailableLicenses
        {
            get
            {
                return list_allAvailableLicenses;
            }
            set
            {
                list_allAvailableLicenses = value;
            }
        }

        //constructor
        public ControllerLicense(ControllerParent calling, FormLicense view, ArrayList list_customers, ArrayList list_licenses, ArrayList list_licenseInventories) : base(calling)
        {
            //connect controller to its view
            this.view = view;
            this.list_customers = list_customers;
            this.list_allAvailableLicenses = list_licenses;
            this.list_licenseInventories = list_licenseInventories;

        }

        //functions
        public void AddLicenseToInventory(Object license, decimal count)
        {
            License l = (License)license;
            currentLicenseInventory.AddLicenseToInventory(l.LicenseNumber, (int)count);
            UpdateView(false);
        }

        public void CreateLicenseInventory()
        {

        }

        public void GetLicenseInventoryFromDB()
        {

        }

        public void GetAllLicenseTypesFromDB()
        {

        }

        public void SaveLicenseInventoryToDB()
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
            //License Types
            view.ClearLicenseTypes();
            foreach (License l in list_allAvailableLicenses)
            {
                view.AddLicenseType(l);
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
                            view.AddLicense(l, count);
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
            Console.WriteLine("Customer changed successfully: New Customer: {0}", currentCustomer.Name);
            //Get Licenseinventory of the customer or create a new one
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
                currentLicenseInventory = CreateLicenseInventory(currentCustomer.Cnumber);
                Console.WriteLine("new inventory created");
            }
            UpdateView(false);
        }

        //Create a new Licenseinventory
        public LicenseInventory CreateLicenseInventory(int customerNumber)
        {
            currentLicenseInventory = new LicenseInventory(customerNumber, list_licenseInventories.Count);
            list_licenseInventories.Add(currentLicenseInventory);
            return currentLicenseInventory;
        }

    }
}
