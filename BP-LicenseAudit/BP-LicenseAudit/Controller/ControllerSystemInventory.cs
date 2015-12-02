using System;
using BP_LicenseAudit.Model;
using BP_LicenseAudit.View;
using System.Windows.Forms;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;

namespace BP_LicenseAudit.Controller
{
    public class ControllerSystemInventory : ControllerParent
    {
        //properties
        private FormSystemInventory view;
        private NetworkInventory currentNetworkInventory;
        private SystemInventory currentSystemInventory;
        private ClientSystem currentSystem;
        private ArrayList list_networks;
        private ArrayList list_networkinventories;
        private ArrayList list_systems;
        private ArrayList list_systemInventories;
        private ArrayList selectedNetworks;

        //constructor
        public ControllerSystemInventory(ControllerParent calling, FormSystemInventory view, ArrayList list_customers, 
                                         ArrayList list_networks, ArrayList list_networkinventories, ArrayList list_systems, ArrayList list_systemInventories) : base(calling)
        {
            //connect controller to its view
            this.view = view;
            this.list_customers = list_customers;
            this.list_networks = list_networks;
            this.list_networkinventories = list_networkinventories;
            this.list_systems = list_systems;
            this.list_systemInventories = list_systemInventories;
            selectedNetworks = new ArrayList();
        }


        //funtions
        private void scanNetwork()
        {
            foreach (Network n in selectedNetworks)
            {
                Console.WriteLine("INVENTORY: {0}", n.Name);
                foreach (IPAddress ip in n.IpAddresses)
                {
                    // Ping the ip address
                    Ping pingSender = new Ping();
                    PingReply reply = pingSender.Send(ip, 100);
                    Console.WriteLine("Ping: {0}", ip.ToString());
                    if (reply.Status == IPStatus.Success)
                    {
                        currentSystem = new ClientSystem(list_systems.Count, ip);
                        list_systems.Add(currentSystem);
                        currentSystemInventory.AddSystemToInventory(currentSystem);
                        Console.WriteLine("System {0} added to Systeminventory", currentSystem.ClientIP.ToString());
                    }
                }
            }

        }

        public void Inventory()
        {
            scanNetwork();
        }

        private void scanDetails()
        {

        }

        public SystemInventory CreateSystemInventroy(int customerNumber)
        {
            currentSystemInventory = new SystemInventory(customerNumber, list_systemInventories.Count);
            list_systemInventories.Add(currentSystemInventory);
            //db.SaveSystemkInventories(list_systemInventories);
            return currentSystemInventory;
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


        public override void UpdateInformation()
        {//Updates all neccesary properties of the controller (could be caled by a controller who self was caled by this)
        }

        public void lstNetworksSelected(ListBox.SelectedObjectCollection selectedNetworks)
        {
            //Add selected Networks to List
            foreach (Network n in selectedNetworks)
            {
                selectedNetworks.Add(n);
            }
            //Set Checkbox State
            if(selectedNetworks.Count == currentNetworkInventory.List_networks.Count)
            {
                view.SetChkAll(true);
            }
            else
            {
                view.SetChkAll(false);
            }
        }

        public override void UpdateView(bool customerUpdated)
        {
            //Customer
            if (customerUpdated)
            {
                view.ClearCustomers();
                foreach (Customer c in list_customers)
                {
                    view.AddCustomer(c);
                }
            }

            //Networks
            view.ClearNetworks();
            if (currentNetworkInventory != null && currentNetworkInventory.List_networks.Count > 0)
            {
                foreach (Network n in currentNetworkInventory.List_networks)
                {
                    view.AddNetwork(n);
                }
            }
        }

        public override void SelectedCustomerChanged(Object customer)
        {
            base.SelectedCustomerChanged(customer);
            currentNetworkInventory = null;
            currentSystemInventory = null;
            Console.WriteLine("Customer changed successfully: New Customer: {0}", currentCustomer.Name);
            //Get Networkinventory of the customer
            foreach (NetworkInventory n in list_networkinventories)
            {
                if (n.Customernumber == currentCustomer.Cnumber)
                {
                    currentNetworkInventory = n;
                    Console.WriteLine("Networkinventory for customer {0} found", currentCustomer.Name);
                }
            }
            if (currentNetworkInventory == null)
            {
                Console.WriteLine("No Networkinventory found");
                MessageBox.Show("Kein Netzwerkinventar gefunden, bitte ein Netzwerkinventar für den Kunden erstellen", "Kein Netzwerkinventar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Get Systeminventory of the customer
            foreach (SystemInventory si in list_systemInventories)
            {
                if (si.Customernumber == currentCustomer.Cnumber)
                {
                    currentSystemInventory = si;
                    Console.WriteLine("Systeminventory for customer {0} found", currentCustomer.Name);
                }
            }
            if (currentSystemInventory == null)
            {
                currentSystemInventory = CreateSystemInventroy(currentCustomer.Cnumber);
                Console.WriteLine("New SystemInventory created");
            }
            UpdateView(false);
        }

        public void chkAll_Changed()
        {
            if (view.chkAll_State())
            {
                //Select all networks
                foreach (Network n in currentNetworkInventory.List_networks)
                {
                    view.lstNetworks_selectItem(currentNetworkInventory.List_networks.IndexOf(n));
                }
            }
        }

    }
}
