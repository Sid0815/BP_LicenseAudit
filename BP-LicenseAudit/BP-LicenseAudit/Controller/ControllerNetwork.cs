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
    public class ControllerNetwork : ControllerParent
    {
        private FormNetwork view;
        private NetworkInventory currentNetworkInventory;
        private Network currentNetwork;

        //constructor
        public ControllerNetwork(FormNetwork view)
        {
            //connect controller to its view
            this.view = view;
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

        public override void UpdateView()
        {

        }
    }
}
