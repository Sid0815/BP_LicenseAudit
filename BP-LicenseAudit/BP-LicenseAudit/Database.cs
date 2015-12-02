﻿using BP_LicenseAudit.Model;
using System.IO;
using System;
using System.Collections;
using System.Net;

namespace BP_LicenseAudit
{
    public class Database
    {
        private string pathCustomer = "..\\..\\customers.txt";
        private string pathNetwork = "..\\..\\networks.txt";
        private string pathNetworkInventory = "..\\..\\NI.txt";
        private string pathLicenses = "..\\..\\licenses.txt";
        private string pathLicenseInventory = "..\\..\\LI.txt";

        private void checkFile(string path)
        {
            //If File doesn't exist create it
            if (!File.Exists(path))
            {
                Console.WriteLine("File {0} not found, creating it", path);
                File.Create(path).Close();
            }
        }

        public void SaveCustomer(Customer c)
        {
            //If File doesn't exist create it
            checkFile(pathCustomer);
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
            //If File doesn't exist create it
            checkFile(pathCustomer);
            //GetCustomers
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
            //If File doesn't exist create it
            checkFile(pathLicenses);
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
                    Console.WriteLine("License {0}, {1} added to list", l.LicenseNumber, l.Name);
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
            //If File doesn't exist create it
            checkFile(pathNetwork);
            //Save networks
            Console.WriteLine("Database.SaveNetworks called");
            try
            {
                FileStream fs = new FileStream(pathNetwork, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                string towrite;
                towrite = String.Format("{0};{1};{2};{3}", n.NetworkNumber, n.Name, n.InputType, n.IpAddresses.Count);
                Console.WriteLine(towrite);
                sw.WriteLine(towrite);
                for (int i = 0; i < n.IpAddresses.Count; i++)
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
            //If File doesn't exist create it
            checkFile(pathNetwork);
            //Get networks
            Console.WriteLine("Database.GetNetworks called");
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
                    for (int x = 0; x < i; x++)
                    {
                        read = sr.ReadLine();
                        n.IpAddresses.Add(IPAddress.Parse(read));
                        //Console.WriteLine("IPAdresse hinzugefügt: {0}", IPAddress.Parse(read).ToString());
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

        public void SaveNetworkInventories(ArrayList list_networkinventories)
        {
            //If File doesn't exist create it
            checkFile(pathNetworkInventory);
            //Save NetworkInventory
            Console.WriteLine("Database.SaveNetworkInventory called");
            try
            {
                FileStream fs = new FileStream(pathNetworkInventory, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                //to avoid inconsistency write all inventories each time
                foreach (NetworkInventory ni in list_networkinventories)
                {
                    string towrite;
                    //Customernumber;Networkinventorynumber;Number of Networks
                    //Networknumber
                    //Networknumber
                    //...
                    towrite = String.Format("{0};{1};{2}", ni.Customernumber, ni.NetworkInventoryNumber, ni.List_networks.Count);
                    Console.WriteLine(towrite);
                    sw.WriteLine(towrite);
                    //Write belonging Network Numbers
                    for (int i = 0; i < ni.List_networks.Count; i++)
                    {
                        Network n = (Network)ni.List_networks[i];
                        towrite = String.Format("{0}", n.NetworkNumber);
                        sw.WriteLine(towrite);
                    }
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing File: {0}", e.Message);
            }
        }

        public ArrayList GetNetworkInventories()
        {
            //If File doesn't exist create it
            checkFile(pathNetworkInventory);
            //Get networks
            Console.WriteLine("Database.GetNetworkInventories called");
            try
            {
                FileStream fs = new FileStream(pathNetworkInventory, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string read;
                ArrayList list_networkinventories = new ArrayList();
                ArrayList list_networks = GetNetworks();
                while (sr.Peek() != -1)
                {
                    read = sr.ReadLine();
                    string[] input = read.Split(';');
                    NetworkInventory ni = new NetworkInventory(int.Parse(input[0]), int.Parse(input[1]), new ArrayList());
                    int i = int.Parse(input[2]);
                    for (int x = 0; x < i; x++)
                    {
                        read = sr.ReadLine();
                        //find networks to add them to the Networkinventory's List of networks
                        foreach (Network n in list_networks)
                        {
                            if (n.NetworkNumber == int.Parse(read))
                            {
                                ni.AddNetwork(n);
                                Console.WriteLine("Netzwerk {0} zu NetzwerkInventory {1} hinzugefügt.", n.NetworkNumber, ni.NetworkInventoryNumber);
                            }
                        }

                    }
                    list_networkinventories.Add(ni);
                    Console.WriteLine("NetworkInventory {0} added to list", ni.NetworkInventoryNumber);
                }
                sr.Close();
                return list_networkinventories;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading Network Inventories: {0}", e.Message);
                return null;
            }
        }

        public void SaveLicenseInventories(ArrayList list_licenseinventories)
        {
            //If File doesn't exist create it
            checkFile(pathLicenseInventory);
            //Save NetworkInventory
            Console.WriteLine("Database.SaveLicenseInventory called");
            try
            {
                FileStream fs = new FileStream(pathLicenseInventory, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                //to avoid inconsistency write all inventories each time
                foreach (LicenseInventory li in list_licenseinventories)
                {
                    string towrite;
                    //Customernumber;Licenseinventorynumber;Number of tuples in inventory
                    //Licensenumber;Count
                    //Licensenumber;Count
                    //...
                    towrite = String.Format("{0};{1};{2}", li.Customernumber, li.LicenseInventoryNumber, li.Inventory.Count);
                    Console.WriteLine(towrite);
                    sw.WriteLine(towrite);
                    //Write belonging tuples
                    for (int i = 0; i < li.Inventory.Count; i++)
                    {
                        Tuple<int, int> t = (Tuple<int, int>)li.Inventory[i];
                        towrite = String.Format("{0};{1}", t.Item1, t.Item2);
                        sw.WriteLine(towrite);
                    }
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing License Inventory: {0}", e.Message);
            }
        }

        public ArrayList GetLicenseInventories()
        {
            //If File doesn't exist create it
            checkFile(pathLicenseInventory);
            //Get License Inventories
            Console.WriteLine("Database.GetLicenseInventories called");
            try
            {
                FileStream fs = new FileStream(pathLicenseInventory, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string read;
                ArrayList list_licenseinventories = new ArrayList();
                ArrayList list_licenses = GetLicenses();
                while (sr.Peek() != -1)
                {
                    read = sr.ReadLine();
                    string[] input = read.Split(';');
                    LicenseInventory li = new LicenseInventory(int.Parse(input[0]), int.Parse(input[1]));
                    int i = int.Parse(input[2]);
                    for (int x = 0; x < i; x++)
                    {   
                        //add tuples to license Inventory
                        read = sr.ReadLine();
                        input = read.Split(';');
                        Tuple<int, int> t = new Tuple<int, int>(int.Parse(input[0]), int.Parse(input[1]));
                        li.Inventory.Add(t);
                        Console.WriteLine("Lizenz {0} zu LizenzInventory {1} hinzugefügt.", t.Item1, li.LicenseInventoryNumber);
                    }
                    list_licenseinventories.Add(li);
                    Console.WriteLine("LicenseInventory {0} added to list", li.LicenseInventoryNumber);
                }
                sr.Close();
                return list_licenseinventories;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading Network Inventories: {0}", e.Message);
                return null;
            }
        }
    }
}
