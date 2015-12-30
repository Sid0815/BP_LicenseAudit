using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BP_LicenseAudit.View;
using BP_LicenseAudit.Model;
using System.Windows.Forms;
using System.Collections;
using System.Net;

namespace BP_LicenseAudit.Controller
{
    public class ControllerChanges : ControllerParent
    {
        //properties
        private FormChange view;
        private NetworkInventory currentNetworkInventory;
        private Network selectedNetwork;
        private LicenseInventory currentLicenseInventory;
        private License selectedlicense;
        private ArrayList list_networks;
        private ArrayList list_networkInventories;
        private ArrayList list_licenseInventories;
        private ArrayList list_allAvailableLicenses;

        //constrctor
        public ControllerChanges(ControllerParent calling, FormChange view, ArrayList list_customers, ArrayList list_networks, ArrayList list_networkinventories, ArrayList list_licenseInventories, ArrayList list_allAvailableLicenses) : base(calling, list_customers)
        {
            //connect controller to its view
            this.view = view;
            this.list_networks = list_networks;
            this.list_networkInventories = list_networkinventories;
            this.list_licenseInventories = list_licenseInventories;
            this.list_allAvailableLicenses = list_allAvailableLicenses;
        }

        //functions

        //Update the vie with the selected license
        public void SelectedLicenseChanged(string license, string count)
        {
            selectedlicense = null;
            int c = 0;
            try
            {
                c = int.Parse(count);
            }
            catch (Exception e)
            {
                Log.WriteLog("Error parsing int");
            }
            foreach (License l in list_allAvailableLicenses)
            {
                if (l.Name.Equals(license))
                {
                    selectedlicense = l;
                }
            }
            if (selectedlicense != null)
            {
                view.UpdateLicense(selectedlicense, c);
            }



        }

