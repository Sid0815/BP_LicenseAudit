using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_LicenseAudit.Model
{
    public class SystemInventory : Inventory
    {
        private int systemInventoryNumber;
        private ArrayList list_systems;
        private DateTime date;

        //properties
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

        public ArrayList List_Systems
        {
            get
            {
                return list_systems;
            }
            private set
            {
                list_systems = value;
            }
        }

        
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
        public SystemInventory(int customernumber, int number) : base(customernumber)
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

        public void AddSystemToInventory(ClientSystem sys)
        {
            list_systems.Add(sys);
        }


    }
}
