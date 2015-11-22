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
        private ArrayList list_customers =new ArrayList();

        //constructor
        public ControllerMain(FormMain view):base(null)
        {
            //connect controller to its view
            this.view = view;

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

            //Creating Controllers and connect view to controller
            cAudit = new ControllerAudit(this, fAudit);
            cChanges = new ControllerChanges(this, fChanges);
            cCustomer = new ControllerCustomer(this, fCustomer, list_customers);
            cLicense = new ControllerLicense(this, fLicense);
            cNetwork = new ControllerNetwork(this, fNetwork);
            cSystemInventory = new ControllerSystemInventory(this, fSystemInventory);

            //Connect Controller to View
            fAudit.Currentcontroller = cAudit;
            fChanges.Currentcontroller = cChanges;
            fCustomer.Currentcontroller = cCustomer;
            fLicense.Currentcontroller = cLicense;
            fNetwork.Currentcontroller = cNetwork;
            fSystemInventory.Currentcontroller = cSystemInventory;

            //TODO: initialising by database


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
                    fAudit.ShowDialog();
                    break;
                case "Changes":
                    fChanges.ShowDialog();
                    break;
                case "Customer":
                    cCustomer.UpdateView();
                    fCustomer.ShowDialog();
                    break;
                case "License":
                    fLicense.ShowDialog();
                    break;
                case "Network":
                    fNetwork.ShowDialog();
                    break;
                case "SystemInventory":
                    fSystemInventory.ShowDialog();
                    break;
                default:
                    Console.WriteLine("No proper Formsubmitted");
                    break;
            }
        }

        public override void UpdateView()
        {
            //Customer
            view.ClearCustomerList();
            foreach(Customer c in list_customers)
            {
                view.AddCustomer(c.Name);
            }
        }

        public override void UpdateInformation()
        {
            
        }
    }
}
