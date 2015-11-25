using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_LicenseAudit.Model
{
    class SystemInventory : Inventory
    {
        //properties
        private int systemInventoryNumber;
        public int SystemInventoryNumber
        {
            get
            {
                return systemInventoryNumber;
            }
            private set
            {
                systemInventoryNumber = value;
            }
        }

        private ArrayList list_systems;

        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        //constructor
        public SystemInventory(int customernumber, int number):base(customernumber)
        {
            systemInventoryNumber = number;
            list_systems = new ArrayList();
            date = DateTime.Now;
        }

        //functions

        public void SearchClientSystem()
        {

        }

        public void CountSameTypes()
        {

        }


    }
}
