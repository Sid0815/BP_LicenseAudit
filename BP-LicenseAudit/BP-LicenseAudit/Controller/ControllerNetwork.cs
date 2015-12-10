using System;
using System.Net;
using System.Collections;
using BP_LicenseAudit.Model;
using BP_LicenseAudit.View;
using System.Windows.Forms;

namespace BP_LicenseAudit.Controller
{
    public class ControllerNetwork : ControllerParent
    {
        private FormNetwork view;
        private ArrayList list_networks;
        private ArrayList list_networkinventories;
        private NetworkInventory currentNetworkInventory;
        private Network currentNetwork;
        private int inputtype = 0;

        //constructor
        public ControllerNetwork(ControllerParent calling, FormNetwork view, ArrayList list_customers, ArrayList list_networks, ArrayList list_networkinventories) : base(calling)
        {
            //connect controller to its view
            this.view = view;
            this.list_customers = list_customers;
            this.list_networks = list_networks;
            this.list_networkinventories = list_networkinventories;
        }

        //functions


        public static ArrayList calcAddressesSE(IPAddress start, IPAddress end)
        {
            ArrayList addresses = new ArrayList();
            addresses.Add(start);
            if (start.Equals(end))
            {
                return addresses;
            }
            UInt32 h = 0;
            while (!(start.Equals(end)))
            {
                h = convertIPtoUInt32(start);
                h++;
                start = IPAddress.Parse(Convert.ToString(h));
                addresses.Add(start);
            }
            return addresses;
        }

        public static ArrayList calcAddressesCidr(IPAddress network, byte cidr)
        {
            ArrayList addresses = new ArrayList();
            UInt32 subnetmask;
            UInt32 convertedIP = 0;
            UInt32 networkip = 0;
            UInt32 broadcast = 0;
            convertedIP = convertIPtoUInt32(network);
            //get subnetmask by shifting and building the complement
            if (cidr == 32)
            {
                addresses.Add(network);
                return addresses;
            }
            else subnetmask = ~(0xffffffff >> cidr);
            //calculate networkip
            networkip = convertedIP & subnetmask;
            IPAddress ipStartAddress = IPAddress.Parse(Convert.ToString(networkip));
            //calculate endaddress of the range
            broadcast = (networkip & subnetmask) | ~subnetmask;
            IPAddress ipEndAddress = IPAddress.Parse(Convert.ToString(broadcast));
            //calculate Addresses of the range
            addresses = calcAddressesSE(ipStartAddress, ipEndAddress);
            return addresses;
        }

        public NetworkInventory CreateNetworkInventory(int customerNumber)
        {
            currentNetworkInventory = new NetworkInventory(customerNumber, list_networkinventories.Count, new ArrayList());
            list_networkinventories.Add(currentNetworkInventory);
            db.SaveNetworkInventories(list_networkinventories);
            return currentNetworkInventory;
        }

        public void AddNetworkToInventory()
        {
            inputtype = view.GetInputtype();
            if (currentCustomer != null)
            {
                try
                {
                    switch (inputtype)
                    {
                        //Start- Endaddress
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
                                if (convertIPtoUInt32(start) > convertIPtoUInt32(end))
                                {
                                    IPAddress helper = start;
                                    start = end;
                                    end = helper;
                                    MessageBox.Show("Addressen gedreht.", "Inputfehler korregiert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                //Creating and adding network
                                currentNetwork = new Network(list_networks.Count,
                                                                String.Format("{0} - {1}", start.ToString(), end.ToString()),
                                                                inputtype,
                                                                calcAddressesSE(start, end));
                                view.ClearStartEndInput();
                                break;
                            }
                        //Host
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
                                currentNetwork = new Network(list_networks.Count,
                                                                host.ToString(),
                                                                inputtype,
                                                                addresses);
                                view.ClearHostInput();
                                break;
                            }

                        //Cidr
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
                                if (cidr > 32) throw new Exception();
                                //Creating and adding network
                                IPAddress network = new IPAddress(b_cidraddress);
                                currentNetwork = new Network(list_networks.Count,
                                                                String.Format("{0} / {1}", network.ToString(), cidr.ToString()),
                                                                inputtype,
                                                                calcAddressesCidr(network, cidr));
                                view.ClearCidrInput();
                                break;
                            }
                        default:
                            Console.WriteLine("Unknown Inputtype");
                            break;
                    }


                    list_networks.Add(currentNetwork);
                    view.AddNetwork(currentNetwork);
                    currentNetworkInventory.AddNetwork(currentNetwork);
                    db.SaveNetwork(currentNetwork);
                    db.SaveNetworkInventories(list_networkinventories);
                    callingController.UpdateInformation();
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error while parsing IPAddress String to Byte: " + e.Message);
                    MessageBox.Show("Fehler bei der Eingabe der Adressen", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (OutOfMemoryException e)
                {
                    MessageBox.Show("Maximal zulässige Anzahl an Adressen überschritten. Das Netzwerk wurde nicht hinzugefügt. Bitte Netzwerk korregieren.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Speicherüberlauf: " + e.Message);
                    GC.Collect();
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Allgemeiner Fehler.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Allgemeiner Fehler: " + e.Message);
                    return;
                }
            }

            UpdateView(false);
        }

        public void GetNotworkInventoryFromDB()
        {
            //set currentNI wirh customers NI from DB
        }

        public void SaveNetworkInventoryToDB()
        {
            //save currentNI to DB
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

        public override void UpdateInformation()
        {//Updates all neccesary properties of the controller (could be caled by a controller who self was caled by this)
        }

        //Converts an IP into an Integer to be able to calculate and compare IPs
        public static UInt32 convertIPtoUInt32(IPAddress ip)
        {
            //use UINt32 to handle overflow correct
            UInt32 convertedIP = 0;
            Byte[] bip = ip.GetAddressBytes();
            //Split IP into Bytes
            UInt32 byte1 = Convert.ToUInt32(bip[0]);
            UInt32 byte2 = Convert.ToUInt32(bip[1]);
            UInt32 byte3 = Convert.ToUInt32(bip[2]);
            UInt32 byte4 = Convert.ToUInt32(bip[3]);
            //build integer
            convertedIP = (byte1 << 24) | (byte2 << 16) | (byte3 << 8) | byte4;
            return convertedIP;
        }

        public override void SelectedCustomerChanged(Object customer)
        {
            base.SelectedCustomerChanged(customer);
            currentNetworkInventory = null;
            Console.WriteLine("Customer changed successfully: New Customer: {0}", currentCustomer.Name);
            //Get Networkinventor of the customer or create a new one
            foreach (NetworkInventory n in list_networkinventories)
            {
                if (n.Customernumber == currentCustomer.Cnumber)
                {
                    currentNetworkInventory = n;
                    Console.WriteLine("Inventory for customer {0} found", currentCustomer.Name);
                }
            }
            if (currentNetworkInventory == null)
            {
                currentNetworkInventory = CreateNetworkInventory(currentCustomer.Cnumber);
                Console.WriteLine("new NetworkInventory created");
            }
            UpdateView(false);
        }


    }
}
