using BP_LicenseAudit.Model;
using System.IO;
using System;
using System.Collections;
using System.Net;

namespace BP_LicenseAudit
{
    public class Database
    {
        private string pathCustomer = "customers.txt";
        private string pathNetwork = "networks.txt";
        private string pathNetworkInventory = "NI.txt";
        private string pathLicenses = "licenses.txt";
        private string pathLicenseInventory = "LI.txt";

        public void SaveCustomer(Customer c)
        {
            //If File doesn't exist create it
            //write file
            try
            {
                FileStream fs = new FileStream(pathCustomer, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                string towrite;
                towrite = String.Format("{0};{1};{2};{3};{4};{5}", c.Cnumber, c.Name, c.Street, c.Streetnumber, c.City, c.Zip);
                Console.WriteLine(towrite);
                sw.WriteLine(towrite);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing File: {0}", e.Message);
            }
        }

        public ArrayList GetCustomers()
        {
            Console.WriteLine("Database.GetCustomers called");
            try
            {
                FileStream fs = new FileStream(pathCustomer, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string read;
                ArrayList list_customers = new ArrayList();
                while (sr.Peek() != -1)
                {
                    read = sr.ReadLine();
                    string[] input;
                    input = read.Split(';');
                    Customer c = new Customer(int.Parse(input[0]), input[1], input[2], input[3], input[4], input[5]);
                    list_customers.Add(c);
                    Console.WriteLine("Customer {0} added to list", c.Cnumber);
                }
                sr.Close();
                return list_customers;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading File: {0}", e.Message);
                return new ArrayList();
            }
        }

        public ArrayList GetLicenses()
        {
            Console.WriteLine("Database.GetLicenseTypes called");
            try
            {
                FileStream fs = new FileStream(pathLicenses, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string read;
                ArrayList list_licenses = new ArrayList();
                while (sr.Peek() != -1)
                {
                    read = sr.ReadLine();
                    string[] input = read.Split(';');
                    License l = new License(int.Parse(input[0]), input[1]);
                    list_licenses.Add(l);
                    Console.WriteLine("License {0} added to list", l.LicenseNumber);
                }
                sr.Close();
                return list_licenses;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading File: {0}", e.Message);
                return new ArrayList();
            }
        }

        public void SaveNetwork(Network n)
        {
            try
            {
                FileStream fs = new FileStream(pathNetwork, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                string towrite;
                towrite = String.Format("{0};{1};{2};{3}", n.NetworkNumber, n.Name, n.InputType, n.IpAddresses.Count);
                Console.WriteLine(towrite);
                sw.WriteLine(towrite);
                for (int i=0; i < n.IpAddresses.Count; i++)
                {
                    towrite = String.Format("{0}", n.IpAddresses[i]);
                    sw.WriteLine(towrite);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing File: {0}", e.Message);
            }
        }

        public ArrayList GetNetworks()
        {
            Console.WriteLine("Database.GetLicenseTypes called");
            try
            {
                FileStream fs = new FileStream(pathNetwork, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string read;
                ArrayList list_networks = new ArrayList();
                while (sr.Peek() != -1)
                {
                    read = sr.ReadLine();
                    string[] input = read.Split(';');
                    Network n = new Network(int.Parse(input[0]), input[1], int.Parse(input[2]), new ArrayList());
                    int i = int.Parse(input[3]);
                    for(int x=0; x<i; x++)
                    {
                        read = sr.ReadLine();
                        n.IpAddresses.Add(IPAddress.Parse(read));
                    }
                    list_networks.Add(n);
                    Console.WriteLine("Network {0} added to list", n.NetworkNumber);
                }
                sr.Close();
                return list_networks;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading File: {0}", e.Message);
                return null;
            }
        }

    }
}
