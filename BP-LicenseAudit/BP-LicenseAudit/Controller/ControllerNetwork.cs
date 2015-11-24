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
        private int inputtype=0;

        //constructor
        public ControllerNetwork(ControllerParent calling, FormNetwork view, ArrayList list_customers, ArrayList list_networks, ArrayList list_networkinventories) :base(calling)
        {
            //connect controller to its view
            this.view = view;
            this.list_customers = list_customers;
            this.list_networks = list_networks;
            this.list_networkinventories = list_networkinventories;
        }

        //functions
        private ArrayList calcAddressesSE(IPAddress start, IPAddress end)
        {
            ArrayList addresses = new ArrayList();
            addresses.Add(start);
            //view.AddNetwork(start.ToString());
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
                //view.AddNetwork(start.ToString());
            }
            return addresses;
        }

        private ArrayList calcAddressesCidr(IPAddress network, byte cidr)
        {
            ArrayList addresses = new ArrayList();

            return addresses;
        }

        public void CreateNetworkInventory()
        {

        }

        public void AddNetworkToInventory()
        {
            inputtype = view.GetInputtype();
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
                        try
                        {
                            //Checks automaticaly for right value by its type and by converting
                            b_startaddress[0] = Convert.ToByte(str_startaddress[0]);
                            b_startaddress[1] = Convert.ToByte(str_startaddress[1]);
                            b_startaddress[2] = Convert.ToByte(str_startaddress[2]);
                            b_startaddress[3] = Convert.ToByte(str_startaddress[3]);
                            b_endaddress[0] = Convert.ToByte(str_endaddress[0]);
                            b_endaddress[1] = Convert.ToByte(str_endaddress[1]);
                            b_endaddress[2] = Convert.ToByte(str_endaddress[2]);
                            b_endaddress[3] = Convert.ToByte(str_endaddress[3]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error while parsing IPAddress String to Byte: " + e.Message);
                            MessageBox.Show("Fehler bei der Eingabe der Adressen", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
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
                        list_networks.Add(new Network(list_networks.Count,
                                                        String.Format("{0} - {1}", start.ToString(), end.ToString()),
                                                        inputtype,
                                                        calcAddressesSE(start, end)));
                        view.AddNetwork(String.Format("{0} - {1}", start.ToString(), end.ToString()));
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
                        try
                        {
                            //Checks automaticaly for right value by its type and by converting
                            b_hostaddress[0] = Convert.ToByte(str_hostaddress[0]);
                            b_hostaddress[1] = Convert.ToByte(str_hostaddress[1]);
                            b_hostaddress[2] = Convert.ToByte(str_hostaddress[2]);
                            b_hostaddress[3] = Convert.ToByte(str_hostaddress[3]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error while parsing IPAddress String to Byte: " + e.Message);
                            MessageBox.Show("Fehler bei der Eingabe der Adressen", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        IPAddress host = new IPAddress(b_hostaddress);
                        ArrayList addresses = new ArrayList();
                        addresses.Add(host);
                        list_networks.Add(new Network(list_networks.Count,
                                                        host.ToString(),
                                                        inputtype,
                                                        addresses));
                        view.AddNetwork(host.ToString());
                        break;
                    }
                    
                //Cidr
                case 3:
                    {
                        //Get Address-Bytes as string
                        string[] str_cidraddress = new string[5];
                        str_cidraddress = view.GetCidrAddress();
                        //Convert into byte
                        Byte[] b_cidraddress = new Byte[3];
                        byte cidr=0;
                        try
                        {
                            //Checks automaticaly for right value by its type and by converting
                            b_cidraddress[0] = Convert.ToByte(str_cidraddress[0]);
                            b_cidraddress[1] = Convert.ToByte(str_cidraddress[1]);
                            b_cidraddress[2] = Convert.ToByte(str_cidraddress[2]);
                            b_cidraddress[3] = Convert.ToByte(str_cidraddress[3]);
                            cidr = Convert.ToByte(str_cidraddress[4]);
                            if (cidr > 32) throw new Exception();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error while parsing IPAddress String to Byte: " + e.Message);
                            MessageBox.Show("Fehler bei der Eingabe der Adressen", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        //Creating and adding network
                        IPAddress network = new IPAddress(b_cidraddress);
                        list_networks.Add(new Network(list_networks.Count,
                                                        String.Format("{0} // {1}", network.ToString(), cidr.ToString()),
                                                        inputtype,
                                                        calcAddressesCidr(network, cidr)));
                        view.AddNetwork(String.Format("{0} // {1}", network.ToString(), cidr.ToString()));

                        break;
                    }
                    
                    

                default:
                    Console.WriteLine("Unknown Inputtype");
                    break;
            }
                

        }

        public void GetNotworkInventoryFromDB()
        {
            //set currentNI wirh customers NI from DB
        }

        public void SaveNetworkInventoryToDB()
        {
            //save currentNI to DB
        }

        public override void UpdateView()
        {
            //Customer
            foreach (Customer c in list_customers)
            {
                view.AddCustomer(c.Name);
            }
            //Networks
            //Show all networks belonging to the customer with the cnr = index of selected element cmbCustomer
        }

        public override void UpdateInformation()
        {//Updates all neccesary properties of the controller (could be caled by a controller who self was caled by this)
        }

        //Converts an IP into an Integer to be able to calculate and compare IPs
        private UInt32 convertIPtoUInt32(IPAddress ip)
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



        }
}