        public void UpdateLicenseInventory(Object license, decimal count)
        {
            License l = (License)license;
            //Check if Licensetype is already in Licenseinventory
            int x = -1;
            DialogResult dr = DialogResult.No;
            if (currentLicenseInventory == null)
            {
                MessageBox.Show("Kein Lizenzinventar für diesen Kunden gefunden.", "Kein Lizenzinventar gefunden", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                foreach (Tuple<int, int> t in currentLicenseInventory.Inventory)
                {
                    if (t.Item1 == l.LicenseNumber)
                    {   //Get Index of license, in the loop deleting is not possible
                        x = currentLicenseInventory.Inventory.IndexOf(t);
                        //If the new count is the same as already in the inventory
                        if (t.Item2 == count)
                        {
                            MessageBox.Show("Lizenz bereits im Inventar vorhanden. Es wurden keine Daten geändert.", "Lizenz bereits vorhanden", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            dr = MessageBox.Show(String.Format("Soll die Lizenz von {0} auf {1} aktualisiert werden.", t.Item2, count), "Lizenz aktualisiert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                    }
                }
                //License doubled and update yes --> remove old status, and add new status
                if (dr == DialogResult.Yes && (x != -1))
                {
                    currentLicenseInventory.RemoveLicenseFromInventory(l.LicenseNumber);
                    currentLicenseInventory.AddLicenseToInventory(l.LicenseNumber, (int)count);
                    callingController.UpdateInformation();
                    db.UpdateLicenseInventory(currentLicenseInventory, l, (int)count);
                    UpdateView(false);
                }
                else if (dr == DialogResult.No && (x == -1))
                {
                    MessageBox.Show("Lizenz nicht im Inventar vorhanden. Bitte einen im Inventar vorhandenen Lizenztyp wählen.", "Lizenz nicht im Inventar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        //Update the view with the selected network
        public void SelectedNetworkChanged(object selectedNetwork)
        {
            this.selectedNetwork = (Network)selectedNetwork;
            if (this.selectedNetwork != null)
            {
                //1=Start-/EndAddress
                //2=Host only
                //3=Cidr
                int type = this.selectedNetwork.InputType;
                switch (type)
                {
                    case 1:
                        {
                            //Get the start and endaddress, get their bytes, convert them to strings and pass them to the view
                            view.SetNetworkTab(type - 1);
                            view.ClearStartEndInput();
                            IPAddress start = (IPAddress)this.selectedNetwork.IpAddresses[0];
                            IPAddress end = (IPAddress)this.selectedNetwork.IpAddresses[this.selectedNetwork.IpAddresses.Count - 1];
                            Byte[] b_start = start.GetAddressBytes();
                            Byte[] b_end = end.GetAddressBytes();
                            string[] s_start = new string[4], s_end = new string[4];
                            for (int i = 0; i < 4; i++)
                            {
                                s_start[i] = b_start[i].ToString();
                                s_end[i] = b_end[i].ToString();
                            }
                            view.UpdateStartEndInput(s_start, s_end);
                            break;
                        }

                    case 2:
                        {
                            //Get Hostaddress and convert their bytes to string and pass them to the view
                            view.SetNetworkTab(type - 1);
                            view.ClearHostInput();
                            IPAddress host = (IPAddress)this.selectedNetwork.IpAddresses[0];
                            Byte[] b_host = host.GetAddressBytes();
                            string[] s_host = new string[4];
                            for (int i = 0; i < 4; i++)
                            {
                                s_host[i] = b_host[i].ToString();
                            }
                            view.UpdateHostInput(s_host);
                            break;
                        }

                    case 3:
                        {
                            //Get the name, split cidr and bytes from the name and pass to view
                            view.SetNetworkTab(type - 1);
                            view.ClearCidrInput();
                            string[] cidr = this.selectedNetwork.Name.Split('/', '.');
                            for (int i = 0; i < cidr.Length; i++)
                            {
                                cidr[i].Trim();
                            }
                            view.UpdateCidrInput(cidr);
                            break;
                        }
                    default:
                        {
                            Log.WriteLog("Error, wrong Inputtype");
                            break;
                        }

                }
            }
        }

        public void UpdateNetworkInventory(object selectedNetwork)
        {
            //bind to existing network
            if (selectedNetwork == null)
            {
                MessageBox.Show("Kein Netzwerk ausgewählt. Bitte zuerst ein Netzwerk auswählen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Network help = (Network)selectedNetwork;
                foreach (Network n in list_networks)
                {
                    if (help.NetworkNumber == n.NetworkNumber)
                    {
                        this.selectedNetwork = n;
                    }
                }
                string newname = null;
                //Question if the network should be changed as selected
                switch (view.GetNetworkInputtype())
                {
                    case 1:
                        {
                            string[] str_s = view.GetStartAddress();
                            string[] str_e = view.GetEndAddress();
                            newname = String.Format("{0}.{1}.{2}.{3} - {4}.{5}.{6}.{7}", str_s[0], str_s[1], str_s[2], str_s[3], str_e[0], str_e[1], str_e[2], str_e[3]);
                            break;
                        }
                    case 2:
                        {
                            string[] str_h = view.GetHostAddress();
                            newname = String.Format("{0}.{1}.{2}.{3}", str_h[0], str_h[1], str_h[2], str_h[3]);
                            break;
                        }
                    case 3:
                        {
                            string[] str_cidr = view.GetCidrAddress();
                            string[] str_e = view.GetEndAddress();
                            newname = String.Format("{0}.{1}.{2}.{3} / {4}", str_cidr[0], str_cidr[1], str_cidr[2], str_cidr[3], str_cidr[4]);
                            break;
                        }
                    default:
                        newname = "";
                        break;
                }
                DialogResult dr = MessageBox.Show(String.Format("Soll das Netzwerk {0} in das Netzwerk {1} geändert werden?", this.selectedNetwork.Name, newname), "Netzwerk ändern", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        //Change the network
                        switch (view.GetNetworkInputtype())
                        {
                            case 1:
                                {
                                    //Get Address-Bytes as string
                                    string[] str_startaddress = new string[4];
                                    str_startaddress = view.GetStartAddress();
                                    string[] str_endaddress = new string[4];
                                    str_endaddress = view.GetEndAddress();
                                    //Convert into byte
                                    Byte[] b_startaddress = new Byte[4];
                                    Byte[] b_endaddress = new Byte[4];
                                    //Checks automaticaly for right value by its type and by converting
                                    b_startaddress[0] = Convert.ToByte(str_startaddress[0]);
                                    b_startaddress[1] = Convert.ToByte(str_startaddress[1]);
                                    b_startaddress[2] = Convert.ToByte(str_startaddress[2]);
                                    b_startaddress[3] = Convert.ToByte(str_startaddress[3]);
                                    b_endaddress[0] = Convert.ToByte(str_endaddress[0]);
                                    b_endaddress[1] = Convert.ToByte(str_endaddress[1]);
                                    b_endaddress[2] = Convert.ToByte(str_endaddress[2]);
                                    b_endaddress[3] = Convert.ToByte(str_endaddress[3]);
                                    IPAddress start = new IPAddress(b_startaddress);
                                    IPAddress end = new IPAddress(b_endaddress);
                                    //Check for right input: Start must be lower than end
                                    if (ControllerNetwork.convertIPtoUInt32(start) > ControllerNetwork.convertIPtoUInt32(end))
                                    {
                                        IPAddress helper = start;
                                        start = end;
                                        end = helper;
                                        MessageBox.Show("Addressen gedreht.", "Inputfehler korregiert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    if ((int)(ControllerNetwork.convertIPtoUInt32(end) - ControllerNetwork.convertIPtoUInt32(start)) > 10000)
                                    {
                                        DialogResult dr_inner = MessageBox.Show("Achtung: Die Berechnung dieses Netzwerks kann unter Umständen länger dauern. Wollen Sie fortfahren?", "Warnung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                        if (dr_inner == DialogResult.No)
                                        {
                                            return;
                                        }
                                    }
                                    this.selectedNetwork.Name = String.Format("{0} - {1}", start.ToString(), end.ToString());
                                    this.selectedNetwork.InputType = view.GetNetworkInputtype();
                                    this.selectedNetwork.IpAddresses = ControllerNetwork.calcAddressesSE(start, end, view.GetProgressBar());
                                    view.ClearStartEndInput();
                                    break;
                                }
                            case 2:
                                {
                                    //Get Address-Bytes as string
                                    string[] str_hostaddress = new string[4];
                                    str_hostaddress = view.GetHostAddress();
                                    //Convert into byte
                                    Byte[] b_hostaddress = new Byte[4];
                                    //Checks automaticaly for right value by its type and by converting
                                    b_hostaddress[0] = Convert.ToByte(str_hostaddress[0]);
                                    b_hostaddress[1] = Convert.ToByte(str_hostaddress[1]);
                                    b_hostaddress[2] = Convert.ToByte(str_hostaddress[2]);
                                    b_hostaddress[3] = Convert.ToByte(str_hostaddress[3]);
                                    IPAddress host = new IPAddress(b_hostaddress);
                                    ArrayList addresses = new ArrayList();
                                    addresses.Add(host);
                                    this.selectedNetwork.Name = host.ToString();
                                    this.selectedNetwork.InputType = view.GetNetworkInputtype();
                                    this.selectedNetwork.IpAddresses = addresses;
                                    view.ClearHostInput();
                                    break;
                                }
                            case 3:
                                {
                                    //Get Address-Bytes as string
                                    string[] str_cidraddress = new string[5];
                                    str_cidraddress = view.GetCidrAddress();
                                    //Convert into byte
                                    Byte[] b_cidraddress = new Byte[4];
                                    byte cidr = 0;
                                    //Checks automaticaly for right value by its type and by converting
                                    b_cidraddress[0] = Convert.ToByte(str_cidraddress[0]);
                                    b_cidraddress[1] = Convert.ToByte(str_cidraddress[1]);
                                    b_cidraddress[2] = Convert.ToByte(str_cidraddress[2]);
                                    b_cidraddress[3] = Convert.ToByte(str_cidraddress[3]);
                                    cidr = Convert.ToByte(str_cidraddress[4]);
                                    if (cidr > 32) throw new Exception("Cidr overflow");
                                    if (cidr < 19)
                                    {
                                        DialogResult dr_inner = MessageBox.Show("Achtung: Die Berechnung dieses Netzwerks kann unter Umständen länger dauern. Wollen Sie fortfahren?", "Warnung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                        if (dr_inner == DialogResult.No)
                                        {
                                            return;
                                        }
                                    }
                                    //Creating and adding network
                                    IPAddress network = new IPAddress(b_cidraddress);
                                    this.selectedNetwork.Name = String.Format("{0} / {1}", network.ToString(), cidr.ToString());
                                    Log.WriteLog("NetworktabTest:" + view.GetNetworkInputtype());
                                    this.selectedNetwork.InputType = view.GetNetworkInputtype();

                                    this.selectedNetwork.IpAddresses = ControllerNetwork.calcAddressesCidr(network, cidr, view.GetProgressBar());
                                    view.ClearCidrInput();
                                    break;
                                }
                            default:
                                newname = "";
                                break;
                        }
                        db.UpdateNetwork(this.selectedNetwork);
                        callingController.UpdateInformation();
                        UpdateView(false);
                    }
                    catch (FormatException e)
                    {
                        Log.WriteLog("Error while parsing IPAddress String to Byte: " + e.Message);
                        MessageBox.Show("Fehler bei der Eingabe der Adressen", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    catch (OutOfMemoryException e)
                    {
                        MessageBox.Show("Maximal zulässige Anzahl an Adressen überschritten. Das Netzwerk wurde nicht hinzugefügt. Bitte Netzwerk korregieren.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Log.WriteLog("Speicherüberlauf: " + e.Message);
                        GC.Collect();
                        return;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Allgemeiner Fehler.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Log.WriteLog("Allgemeiner Fehler: " + e.Message);
                        return;
                    }
                }
            }
        }

        public void UpdateCustomer(Object customer, string name, string street, string streetnr, string city, string zip)
        {
            if (customer == null)
            {
                MessageBox.Show("Kein Kunde ausgewählt. Bitte zuerst einen Kunden auswählen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (name == null || street == null || streetnr == null || city == null || zip == null || name.Trim().Equals("") || street.Trim().Equals("") || streetnr.Trim().Equals("") || city.Trim().Equals("") || zip.Trim().Equals(""))
            {
                MessageBox.Show("Bitte prüfen Sie ihre Eingabe.", "Eingabefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool zip_ok = true;
                //check if zip contains only digits
                foreach (Char ch in zip)
                {
                    if (!Char.IsDigit(ch))
                    {
                        MessageBox.Show("Fehler bei der Eingabe der Postleitzahl", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        zip_ok = false;
                    }
                }
                if (zip_ok)
                {
                    Customer c = (Customer)customer;
                    int x = list_customers.IndexOf(c);
                    currentCustomer = (Customer)list_customers[x];
                    if ((!currentCustomer.Name.Equals(name)) || (!currentCustomer.Street.Equals(street)) || (!currentCustomer.Streetnumber.Equals(streetnr)) || (!currentCustomer.City.Equals(city)) || (!currentCustomer.Zip.Equals(zip)))
                    {
                        DialogResult dr = MessageBox.Show(String.Format("Soll der Kunde {0}, {1}, {2}, {3}, {4} in {5}, {6}, {7}, {8}, {9} geändert werden?",
                            currentCustomer.Name, currentCustomer.Street, currentCustomer.Streetnumber, currentCustomer.City, currentCustomer.Zip,
                            name, street, streetnr, city, zip), "Kunde aktualisieren", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            currentCustomer.Name = name;
                            currentCustomer.Street = street;
                            currentCustomer.Streetnumber = streetnr;
                            currentCustomer.City = city;
                            currentCustomer.Zip = zip;
                            UpdateView(true);
                            UpdateCustomerView();
                            db.UpdateCustomer(currentCustomer);
                        }
                    }
                }

            }
        }

        public void RemoveNetwork(Object selectedNetwork)
        {
            if (selectedNetwork == null)
            {
                MessageBox.Show("Kein Netzwerk ausgewählt. Bitte zuerst ein Netzwerk auswählen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.selectedNetwork = (Network)selectedNetwork;
                DialogResult dr = MessageBox.Show(String.Format("Soll das Netzwerk {0} unwiderruflich gelöscht werden?", this.selectedNetwork.Name), "Netzwerk löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    for (int i = 0; i < currentNetworkInventory.List_networks.Count; i++)
                    {
                        Network n = (Network)currentNetworkInventory.List_networks[i];
                        if (n.NetworkNumber == this.selectedNetwork.NetworkNumber)
                        {
                            currentNetworkInventory.List_networks.Remove(n);
                            i = currentNetworkInventory.List_networks.Count;
                        }
                    }
                    //TODO: UPDATE NI
                    db.RemoveNetwork(this.selectedNetwork);
                    callingController.UpdateInformation();
                    UpdateView(false);
                    MessageBox.Show(String.Format("Das Netzwerk {0} wurde unwiderruflich gelöscht.", this.selectedNetwork.Name), "Netzwerk gelöscht", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            UpdateCustomerView();
            //License Types (only updated if a the number of diplayed types and the number of types is different)
            if (!(list_allAvailableLicenses.Count == view.CountLicenseTypes()))
            {
                Log.WriteLog("ViewUpdate Licensetypes");
                view.ClearLicenseTypes();
                foreach (License l in list_allAvailableLicenses)
                {
                    view.AddLicenseType(l);
                }
            }
            //LicenseInventory
            view.ClearLicenses();
            if (currentLicenseInventory != null)
            {
                foreach (Tuple<int, int> t in currentLicenseInventory.Inventory)
                {
                    int licensenumber = t.Item1;
                    int count = t.Item2;
                    foreach (License l in list_allAvailableLicenses)
                    {
                        if (l.LicenseNumber == licensenumber)
                        {
                            view.AddLicense(l.Name, count);
                        }
                    }
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

        public override void UpdateInformation()
        {

        }

        //Fills textboxes with selected customer data
        public void UpdateCustomerView()
        {
            view.ClearCustomer();
            if (currentCustomer != null)
            {
                view.UpdateCustomer(currentCustomer.Name, currentCustomer.City, currentCustomer.Zip, currentCustomer.Street, currentCustomer.Streetnumber);
            }
        }

        public override void SelectedCustomerChanged(Object customer)
        {
            base.SelectedCustomerChanged(customer);
            currentLicenseInventory = null;
            currentNetworkInventory = null;
            Log.WriteLog(string.Format("Customer changed successfully: New Customer: {0}", currentCustomer.Name));
            //Get Licenseinventory of the customer
            foreach (LicenseInventory li in list_licenseInventories)
            {
                if (li.Customernumber == currentCustomer.Cnumber)
                {
                    currentLicenseInventory = li;
                    Log.WriteLog(string.Format("Licenseinventory for customer {0} found", currentCustomer.Name));
                }
            }
            if (currentLicenseInventory == null)
            {
                MessageBox.Show("Kein Lizenzinventar für diesen Kunden gefunden.", "Kein Lizenzinventar gefunden", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Get Networkinventory of the customer
            foreach (NetworkInventory ni in list_networkInventories)
            {
                if (ni.Customernumber == currentCustomer.Cnumber)
                {
                    currentNetworkInventory = ni;
                    Log.WriteLog(string.Format("Networkinventory for customer {0} found", currentCustomer.Name));
                }
            }
            if (currentNetworkInventory == null)
            {
                MessageBox.Show("Kein Netzwerkinventar für diesen Kunden gefunden.", "Kein Netzwerkinventar gefunden", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateView(false);
        }
    }
}
