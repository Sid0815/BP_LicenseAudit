using System.Windows.Forms;
using BP_LicenseAudit.View;
using BP_LicenseAudit.Model;
using System;
using System.Collections;

namespace BP_LicenseAudit.Controller
{
    public class ControllerMain : ControllerParent
    {
        private FormMain view;
        private FormAudit fAudit;
        private FormChange fChanges;
        private FormCustomer fCustomer;
        private FormLicense fLicense;
        private FormNetwork fNetwork;
        private FormSystemInventory fSystemInventory;
        private ControllerAudit cAudit;
        private ControllerChanges cChanges;
        private ControllerCustomer cCustomer;
        private ControllerLicense cLicense;
        private ControllerNetwork cNetwork;
        private ControllerSystemInventory cSystemInventory;
        private ArrayList list_networks;
        private ArrayList list_networkInventories;
        private NetworkInventory currentNetworkInventory;
        private ArrayList list_licenses;
        private ArrayList list_licenseInventories;

        //constructor
        public ControllerMain(FormMain view):base(null)
        {
            //connect controller to its view
            this.view = view;

            list_networks = new ArrayList();
            list_networkInventories = new ArrayList();
            list_licenses = new ArrayList();
            list_licenseInventories = new ArrayList();

            //initialising by database
            list_customers = db.GetCustomers();
            //list_networks =db.GetNeetworks();
            //list_networkInventories = db.GetNetworkInventoriers();
            list_licenses = db.GetLicenses();
            //list_licenseInventoriers = db.GetLicenseInventoriers();

            //Creating Forms
            fAudit = new FormAudit();
            fChanges = new FormChange();
            fCustomer = new FormCustomer();
            fLicense = new FormLicense();
            fNetwork = new FormNetwork();
            fSystemInventory = new FormSystemInventory();
            fAudit.Visible = false;
            fChanges.Visible = false;
            fCustomer.Visible = false;
            fLicense.Visible = false;
            fNetwork.Visible = false;
            fSystemInventory.Visible = false;

            //Creating Controllers and connect data
            cAudit = new ControllerAudit(this, fAudit, list_customers);
            cChanges = new ControllerChanges(this, fChanges, list_customers);
            cCustomer = new ControllerCustomer(this, fCustomer, list_customers);
            cLicense = new ControllerLicense(this, fLicense, list_customers, list_licenses, list_licenseInventories);
            cNetwork = new ControllerNetwork(this, fNetwork, list_customers, list_networks, list_networkInventories);
            cSystemInventory = new ControllerSystemInventory(this, fSystemInventory, list_customers);

            //Connect Controller to View
            fAudit.Currentcontroller = cAudit;
            fChanges.Currentcontroller = cChanges;
            fCustomer.Currentcontroller = cCustomer;
            fLicense.Currentcontroller = cLicense;
            fNetwork.Currentcontroller = cNetwork;
            fSystemInventory.Currentcontroller = cSystemInventory;

            //Update View with Information initialised by Database
            UpdateView(true);

        }
        

        //functions
        public void CollectInformation()
        {

        }

        public void ConnectToDatabase()
        {

        }

        public void OpenForm(string view)
        {
            switch (view)
            {
                case "Audit":
                    cAudit.UpdateView(true);
                    fAudit.ShowDialog();
                    break;
                case "Changes":
                    cChanges.UpdateView(true);
                    fChanges.ShowDialog();
                    break;
                case "Customer":
                    cCustomer.UpdateView(true);
                    fCustomer.ShowDialog();
                    break;
                case "License":
                    cLicense.UpdateView(true);
                    fLicense.ShowDialog();
                    break;
                case "Network":
                    cNetwork.UpdateView(true);
                    fNetwork.ShowDialog();
                    break;
                case "SystemInventory":
                    cSystemInventory.UpdateView(true);
                    fSystemInventory.ShowDialog();
                    break;
                default:
                    Console.WriteLine("No proper Formsubmitted");
                    break;
            }
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
            //Network
            view.ClearNetworks();
            if (currentNetworkInventory != null)
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

        public override void SelectedCustomerChanged(Object customer)
        {
            base.SelectedCustomerChanged(customer);
            Console.WriteLine("Customer changed successfully: New Customer: {0}", currentCustomer.Name);
            currentNetworkInventory = null;
            //Get Networkinventor of the customer
            foreach (NetworkInventory n in list_networkInventories)
            {
                if (n.Customernumber == currentCustomer.Cnumber)
                {
                    currentNetworkInventory = n;
                    Console.WriteLine("NetworkInventory for customer {0} found", currentCustomer.Name);
                }
            }
            UpdateView(false);


        }
    }
}
