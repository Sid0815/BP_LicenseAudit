using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace TestPingAsync
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public List<IPAddress> GetNetworks()
        {
            Console.WriteLine("Database.GetNetworks called");
            try
            {
                FileStream fs = new FileStream("..\\..\\networks.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string read;
                List<IPAddress> list_networks = new List<IPAddress>();
                while (sr.Peek() != -1)
                {
                    read = sr.ReadLine();
                    list_networks.Add(IPAddress.Parse(read));
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
