using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BP_LicenseAudit.Model;
using System.Windows.Forms;

namespace BP_LicenseAudit.Controller
{
    class ControllerLicense : ControllerParent
    {
        //properties
        private ArrayList list_allAvailableLicenses;
        public ArrayList List_allAvailableLicenses
        {
            get
            {
                return list_allAvailableLicenses;
            }
            set
            {
                list_allAvailableLicenses = value;
            }
        }
        private LicenseInventory currentLicenseInventory;

        //constructor
        public ControllerLicense(Form view) : base(view)
        {

        }

        //functions
        public void AddLicenseToInventory()
        {

        }

        public void CreateLicenseInventory()
        {

        }

        public void GetLicenseInventoryFromDB()
        {

        }

        public void GetAllLicenseTypesFromDB()
        {

        }

        public void SaveLicenseInventoryToDB()
        {

        }
    }
}
