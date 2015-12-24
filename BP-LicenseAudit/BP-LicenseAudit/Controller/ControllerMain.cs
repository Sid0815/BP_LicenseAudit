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
        private ArrayList list_allAvailableLicenses;
        private ArrayList list_licenseInventories;
        private LicenseInventory currentLicenseInventory;
        private ArrayList list_systems;
        private ArrayList list_systemInventories;
        private SystemInventory currentSystemInventory;
        private ArrayList list_Audits;
        private Audit currentAudit;

        //constructor
        public ControllerMain(FormMain view) : base(null, null)
        {
            //connect controller to its view
            this.view = view;
            list_customers = new ArrayList();
            list_networks = new ArrayList();
            list_networkInventories = new ArrayList();
            list_allAvailableLicenses = new ArrayList();
            list_licenseInventories = new ArrayList();
            list_systems = new ArrayList();
            list_systemInventories = new ArrayList();
            list_Audits = new ArrayList();

            //initialising by database
            list_customers = db.GetCustomers();
            list_allAvailableLicenses = db.GetLicenses();
            list_networks = db.GetNetworks();
            list_networkInventories = db.GetNetworkInventories();
            list_licenseInventories = db.GetLicenseInventories();
            list_systems = db.GetClientSystems();
            list_systemInventories = db.GetSystemInventories();
            list_Audits = db.GetAudits();

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
            cAudit = new ControllerAudit(this, fAudit, list_customers, list_licenseInventories, list_systemInventories, list_Audits, list_allAvailableLicenses);
            cChanges = new ControllerChanges(this, fChanges, list_customers, list_networks, list_networkInventories, list_licenseInventories, list_allAvailableLicenses);
            cCustomer = new ControllerCustomer(this, fCustomer, list_customers);
            cLicense = new ControllerLicense(this, fLicense, list_customers, list_allAvailableLicenses, list_licenseInventories);
            cNetwork = new ControllerNetwork(this, fNetwork, list_customers, list_networks, list_networkInventories);
            cSystemInventory = new ControllerSystemInventory(this, fSystemInventory, list_customers, list_networks,
                                                             list_networkInventories, list_systems, list_systemInventories, list_allAvailableLicenses);

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
                    Log.WriteLog("No proper Formsubmitted");
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
            //NetworkInventory (if customer has one)
            view.ClearNetworks();
            if (currentNetworkInventory != null)
            {
                foreach (Network n in currentNetworkInventory.List_networks)
                {
                    view.AddNetwork(n);
                }
            }
            //LicenseInventory (if customer has one)
            view.ClearLicenses();
            if (currentLicenseInventory != null)
            {
                //Get for each License in the Inventory the Licensename and add a row to the data grid view
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
            //Actions
            view.ClearActions();
            if (currentSystemInventory != null)
            {
                view.AddAction(string.Format("Inventarisierung {0}", currentSystemInventory.Date));
            }
            if (currentAudit != null)
            {
                view.AddAction(string.Format("Audit {0}", currentAudit.Date));
            }

        }

        public override void UpdateInformation()
        {   //Updates the view only if a customer is selected
            if (currentCustomer != null)
            {
                view.lstCustomer_SelectedIndexChanged(new object(), new EventArgs());
            }

        }

        public override void SelectedCustomerChanged(Object customer)
        {
            base.SelectedCustomerChanged(customer);
            Log.WriteLog(string.Format("Customer changed successfully: New Customer: {0}", currentCustomer.Name));

            //Get Networkinventory of the customer
            currentNetworkInventory = null;
            foreach (NetworkInventory n in list_networkInventories)
            {
                if (n.Customernumber == currentCustomer.Cnumber)
                {
                    currentNetworkInventory = n;
                    Log.WriteLog(string.Format("NetworkInventory for customer {0} found", currentCustomer.Name));
                }
            }

            //Get LicenseInventory of the customer
            currentLicenseInventory = null;
            foreach (LicenseInventory li in list_licenseInventories)
            {
                if (li.Customernumber == currentCustomer.Cnumber)
                {
                    currentLicenseInventory = li;
                    Log.WriteLog(string.Format("LicenseInventory for customer {0} found", currentCustomer.Name));
                }
            }

            //Get latest SystemInventory of the customer
            currentSystemInventory = null;
            foreach (SystemInventory si in list_systemInventories)
            {
                if (si.Customernumber == currentCustomer.Cnumber)
                {
                    currentSystemInventory = si;
                    Log.WriteLog(string.Format("SystemInventory for customer {0} found", currentCustomer.Name));
                }
            }

            //Get latest Audit of the customer
            currentAudit = null;
            foreach (Audit a in list_Audits)
            {
                if (a.CustomerNumber == currentCustomer.Cnumber)
                {
                    currentAudit = a;
                    Log.WriteLog(string.Format("Audit for customer {0} found", currentCustomer.Name));
                }
            }
            UpdateView(false);


        }
    }
}
