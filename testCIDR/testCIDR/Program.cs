using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace testCIDR
{
    class Program
    {
        static void Main(string[] args)
        {
            Byte[] ip = new Byte[4];
            ip[0] = 192;
            ip[1] = 168;
            ip[2] = 1;
            ip[3] = 2;
            int cidr = 30;
            UInt32 subnetmask;
            IPAddress testIP = new IPAddress(ip);
            Console.WriteLine("Calculation the adresses for {0}/{1}", testIP.ToString(), cidr);
            UInt32 convertedIP = 0;
            UInt32 network = 0;
            UInt32 broadcast = 0;
            Byte[] bip = testIP.GetAddressBytes();
            //Split IP into Bytes
            UInt32 byte1 = Convert.ToUInt32(bip[0]);
            UInt32 byte2 = Convert.ToUInt32(bip[1]);
            UInt32 byte3 = Convert.ToUInt32(bip[2]);
            UInt32 byte4 = Convert.ToUInt32(bip[3]);
            convertedIP = (byte1 << 24) | (byte2 << 16) | (byte3 << 8) | byte4;
            //get subnetmask by shifting and building the complement
            if (cidr == 32) subnetmask = 0xffffffff;
            else subnetmask = ~(0xffffffff >> cidr);
            Console.WriteLine("Subnetmask: " + subnetmask);
            IPAddress ipsubnetmask = IPAddress.Parse(Convert.ToString(subnetmask));
            Console.WriteLine("Subnetmask: " + ipsubnetmask.ToString());
            network = convertedIP & subnetmask;
            Console.WriteLine("Network: " + network);
            IPAddress ipnw = IPAddress.Parse(Convert.ToString(network));
            Console.WriteLine("Network: " + ipnw.ToString());
            broadcast = (network & subnetmask) | ~subnetmask;
            Console.WriteLine("Broadcast: " + broadcast);
            IPAddress ipend = IPAddress.Parse(Convert.ToString(broadcast));
            Console.WriteLine("Broadcast: " + ipend.ToString());
            Console.ReadLine();




        }
    }
}
