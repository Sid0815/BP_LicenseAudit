using System;
using System.Management;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWMI2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                String host, user, password = "";
                //INPUT
                //Hostname
                Console.WriteLine("Bitte Hostname eingeben:");
                host = Console.ReadLine();
                //Username
                Console.WriteLine("Bitte Benutzer eingeben:");
                user = Console.ReadLine();
                //Password
                Console.WriteLine("Bitte Passwort eingeben:");
                ConsoleKeyInfo info = Console.ReadKey(true);
                while (info.Key != ConsoleKey.Enter)
                {
                    if (info.Key != ConsoleKey.Backspace)
                    {
                        password += info.KeyChar;
                        info = Console.ReadKey(true);
                    }
                    else if (info.Key == ConsoleKey.Backspace)
                    {
                        if (!string.IsNullOrEmpty(password))
                        {
                            password = password.Substring
                            (0, password.Length - 1);
                        }
                        info = Console.ReadKey(true);
                    }
                }
                Console.WriteLine();
                //Connect via WMI
                ConnectionOptions options =
                new ConnectionOptions();
                options.Username = user;
                options.Password = password;
                //options.Authority = "ntdlmdomain:bpade.local";
                //options.Authentication = AuthenticationLevel.PacketPrivacy;
                ManagementScope scope;
                //Localhost don't need credentials
                if (host.Equals("localhost", StringComparison.InvariantCultureIgnoreCase) || host.Equals(Dns.GetHostName(), StringComparison.InvariantCultureIgnoreCase)) scope = new ManagementScope("\\\\" + host + "\\root\\cimv2");
                else scope = new ManagementScope("\\\\" + host + "\\root\\cimv2", options);
                scope.Connect();
                ObjectQuery query = new ObjectQuery(
               "SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject m in queryCollection)
                {
                    // Display the remote computer information
                    Console.WriteLine("Computer Name : {0}",
                        m["csname"]);
                    Console.WriteLine("Windows Directory : {0}",
                        m["WindowsDirectory"]);
                    Console.WriteLine("Operating System: {0}",
                        m["Caption"]);
                    Console.WriteLine("Version: {0}", m["Version"]);
                    Console.WriteLine("Manufacturer : {0}",
                        m["Manufacturer"]);
                    Console.WriteLine("SerialNumber : {0}",
                        m["SerialNumber"]);
                    Console.WriteLine("OSType : {0}",
                        m["OSType"]);
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            string x = Console.ReadLine();
            }
        }
    }

