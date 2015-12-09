using System.Collections;


namespace BP_LicenseAudit.Model
{
    public class NetworkInventory : Inventory
    {
        private int networkInventoryNumber;
        private ArrayList list_networks;

        //properties

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
        public NetworkInventory(int customerNumber, int niNumber, ArrayList networks) : base(customerNumber)
        {
            this.networkInventoryNumber = niNumber;
            this.list_networks = networks;
        }

        //functions
        public void AddNetwork(Network toAddingNetwork)
        {
            list_networks.Add(toAddingNetwork);
        }
    }
}
