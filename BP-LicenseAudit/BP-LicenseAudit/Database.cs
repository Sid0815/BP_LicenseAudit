using BP_LicenseAudit.Model;
using System.IO;
using System;
using System.Collections;

namespace BP_LicenseAudit
{
    public class Database
    {
        private string pathCustomer = "customers.txt";
        private string pathNetwork = "networks.txt";
        private string pathNetworkInventory = "NI.txt";
        private string pathLicense = "license.txt";
        private string pathLicenseInventory = "LI.txt";

        public void SaveCustomer(Customer c)
        {
            //If File doesn't exist create it
            if (!File.Exists(pathCustomer))
            {
                File.Create(pathCustomer);
            }
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
            //If File doesn't exist create it
            if (!File.Exists(pathCustomer))
            {
                File.Create(pathCustomer);
                return new ArrayList();
            }
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
                return null;
            }
        }

    }
}
