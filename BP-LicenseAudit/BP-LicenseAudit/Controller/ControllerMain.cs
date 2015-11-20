using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BP_LicenseAudit.Model;
using System.Windows.Forms;

namespace BP_LicenseAudit.Controller
{
    class ControllerMain : ControllerParent
    {
        private Form fAudit;
        private Form fChanges;
        private Form fCustomer;
        private Form fLicense;
        private Form fNetwork;
        private Form fSystemInventory;
        private ControllerAudit cAudit;
        private ControllerChanges cChanges;
        private ControllerCustomer cCustomer;
        private ControllerLicense cLicense;
        private ControllerNetwork cNetwork;
        private ControllerSystemInventory cSystemInventory;

        //constructor
        public ControllerMain(Form view):base(view)
        {
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
    }
}
