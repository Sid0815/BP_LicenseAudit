using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BP_LicenseAudit.Controller;

namespace BP_LicenseAudit.Model
{
    class NetworkInventory : Inventory
    {
        //properties
        private int networkInventoryNumber;
        public int NetworkInventoryNumber
        {
            get
            {
                return networkInventoryNumber;
            }
            private set
            {
                networkInventoryNumber = value;
            }
        }
        private ArrayList list_networks;
        public ArrayList List_networks
        {
            get
            {
                return list_networks;
            }
            set
            {
                list_networks = value;
            }
        }

        //constructor
        public NetworkInventory(int number)
        {
            networkInventoryNumber = number;
            list_networks =  new ArrayList();
        }

        //functions
        public void AddNetwork(Network toAddingNetwork)
        {
            list_networks.Add(toAddingNetwork);
        }
    }
}
