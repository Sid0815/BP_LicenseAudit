using System;
using BP_LicenseAudit.Model;
using BP_LicenseAudit.View;
using System.Windows.Forms;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;
using System.Management;
using System.Collections.Generic;

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
        private bool chkall;
        private string username;
        private string password;

        //constructor
        public ControllerSystemInventory(ControllerParent calling, FormSystemInventory view, ArrayList list_customers,
                                         ArrayList list_networks, ArrayList list_networkinventories, ArrayList list_systems, ArrayList list_systemInventories) : base(calling, list_customers)
        {
            //connect controller to its view
            this.view = view;
            this.list_networks = list_networks;
            this.list_networkinventories = list_networkinventories;
            this.list_systems = list_systems;
            this.list_systemInventories = list_systemInventories;
            selectedNetworks = new ArrayList();
            chkall = false;
        }


        //funtions
        public void Inventory(ListBox.SelectedObjectCollection selectedNetworks)
        {
            if (currentCustomer != null)
            {
                //Add selected Networks to List
                this.selectedNetworks.Clear();
                foreach (Network n in selectedNetworks)
                {
                    this.selectedNetworks.Add(n);
                }
                //Get Admin credntials
                username = null;
                password = null;
                GetCredenials();
                if (username == null || password == null)
                {
                    MessageBox.Show("Keine Zugangsdaten übermittelt. Bitte Inventarisierung erneut starten.", "Keine Zugangsdaten", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                scanNetwork();
                scanDetails();
                UpdateClients(selectedNetworks);
                //Client Systems are passed by reference, no need to update list_systems
                db.SaveSystemInventory(currentSystemInventory);
                callingController.UpdateInformation();
                MessageBox.Show("Inventarisierung beendet.", "Inventarisierung beendet.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kein Kunde ausgewählt. Bitte Kunde auswählen.", "Kein Kunde ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //scan Network for Clients
        private void scanNetwork()
        {
            //Create a new system Inventory
            currentSystemInventory = CreateSystemInventroy(currentCustomer.Cnumber);
            Console.WriteLine("New SystemInventory created");
            //Get the latest systemnumber
            int latestsystemnumber;
            //only if there is no data, set it manually
            if (list_systems.Count <= 0)
            {
                latestsystemnumber = 0;
            }
            else
            {
                currentSystem = (ClientSystem)list_systems[list_systems.Count - 1];
                latestsystemnumber = currentSystem.ClientSystemNumber;
            }
            //scan Networks
            Dictionary<String, IPAddress> unique = new Dictionary<string, IPAddress>();
            foreach (Network n in selectedNetworks)
            {
                // Ping each ip address of the network with timeout of 100ms
                foreach (IPAddress ip in n.IpAddresses)
                {
                    try
                    {
                        unique.Add(ip.ToString(), ip);
                        Ping pingSender = new Ping();
                        PingReply reply = pingSender.Send(ip, 100);
                        Console.WriteLine("Ping: {0}", ip.ToString());
                        if (reply.Status == IPStatus.Success)
                        {
                            currentSystem = new ClientSystem(++latestsystemnumber, ip, n.NetworkNumber);
                            list_systems.Add(currentSystem);
                            db.SaveClientSystem(currentSystem, currentSystemInventory);
                            currentSystemInventory.AddSystemToInventory(currentSystem);
                            Console.WriteLine("System {0} added to Systeminventory", currentSystem.ClientIP.ToString());
                        }
                    }
                    //If dictionary contains key already
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("IP-Addresse already in list: {0}", ip.ToString());
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        //Scan all Clients in current System Inevntory for Details
        private void scanDetails()
        {
            Console.WriteLine("Scanning Details");
            //Get IP of local Host because the wmi conection differs
            IPAddress[] localhost = Dns.GetHostAddresses("");
            ArrayList localadrresses = new ArrayList();
            foreach (IPAddress ip in localhost)
            {   //only IPv4
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localadrresses.Add(ip.ToString());
                    Console.WriteLine("Local Adresses: {0}", ip.ToString());
                }
            }
            foreach (ClientSystem c in currentSystemInventory.List_Systems)
            {
                //Connect via WMI
                string host = c.ClientIP.ToString();
                Console.WriteLine("Connecting to {0}", host);
                ConnectionOptions options = new ConnectionOptions();
                options.Username = username;
                options.Password = password;
                ManagementScope scope;
                //Localhost don't need credentials
                if (localadrresses.Contains(host))
                {
                    scope = new ManagementScope("\\\\" + host + "\\root\\cimv2");
                }
                else
                {
                    scope = new ManagementScope("\\\\" + host + "\\root\\cimv2", options);
                }
                try
                {
                    scope.Connect();
                    //Query Operating System Informations
                    ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                    ManagementObjectCollection queryCollection = searcher.Get();
                    foreach (ManagementObject m in queryCollection)
                    {
                        //Computername
                        Console.WriteLine("Computer Name : {0}",
                            m["csname"]);
                        c.Computername = (string)m["csname"];
                        //Operatingsystem
                        Console.WriteLine("Operating System: {0}", m["Caption"]);
                        c.Type = (string)m["Caption"];
                        //OperatingSystemSerial
                        Console.WriteLine("SerialNumber : {0}", m["SerialNumber"]);
                        c.Serial = (string)m["SerialNumber"];
                    }

                }
                catch (System.Runtime.InteropServices.COMException e)
                {
                    //Der RPC-Server ist nicht verfügbar. (Ausnahme von HRESULT: 0x800706BA)
                    Console.WriteLine("COM-Fehler bei der WMI Abfrage: {0}", e.Message);
                    //TODO: Add to ClientSystem Com Exception
                }
                catch (ManagementException e)
                {
                    //Fehler beim der WMI Abfrage: Zugriff verweigert. 
                    Console.WriteLine("Zugriffs-Fehler bei der WMI Abfrage: {0}", e.Message);
                    //TODO: Add to ClientSystem Management Exception
                }
                catch (Exception e)
                {
                    Console.WriteLine("AllgemeinerFehler bei der WMI Abfrage: {0}", e.Message);
                }
                if (c.Type != null)
                {
                    db.UpdateClientSystem(c);
                }
            }
        }

        public SystemInventory CreateSystemInventroy(int customerNumber)
        {
            currentSystemInventory = new SystemInventory(customerNumber, list_systemInventories.Count);
            list_systemInventories.Add(currentSystemInventory);
            return currentSystemInventory;
        }

        public override void UpdateInformation()
        {//Updates all neccesary properties of the controller (could be caled by a controller who self was caled by this)
        }

        public void lstNetworksSelected(ListBox.SelectedObjectCollection selectedNetworks)
        {
            //Get the Checkbox State
            bool state = view.chkAll_State();
            //if the networks get selected by the checkbox dont do anaything
            if (chkall)
            {
                UpdateClients(selectedNetworks);
                //Console.WriteLine("Networks Selected ignored");
                return;
            }
            //activate checkbox if all networks are selected manually
            else if ((selectedNetworks.Count == currentNetworkInventory.List_networks.Count) && (state == false))
            {
                //Console.WriteLine("All networks selected manually");
                view.SetChkAll(true);
            }
            //diable checkbox if not all networks are selected manually
            else if (state && (selectedNetworks.Count != currentNetworkInventory.List_networks.Count))
            {
                //Console.WriteLine("Not all networks selected manually");
                view.SetChkAll(false);
            }
            UpdateClients(selectedNetworks);

        }

        //Updates the Clientlist of the view
        private void UpdateClients(ListBox.SelectedObjectCollection selectedNetworks)
        {
            //Add for each selected network all matching ClientSystems from current SystemInventory
            view.ClearClientSystems();
            view.ClearClientDetails();
            if (currentSystemInventory != null)
            {
                foreach (Network n in selectedNetworks)
                {
                    foreach (ClientSystem c in currentSystemInventory.List_Systems)
                    {
                        if (c.Networknumber == n.NetworkNumber && (c.Type != null && !(c.Type.Equals(""))))
                        {
                            view.AddClientSystem(c);
                        }
                    }
                }
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

            view.SetChkAll(false);

            //Networks
            view.ClearNetworks();
            if (currentNetworkInventory != null && currentNetworkInventory.List_networks.Count > 0)
            {
                foreach (Network n in currentNetworkInventory.List_networks)
                {
                    view.AddNetwork(n);
                }
            }

            //System
            view.ClearClientDetails();
            view.ClearClientSystems();
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
            //Get latest Systeminventory of the customer
            foreach (SystemInventory si in list_systemInventories)
            {
                if (si.Customernumber == currentCustomer.Cnumber)
                {
                    if (currentSystemInventory == null)
                    {
                        currentSystemInventory = si;
                        Console.WriteLine("Systeminventory for customer {0} found", currentCustomer.Name);
                    }
                    //if a systeminventory is newer than the current take this instead
                    else if (DateTime.Compare(si.Date, currentSystemInventory.Date) > 0)
                    {
                        currentSystemInventory = si;
                        Console.WriteLine("Newer Systeminventory for customer {0} found", currentCustomer.Name);
                    }
                }
            }
            //Inform the customer and select all networks to show all Clientsystems of the latest Systeminventory
            if (currentSystemInventory != null)
            {
                MessageBox.Show(String.Format("Es wird das aktuellste Systeminventar vom {0} dargestellt.", currentSystemInventory.Date), "Systeminventar gefunden", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateView(false);
                view.SetChkAll(true);
                return;
            }
            UpdateView(false);
        }

        //manage the checkbox to select or diselect all networks
        public void chkAll_Changed()
        {
            //Console.WriteLine("chkAll_Changed called");
            if (view.chkAll_State())
            {
                //set chkall to true to disable lstNetworksSelected (avoid loop)
                chkall = true;
                //Select all networks
                foreach (Network n in currentNetworkInventory.List_networks)
                {
                    view.lstNetworks_selectItem(currentNetworkInventory.List_networks.IndexOf(n), true);
                }
                //set chkall to false to enable lstNetworksSelected
                chkall = false;
            }
            else
            {
                //Unselect all networks
                foreach (Network n in currentNetworkInventory.List_networks)
                {
                    view.lstNetworks_selectItem(currentNetworkInventory.List_networks.IndexOf(n), false);
                }
            }
        }

        //Open new Form to get credentials for WMI Authorization
        public void GetCredenials()
        {
            FormCredentials view_credentials = new FormCredentials(this);
            view_credentials.ShowDialog();
        }

        //set the credentials
        public void SetCredentials(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        //Updates the Clientinformations in the view
        public void ClientSelected(Object c)
        {
            if (c != null)
            {
                currentSystem = (ClientSystem)c;
                view.UpdateClientDetails(currentSystem.Computername, currentSystem.ClientIP.ToString(), currentSystem.Type);
            }

        }
    }
}
