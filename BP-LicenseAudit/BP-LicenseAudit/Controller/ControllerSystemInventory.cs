using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BP_LicenseAudit.Model;
using System.Windows.Forms;

namespace BP_LicenseAudit.Controller
{
    class ControllerSystemInventory : ControllerParent
    {
        //properties
        private NetworkInventory currentNetworkInventory;
        private SystemInventory currentsystemInventory;
        private ClientSystem currentSystem;

        //constructor
        public ControllerSystemInventory(Form view) : base(view)
        { }
        

        //funtions
        private void scanNetwork()
        {

        }

        private void scanDetails()
        {

        }

        public void CreatesystemInventroy()
        {

        }

        public void AddSystemToInventory()
        {

        }

        public void GetSystemInventoryFromDB()
        {

        }

        public void GetNetworkInventoryFromDB()
        {

        }

        public void SaveSystemInventoryToDB()
        {

        }
    }
}
