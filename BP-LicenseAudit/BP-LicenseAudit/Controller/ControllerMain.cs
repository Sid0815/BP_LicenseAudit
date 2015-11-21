using System.Windows.Forms;
using BP_LicenseAudit.View;
using System;

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

        //constructor
        public ControllerMain(FormMain view)
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

            //Creating Controllers and connect to corresponding view
            cAudit = new ControllerAudit(fAudit);
            cChanges = new ControllerChanges(fChanges);
            cCustomer = new ControllerCustomer(fCustomer);
            cLicense = new ControllerLicense(fLicense);
            cNetwork = new ControllerNetwork(fNetwork);
            cSystemInventory = new ControllerSystemInventory(fSystemInventory);

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
    }
}
