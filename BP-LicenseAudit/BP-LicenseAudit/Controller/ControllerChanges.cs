﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BP_LicenseAudit.Model;
using System.Windows.Forms;

namespace BP_LicenseAudit.Controller
{
    class ControllerChanges : ControllerParent
    {
        //properties
        private NetworkInventory currentNetworkInventory;
        private Network selectedNetwork;
        private LicenseInventory currentLicenseInventory;
        private License selectedlicense;

        //constrctor
        public ControllerChanges(Form view) : base(view)
        {

        }

        //functions
        public void SelectedLicenseChanged()
        {

        }

        public void SelectedNetworkChanged()
        {

        }

        public void UpdateLicenseInventory()
        {

        }

        public void UpdateNetworkInventory()
        {

        }

        public void UpdateCustomer()
        {

        }

        public void RemoveLicense()
        {

        }

        public void RemoveNetwork()
        {

        }

        public void UpdateView()
        {

        }

        public void UpdateCustomerView()
        {

        }

        public void UpdateLicenseView()
        {

        }

        public void updateNetworkView()
        {

        }

        public void GetLicenseInventoryFromDB()
        {

        }

        public void GetAllLicenseTypesFromDB()
        {

        }

        public void GetNetworkInventoryFromDB()
        {

        }
    }
}
