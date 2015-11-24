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
        private NetworkInventory currentNetworkInventory;
        private Network currentNetwork;
        private int inputtype=0;

        //constructor
        public ControllerNetwork(ControllerParent calling, FormNetwork view, ArrayList list_customers):base(calling)
        {
            //connect controller to its view
            this.view = view;
            this.list_customers = list_customers;
        }

        //functions
        private void calcAddresses()
        {

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
                        Console.WriteLine("Error while parsing IPAddress String to Byte: "+e.Message);
                        MessageBox.Show("Fehler bei der Eingabe der Adressen", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    
                    break;
                //Host
                case 2:
                    break;
                //Cidr
                case 3:
                    break;

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
        }

        public override void UpdateInformation()
        {//Updates all neccesary properties of the controller (could be caled by a controller who self was caled by this)
        }

    }
}
