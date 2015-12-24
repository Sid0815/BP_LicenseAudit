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
        private ArrayList list_allAvailableLicenses;
        private bool chkall;
        private string username;
        private string password;

        //constructor
        public ControllerSystemInventory(ControllerParent calling, FormSystemInventory view, ArrayList list_customers,
                                         ArrayList list_networks, ArrayList list_networkinventories, ArrayList list_systems, ArrayList list_systemInventories, ArrayList list_licenses) : base(calling, list_customers)
        {
            //connect controller to its view
            this.view = view;
            this.list_networks = list_networks;
            this.list_networkinventories = list_networkinventories;
            this.list_systems = list_systems;
            this.list_systemInventories = list_systemInventories;
            this.list_allAvailableLicenses = list_licenses;
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
                if (this.selectedNetworks.Count < 1)
                {
                    MessageBox.Show("Kein Netzwerk ausgewählt. Bitte Netzwerke auswählen und Inventarisierung erneut starten.", "Keine Netzwerk ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
                scanNetwork(view.GetProgressBar());
                scanDetails(view.GetProgressBar());
                updateClients(selectedNetworks);
                //Client Systems are passed by reference, no need to update list_systems
                callingController.UpdateInformation();
                MessageBox.Show("Inventarisierung beendet.", "Inventarisierung beendet.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kein Kunde ausgewählt. Bitte Kunde auswählen.", "Kein Kunde ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //scan Network for Clients
        private void scanNetwork(ProgressBar progress)
        {
            //Create a new system Inventory
            currentSystemInventory = CreateSystemInventroy(currentCustomer.Cnumber);
            Log.WriteLog("New SystemInventory created");
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
            //Get number adresses
            int i = 0;
            foreach (Network n in selectedNetworks)
            {
                foreach (IPAddress ip in n.IpAddresses) i++;
            }
            if (progress != null)
            {
                progress.Value = 0;
                progress.Maximum = i;
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
                        if (progress != null) progress.PerformStep();
                        unique.Add(ip.ToString(), ip);
                        Ping pingSender = new Ping();
                        PingReply reply = pingSender.Send(ip, 100);
                        Log.WriteLog(string.Format("Ping: {0}", ip.ToString()));
                        if (reply.Status == IPStatus.Success)
                        {
                            currentSystem = new ClientSystem(++latestsystemnumber, ip, n.NetworkNumber);
                            list_systems.Add(currentSystem);
                            db.SaveClientSystem(currentSystem, currentSystemInventory);
                            currentSystemInventory.AddSystemToInventory(currentSystem);
                            Log.WriteLog(string.Format("System {0} added to Systeminventory",
                                currentSystem.ClientIP.ToString()));
                        }
                    }
                    //If dictionary contains key already
                    catch (ArgumentException e)
                    {
                        Log.WriteLog(string.Format("IP-Addresse already in list: {0}", ip.ToString()));
                        Log.WriteLog(e.Message);
                    }
                }
            }
        }

        //Scan all Clients in current System Inevntory for Details
        private void scanDetails(ProgressBar progress)
        {
            //Prepare known license types
            Dictionary<string, int> licenses = new Dictionary<string, int>();
            foreach (License l in list_allAvailableLicenses)
            {
                if (!licenses.ContainsKey(l.Name))
                {
                    licenses.Add(l.Name, l.LicenseNumber);
                }
            }
            Log.WriteLog("Scanning Details");
            //Get IP of local Host because the wmi conection differs
            IPAddress[] localhost = Dns.GetHostAddresses("");
            ArrayList localadrresses = new ArrayList();
            foreach (IPAddress ip in localhost)
            {   //only IPv4
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localadrresses.Add(ip.ToString());
                    Log.WriteLog(string.Format("Local Adresses: {0}", ip.ToString()));
                }
            }
            if (progress != null)
            {
                progress.Value = 0;
                progress.Maximum = currentSystemInventory.List_Systems.Count;
            }

            foreach (ClientSystem c in currentSystemInventory.List_Systems)
            {
                //Connect via WMI
                string host = c.ClientIP.ToString();
                Log.WriteLog(string.Format("Connecting to {0}", host));
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
                        Log.WriteLog(string.Format("Computer Name : {0}", m["csname"]));
                        c.Computername = (string)m["csname"];
                        //Operatingsystem
                        Log.WriteLog(string.Format("Operating System: {0}", m["Caption"]));
                        c.Type = (string)m["Caption"];
                        //OperatingSystemSerial
                        Log.WriteLog(string.Format("SerialNumber : {0}", m["SerialNumber"]));
                        c.Serial = (string)m["SerialNumber"];
                    }
                    //Check if it is an unknow license type
                    if (!licenses.ContainsKey(c.Type))
                    {
                        //licensetype unknown, learn it
                        License newlicense = new License(list_allAvailableLicenses.Count, c.Type);
                        list_allAvailableLicenses.Add(newlicense);
                        db.SaveLicense(newlicense);
                        licenses.Add(newlicense.Name, newlicense.LicenseNumber);
                        Log.WriteLog("Neue Lizenz gelernt: " + newlicense.Name);
                    }
                }
                catch (System.Runtime.InteropServices.COMException e)
                {
                    //Der RPC-Server ist nicht verfügbar. (Ausnahme von HRESULT: 0x800706BA)
                    Log.WriteLog(string.Format("COM-Fehler bei der WMI Abfrage: {0}", e.Message));
                }
                catch (ManagementException e)
                {
                    //Fehler beim der WMI Abfrage: Zugriff verweigert. 
                    Log.WriteLog(string.Format("Zugriffs-Fehler bei der WMI Abfrage: {0}", e.Message));
                }
                catch (Exception e)
                {
                    Log.WriteLog(string.Format("AllgemeinerFehler bei der WMI Abfrage: {0}", e.Message));
                }
                if (c.Type != null)
                {
                    db.UpdateClientSystem(c);
                }
                if (progress != null) progress.PerformStep();
            }
        }

        public SystemInventory CreateSystemInventroy(int customerNumber)
        {
            currentSystemInventory = new SystemInventory(customerNumber, list_systemInventories.Count);
            db.SaveSystemInventory(currentSystemInventory);
            list_systemInventories.Add(currentSystemInventory);
            return currentSystemInventory;
        }

        public override void UpdateInformation()
        {//Updates all neccesary properties of the controller (could be caled by a controller who self was caled by this)
        }

        public void LstNetworksSelected(ListBox.SelectedObjectCollection selectedNetworks)
        {
            //Get the Checkbox State
            bool state = view.chkAll_State();
            //if the networks get selected by the checkbox dont do anaything
            if (chkall)
            {
                updateClients(selectedNetworks);
                //Log.WriteLog("Networks Selected ignored");
                return;
            }
            //activate checkbox if all networks are selected manually
            else if ((selectedNetworks.Count == currentNetworkInventory.List_networks.Count) && (state == false))
            {
                //Log.WriteLog("All networks selected manually");
                view.SetChkAll(true);
            }
            //diable checkbox if not all networks are selected manually
            else if (state && (selectedNetworks.Count != currentNetworkInventory.List_networks.Count))
            {
                //Log.WriteLog("Not all networks selected manually");
                view.SetChkAll(false);
            }
            updateClients(selectedNetworks);

        }

        //Updates the Clientlist of the view
        private void updateClients(ListBox.SelectedObjectCollection selectedNetworks)
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
            Log.WriteLog(string.Format("Customer changed successfully: New Customer: {0}", currentCustomer.Name));
            //Get Networkinventory of the customer
            foreach (NetworkInventory n in list_networkinventories)
            {
                if (n.Customernumber == currentCustomer.Cnumber)
                {
                    currentNetworkInventory = n;
                    Log.WriteLog(string.Format("Networkinventory for customer {0} found", currentCustomer.Name));
                }
            }
            if (currentNetworkInventory == null)
            {
                Log.WriteLog("No Networkinventory found");
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
                        Log.WriteLog(string.Format("Systeminventory for customer {0} found", currentCustomer.Name));
                    }
                    //if a systeminventory is newer than the current take this instead
                    else if (DateTime.Compare(si.Date, currentSystemInventory.Date) > 0)
                    {
                        currentSystemInventory = si;
                        Log.WriteLog(string.Format("Newer Systeminventory for customer {0} found", currentCustomer.Name));
                    }
                }
            }
            //Inform the customer and select all networks to show all Clientsystems of the latest Systeminventory
            if (currentSystemInventory != null)
            {
                // check if all belonging networks still exist
                bool deletednetworks = false;
                foreach (ClientSystem c in currentSystemInventory.List_Systems)
                {
                    if (c.Networknumber == -1)
                    {
                        deletednetworks = true;
                        break;
                    }
                }
                if (!deletednetworks)
                {
                    MessageBox.Show(String.Format("Es wird das aktuellste Systeminventar vom {0} dargestellt.", currentSystemInventory.Date), "Systeminventar gefunden", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(String.Format("Es wird das aktuellste Systeminventar vom {0} dargestellt. Dies enthält jedoch bereits gelöschte Netzwerke. Daher werden nicht mehr alle Clientsysteme dieses Inventars angezeigt. Es wird empfohlen eine erneute Inventarisierung für diesen Kunden durchzufürhen.",
                        currentSystemInventory.Date), "Systeminventar gefunden", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                UpdateView(false);
                view.SetChkAll(true);
                return;
            }
            UpdateView(false);
        }

        //manage the checkbox to select or diselect all networks
        public void chkAll_Changed()
        {
            if (currentNetworkInventory != null && currentNetworkInventory.List_networks.Count > 0)
            {
                //Log.WriteLog("chkAll_Changed called");
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
