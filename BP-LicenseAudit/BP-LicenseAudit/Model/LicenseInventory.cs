using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_LicenseAudit.Model
{
    class LicenseInventory : Inventory
    {
        //properties
        private int licenseInventoryNumber;
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
        private object inventory;
        public object Inventory
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
            inventory = null;
        }

        //functions
        public void SearchInventory()
        {

        }

        public void AddLicenseToInventory(int licenseNumer, int count)
        {

        }

        public void GetLicenseInventoryFromDB()
        {

        }

        public void SaveLicenseInventoryToDB()
        {
        
        }
    }
}
