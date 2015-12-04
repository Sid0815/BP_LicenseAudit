using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetHostIP
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress[] me = Dns.GetHostAddresses("");
            foreach (IPAddress ip in me)
            {   //Prints only IPv4
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    Console.WriteLine(ip.ToString());
                }

            }
            Console.ReadKey();
        }
    }
}
