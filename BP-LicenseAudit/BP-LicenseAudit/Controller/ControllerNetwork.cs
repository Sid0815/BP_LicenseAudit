using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BP_LicenseAudit.Model;
using System.Windows.Forms;

namespace BP_LicenseAudit.Controller
{
    class ControllerNetwork : ControllerParent
    {
        private NetworkInventory currentNetworkInventory;
        private Network currentNetwork;

        //constructor
        public ControllerNetwork(Form view) : base(view)
        {

        }

        //functions
        private void calcAddresses()
        {

        }

        public void CreateNetworkInventory()
        {

        }

        public void AddNetworkToInventory()
        {

        }

        public void GetNotworkInventoryFromDB()
        {
            //set currentNI wirh customers NI from DB
        }

        public void SaveNetworkInventoryToDB()
        {
            //save currentNI to DB
        }
    }
}
