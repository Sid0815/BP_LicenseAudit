using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;

namespace TestPing
{
    class Program
    {
        static void Main(string[] args)
        {
            Byte[] ip = new Byte[4];
            ip[0] = 0;
            ip[1] = 0;
            ip[2] = 0;
            ip[3] = 0;
            IPAddress testIP = new IPAddress(ip);
            Console.WriteLine(testIP.ToString());

            //test incrementing
            Console.WriteLine("Test incrementing:");
            IPAddress y = testIP;
            
            for (int i =0; i<100000; i++)
            {
                y = IncrementIP(y);
                Console.WriteLine(y.ToString());
            }

            
            //testIP = IPAddress.Parse("123123123");
            Console.WriteLine();
            //Pause
            String x = Console.ReadLine();  
        }

        public static IPAddress IncrementIP (IPAddress ip)
        {   
            //use UINt32 to handle overflow correct
            UInt32 convertedIP=0;
            Byte[] bip = ip.GetAddressBytes();
            //Split IP into Bytes
            UInt32 byte1 = Convert.ToUInt32(bip[0]);
            UInt32 byte2 = Convert.ToUInt32(bip[1]);
            UInt32 byte3 = Convert.ToUInt32(bip[2]);
            UInt32 byte4 = Convert.ToUInt32(bip[3]);
            //build integer
            convertedIP = (byte1 << 24) | (byte2 << 16) | (byte3 << 8) | byte4;
            //Console.WriteLine("ConvertedIP: " + convertedIP);
            //increment IP
            convertedIP++;
            //convert Integer back to IP Address
            IPAddress i = IPAddress.Parse(Convert.ToString(convertedIP));
            //Console.WriteLine("Incremented IP: "+i.ToString());
            return i;
        }

        public static void ping (IPAddress ip)
        {
            // Ping's the ip address
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(ip);

            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Address: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
            }
            else
            {
                Console.WriteLine(reply.Status);
            }
        }
    }
}
