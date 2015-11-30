using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_LicenseAudit.Model
{
    public class LicenseInventory : Inventory
    {
        private int licenseInventoryNumber;
        private ArrayList inventory;

        //properties        
        public int LicenseInventoryNumber
        {
            get
            {
                return licenseInventoryNumber;
            }
            private set
            {
                licenseInventoryNumber = value;
            }
        }
        
        //List of Tuples<Licensenumber,Count>
        public ArrayList Inventory
        {
            get
            {
                return inventory;
            }
            private set
            {
                inventory = value;
            }
        }

        //constructor
        public LicenseInventory(int customerNumber, int number):base(customerNumber)
        {
            licenseInventoryNumber = number;
            inventory = new ArrayList();
        }

        //functions
        public void SearchInventory()
        {

        }

        public void AddLicenseToInventory(int licenseNumer, int count)
        {
            Tuple<int, int> currentlicense = new Tuple<int, int>(licenseNumer, count);
            Console.WriteLine("Added License to inventory: {0}", currentlicense);
            inventory.Add(currentlicense);
        }

        public void RemoveLicenseFromInventory(int licenseNumber)
        {
            Tuple<int, int> help = new Tuple<int, int>(-1, -1);
            foreach(Tuple<int, int> t in Inventory)
            {
                if(t.Item1 == licenseNumber)
                {
                    help = t;
                }
            }
            inventory.Remove(help);
        }

        public void GetLicenseInventoryFromDB()
        {

        }

        public void SaveLicenseInventoryToDB()
        {
        
        }
    }
}
