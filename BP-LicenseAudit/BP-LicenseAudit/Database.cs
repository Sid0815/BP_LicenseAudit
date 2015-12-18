﻿using BP_LicenseAudit.Model;
using System.IO;
using System;
using System.Collections;
using System.Net;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BP_LicenseAudit
{
    public class Database
    {
        private string pathCustomer = "..\\..\\customers.txt";
        private string pathNetwork = "..\\..\\networks.txt";
        private string pathNetworkInventory = "..\\..\\NI.txt";
        private string pathLicenses = "..\\..\\licenses.txt";
        private string pathLicenseInventory = "..\\..\\LI.txt";
        private string pathClientSystems = "..\\..\\clientsystems.txt";
        private string pathSystemInventory = "..\\..\\SI.txt";
        private string pathAudit = "..\\..\\Audit.txt";
        private string dbpath = "..\\..\\BPLicenseAudit.sqlite";
        private SQLiteConnection connection;
        private SQLiteCommand command;

        public Database()
        {
            if (!File.Exists(dbpath))
            {
                SQLiteConnection.CreateFile(dbpath);
            }
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
                connection.Open();
                //Console.WriteLine("Database opend");
                command = new SQLiteCommand(connection);
                //Create Table Customer if it does not exist
                command.CommandText = "CREATE TABLE IF NOT EXISTS customer ( customerNumber INTEGER NOT NULL PRIMARY KEY, name VARCHAR(200) NOT NULL, street VARCHAR(200) NOT NULL, streetnumber VARCHAR(10) NOT NULL, city VARCHAR(100) NOT NULL, zip VARCHAR(10) NOT NULL);";
                command.ExecuteNonQuery();
                //Create Table License if it does not exist
                command.CommandText = "CREATE TABLE IF NOT EXISTS license ( licenseNumber INTEGER NOT NULL PRIMARY KEY, name VARCHAR(200) NOT NULL);";
                command.ExecuteNonQuery();
                //Create Table Network if it does not exist
                command.CommandText = "CREATE TABLE IF NOT EXISTS network ( networkNumber INTEGER NOT NULL PRIMARY KEY, name VARCHAR(40) NOT NULL, inputtype INTEGER NOT NULL, networkInventoryNumber INTEGER NOT NULL, FOREIGN KEY(networkInventoryNumber) REFERENCES networkinventory(networkInventoryNumber));";
                command.ExecuteNonQuery();
                //Create Table IPaddress if it does not exist
                command.CommandText = "CREATE TABLE IF NOT EXISTS ipaddresses ( ipaddress VARCHAR(20) NOT NULL PRIMARY KEY);";
                command.ExecuteNonQuery();
                //Create Table NetworkIPaddress if it does not exist (n:m network:ipaddress)
                command.CommandText = "CREATE TABLE IF NOT EXISTS networkipadress ( networkNumber INTEGER, ipaddress VARCHAR(20) NOT NULL, PRIMARY KEY (networkNumber, ipaddress), FOREIGN KEY(networkNumber) REFERENCES network(networkNumber), FOREIGN KEY(ipaddress) REFERENCES ipaddresses(ipaddress));";
                command.ExecuteNonQuery();
                //Create Table ClientSystem if it does not exist
                command.CommandText = "CREATE TABLE IF NOT EXISTS clientsystem ( clientSystemNumber INTEGER NOT NULL PRIMARY KEY, networknumber INTEGER  NOT NULL, computername VARCHAR(200), type VARCHAR(200), serial VARCHAR(200), clientIP VARCHAR(20) NOT NULL, FOREIGN KEY(networknumber) REFERENCES network(networkNumber), FOREIGN KEY(clientIP) REFERENCES ipaddresses(ipaddress)); ";
                command.ExecuteNonQuery();
                //Create Table LicenseInventory if it does not exist
                command.CommandText = "CREATE TABLE IF NOT EXISTS licenseinventory ( licenseInventoryNumber INTEGER NOT NULL PRIMARY KEY, customerNumber INTEGER NOT NULL, FOREIGN KEY(customerNumber) REFERENCES customer(customerNumber)); ";
                command.ExecuteNonQuery();
                //Create Table containsLicense if it does not exist(n:m licenseinventory:license)
                command.CommandText = "CREATE TABLE IF NOT EXISTS containsLicense ( licenseInventoryNumber INTEGER NOT NULL, licenseNumber INTEGER NOT NULL, count INTEGER NOT NULL, PRIMARY KEY (licenseInventoryNumber, licenseNumber), FOREIGN KEY(licenseInventoryNumber) REFERENCES licenseinventory(licenseInventoryNumber), FOREIGN KEY(licenseNumber) REFERENCES license(licenseNumber)); ";
                command.ExecuteNonQuery();
                //Create Table NetworkInventory if it does not exist
                command.CommandText = "CREATE TABLE IF NOT EXISTS networkinventory ( networkInventoryNumber INTEGER NOT NULL PRIMARY KEY, customerNumber INTEGER NOT NULL, FOREIGN KEY(customerNumber) REFERENCES customer(customerNumber)); ";
                command.ExecuteNonQuery();
                //Create Table SystemInventory if it does not exist
                command.CommandText = "CREATE TABLE IF NOT EXISTS systeminventory ( systemInventoryNumber INTEGER NOT NULL PRIMARY KEY, customerNumber INTEGER NOT NULL, date DATETIME NOT NULL, FOREIGN KEY(customerNumber) REFERENCES customer(customerNumber)); ";
                command.ExecuteNonQuery();
                //Create Table containsSystem if it does not exist(n:m systeminventory:clientsystem)
                command.CommandText = "CREATE TABLE IF NOT EXISTS containsSystem ( systemInventoryNumber INTEGER NOT NULL, clientSystemNumber INTEGER NOT NULL, PRIMARY KEY (systemInventoryNumber, clientSystemNumber), FOREIGN KEY(systemInventoryNumber) REFERENCES systeminventory(systemInventoryNumber), FOREIGN KEY(clientSystemNumber) REFERENCES clientsystem(clientSystemNumber)); ";
                command.ExecuteNonQuery();
                //Create Table Audit if it does not exist
                command.CommandText = "CREATE TABLE IF NOT EXISTS audit ( auditNumber INTEGER NOT NULL PRIMARY KEY, customerNumber INTEGER NOT NULL, systemInventoryNumber INTEGER NOT NULL, date DATETIME NOT NULL, FOREIGN KEY(customerNumber) REFERENCES customer(customerNumber), FOREIGN KEY(systemInventoryNumber) REFERENCES systeminventory(systemInventoryNumber)); ";
                command.ExecuteNonQuery();
                //Create Table Results if it does not exist(n:m audit:license)
                command.CommandText = "CREATE TABLE IF NOT EXISTS results ( auditNumber INTEGER NOT NULL, licenseNumber INTEGER NOT NULL, result INTEGER NOT NULL, PRIMARY KEY (auditNumber, licenseNumber), FOREIGN KEY(auditNumber) REFERENCES audit(auditNumber), FOREIGN KEY(licenseNumber) REFERENCES license(licenseNumber)); ";
                command.ExecuteNonQuery();
                //Console.WriteLine("Tables checked or created");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Creation", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            connection.Close();
            //Console.WriteLine("Database closed");

        }

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
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO customer (customerNumber, name, street, streetnumber, city, zip) VALUES(@customerNumber, @name, @street, @streetnumber, @city, @zip);";
                command.Parameters.AddWithValue("@customerNumber", c.Cnumber);
                command.Parameters.AddWithValue("@name", c.Name);
                command.Parameters.AddWithValue("@street", c.Street);
                command.Parameters.AddWithValue("@streetnumber", c.Streetnumber);
                command.Parameters.AddWithValue("@city", c.City);
                command.Parameters.AddWithValue("@zip", c.Zip);
                int affectedRows = command.ExecuteNonQuery();
                Console.WriteLine(command.ToString());
                Console.WriteLine("Affected Rows: {0}", affectedRows);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Write Customer", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }

        public void UpdateCustomer(Customer c)
        {
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "UPDATE customer SET name=@name, street=@street, streetnumber=@streetnumber, city=@city, zip=@zip WHERE customerNumber=@cnr ;";
                command.Parameters.AddWithValue("@cnr", c.Cnumber);
                command.Parameters.AddWithValue("@name", c.Name);
                command.Parameters.AddWithValue("@street", c.Street);
                command.Parameters.AddWithValue("@streetnumber", c.Streetnumber);
                command.Parameters.AddWithValue("@city", c.City);
                command.Parameters.AddWithValue("@zip", c.Zip);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Change Customer", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }

        public ArrayList GetCustomers()
        {
            ArrayList list_customers = new ArrayList();
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM customer;";
                SQLiteDataReader r = command.ExecuteReader();
                while (r.Read())
                {
                    list_customers.Add(new Customer(r.GetInt32(0), (string)r["name"], (string)r["street"], (string)r["streetnumber"], (string)r["city"], (string)r["zip"]));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Reading Customers", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return list_customers;
        }

        public void SaveLicense(License l)
        {
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO license (licenseNumber, name) VALUES(@licenseNumber, @name);";
                command.Parameters.AddWithValue("@customerNumber", l.LicenseNumber);
                command.Parameters.AddWithValue("@name", l.Name);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Write License", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }

        public ArrayList GetLicenses()
        {
            ArrayList list_licenses = new ArrayList();
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM license;";
                SQLiteDataReader r = command.ExecuteReader();
                while (r.Read())
                {
                    list_licenses.Add(new License(r.GetInt32(0), (string)r["name"]));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Reading LicenseTypes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return list_licenses;
        }

        public void SaveNetwork(Network n, NetworkInventory ni)
        {
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO network (networkNumber, name, inputtype, networkInventoryNumber) VALUES(@networkNumber, @name, @inputtype, @networkInventoryNumber);";
                command.Parameters.AddWithValue("@networkNumber", n.NetworkNumber);
                command.Parameters.AddWithValue("@name", n.Name);
                command.Parameters.AddWithValue("@inputtype", n.InputType);
                command.Parameters.AddWithValue("@networkInventoryNumber", ni.NetworkInventoryNumber);
                command.ExecuteNonQuery();
                SQLiteTransaction transaction = connection.BeginTransaction();
                foreach (IPAddress ip in n.IpAddresses)
                {
                    try
                    {//Write IP to table, if it is already there, throw exception
                        command.CommandText = "INSERT INTO ipaddresses (ipaddress) VALUES(@ipaddress);";
                        command.Parameters.AddWithValue("@ipaddress", ip.ToString());
                        command.ExecuteNonQuery();
                        //Console.WriteLine("IPAddress {0} saved to database", ip.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error writing IP to DB: " + e.Message);
                    }
                    try
                    {//Connect ip to netwok in database
                        command.CommandText = "INSERT INTO networkipadress (networkNumber, ipaddress) VALUES(@networkNumber, @ipaddress);";
                        command.Parameters.AddWithValue("@networkNumber", n.NetworkNumber);
                        command.Parameters.AddWithValue("@ipaddress", ip.ToString());
                        command.ExecuteNonQuery();
                        //Console.WriteLine("IPaddress {0} connected to network {1} in database.", ip.ToString(), n.Name);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error writing IP/NW to DB: " + e.Message);
                    }
                }
                transaction.Commit();
                Console.WriteLine("Network {0} saved to database.", n.Name);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Write Network", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }

        public void UpdateNetwork(Network n)
        {
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "UPDATE network SET name=@name, inputtype=@inputtype WHERE networkNumber=@nnr ;";
                command.Parameters.AddWithValue("@nnr", n.NetworkNumber);
                command.Parameters.AddWithValue("@name", n.Name);
                command.Parameters.AddWithValue("@inputtype", n.InputType);
                command.ExecuteNonQuery();
                //drop old ip address connection to this network
                command.CommandText = "DELETE FROM networkipadress WHERE networkNumber=@nnr ;";
                command.Parameters.AddWithValue("@nnr", n.NetworkNumber);
                //Add new ip-Addresses
                SQLiteTransaction transaction = connection.BeginTransaction();
                foreach (IPAddress ip in n.IpAddresses)
                {
                    try
                    {//Write IP to table, if it is already there, throw exception
                        command.CommandText = "INSERT INTO ipaddresses (ipaddress) VALUES(@ipaddress);";
                        command.Parameters.AddWithValue("@ipaddress", ip.ToString());
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error writing IP to DB: " + e.Message);
                    }
                    try
                    {//Connect ip to netwok in database
                        command.CommandText = "INSERT INTO networkipadress (networkNumber, ipaddress) VALUES(@networkNumber, @ipaddress);";
                        command.Parameters.AddWithValue("@networkNumber", n.NetworkNumber);
                        command.Parameters.AddWithValue("@ipaddress", ip.ToString());
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error writing IP/NW to DB: " + e.Message);
                    }
                }
                transaction.Commit();
                Console.WriteLine("Network {0} changed in database.", n.Name);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Write Network", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }

        public void RemoveNetwork(Network n)
        {
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
                connection.Open();
                command = new SQLiteCommand(connection);
                //Delete Network
                command.CommandText = "DELETE FROM network WHERE networkNumber=@nnr ;";
                command.Parameters.AddWithValue("@nnr", n.NetworkNumber);
                command.ExecuteNonQuery();
                //drop old ip addresses
                command.CommandText = "DELETE FROM networkipadress WHERE networkNumber=@nnr ;";
                command.Parameters.AddWithValue("@nnr", n.NetworkNumber);
                command.ExecuteNonQuery();
                Console.WriteLine("Network {0} deleted in database.", n.Name);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Write Network", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }

        public ArrayList GetNetworks()
        {
            ArrayList list_networks = new ArrayList();
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3; MultipleActiveResultSets=True;");
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM network;";
                SQLiteDataReader r = command.ExecuteReader();
                while (r.Read())
                {
                    int networkNumber = r.GetInt32(0);
                    string networkName = (string)r["name"];
                    int inputtype = r.GetInt32(2);
                    ArrayList addresses = new ArrayList();
                    //Get the beloning IP-Addresses of the network
                    SQLiteCommand command2 = new SQLiteCommand(connection);
                    command2.CommandText = "SELECT ipaddress FROM networkipadress WHERE networkNumber=@networkNumber;";
                    command2.Parameters.AddWithValue("@networkNumber", networkNumber);
                    SQLiteDataReader r_inner = command2.ExecuteReader();
                    while (r_inner.Read())
                    {
                        addresses.Add(IPAddress.Parse((string)r_inner["ipaddress"]));
                    }
                    list_networks.Add(new Network(networkNumber, networkName, inputtype, addresses));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Reading Networks", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return list_networks;
        }

        public void SaveNetworkInventory(NetworkInventory ni)
        {
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO networkinventory (networkInventoryNumber, customerNumber) VALUES(@networkInventoryNumber, @customerNumber);";
                command.Parameters.AddWithValue("@networkInventoryNumber", ni.NetworkInventoryNumber);
                command.Parameters.AddWithValue("@customerNumber", ni.Customernumber);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Write NetworkInventory", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }

        public ArrayList GetNetworkInventories()
        {
            ArrayList list_networkinventories = new ArrayList();
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3; MultipleActiveResultSets=True;");
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM networkinventory;";
                SQLiteDataReader r = command.ExecuteReader();
                while (r.Read())
                {
                    int niNumber = r.GetInt32(0);
                    int cNumber = r.GetInt32(1);
                    ArrayList networks = new ArrayList();
                    //Get the beloning networks of the networkinventory
                    SQLiteCommand command2 = new SQLiteCommand(connection);
                    command2.CommandText = "SELECT * FROM network WHERE networkInventoryNumber=@niNumber;";
                    command2.Parameters.AddWithValue("@niNumber", niNumber);
                    SQLiteDataReader r_inner = command2.ExecuteReader();
                    while (r_inner.Read())
                    {
                        int networkNumber = r_inner.GetInt32(0);
                        string networkName = (string)r_inner["name"];
                        int inputtype = r_inner.GetInt32(2);
                        ArrayList addresses = new ArrayList();
                        //Get the beloning IP-Addresses of the network
                        SQLiteCommand command3 = new SQLiteCommand(connection);
                        command3.CommandText = "SELECT ipaddress FROM networkipadress WHERE networkNumber=@networkNumber;";
                        command3.Parameters.AddWithValue("@networkNumber", networkNumber);
                        SQLiteDataReader r_inner_inner = command3.ExecuteReader();
                        while (r_inner_inner.Read())
                        {
                            addresses.Add(IPAddress.Parse((string)r_inner_inner["ipaddress"]));
                        }//END IP
                        networks.Add(new Network(networkNumber, networkName, inputtype, addresses));
                    }//END N
                    list_networkinventories.Add(new NetworkInventory(cNumber, niNumber, networks));
                }//END NI
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Reading NetworkInventories", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return list_networkinventories;

        }

        public void SaveLicenseInventory(LicenseInventory li)
        {
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO licenseinventory (licenseInventoryNumber, customerNumber) VALUES(@licenseInventoryNumber, @customerNumber);";
                command.Parameters.AddWithValue("@licenseInventoryNumber", li.LicenseInventoryNumber);
                command.Parameters.AddWithValue("@customerNumber", li.Customernumber);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Update LicenseInventory", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }

        public void UpdateLicenseInventory(LicenseInventory li, License l, int count)
        {
            bool update = false;
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
                connection.Open();
                command = new SQLiteCommand(connection);
                try
                {
                    command.CommandText = "INSERT INTO containsLicense (licenseInventoryNumber, licenseNumber, count) VALUES(@licenseInventoryNumber, @licenseNumber, @count);";
                    command.Parameters.AddWithValue("@licenseInventoryNumber", li.LicenseInventoryNumber);
                    command.Parameters.AddWithValue("@licenseNumber", l.LicenseNumber);
                    command.Parameters.AddWithValue("@count", count);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Lizenz war noch nicht im Inventory");
                }
                catch (SQLiteException e)
                {
                    //Tuple alreeady in table
                    update = true;
                    Console.WriteLine("License already in invnetory, update it");
                }
                if (update)
                {
                    command.CommandText = "UPDATE containsLicense SET count=@count WHERE licenseInventoryNumber=@licenseInventoryNumber AND  licenseNumber=@licenseNumber ;";
                    command.Parameters.AddWithValue("@licenseInventoryNumber", li.LicenseInventoryNumber);
                    command.Parameters.AddWithValue("@licenseNumber", l.LicenseNumber);
                    command.Parameters.AddWithValue("@count", count);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Lizenz aktualisiert");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Update LicenseInventory", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }

        public ArrayList GetLicenseInventories()
        {
            ArrayList list_licenseinventories = new ArrayList();
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM licenseinventory;";
                SQLiteDataReader r = command.ExecuteReader();
                while (r.Read())
                {
                    LicenseInventory currentLicensInvnetory = new LicenseInventory(r.GetInt32(1), r.GetInt32(0));
                    //Get Licenses of the inventory
                    SQLiteCommand command2 = new SQLiteCommand(connection);
                    command2.CommandText = "SELECT * FROM containslicense WHERE licenseInventoryNumber=@licenseInventoryNumber;";
                    command2.Parameters.AddWithValue("@licenseInventoryNumber", currentLicensInvnetory.LicenseInventoryNumber);
                    SQLiteDataReader r_inner = command2.ExecuteReader();
                    while (r_inner.Read())
                    {
                        currentLicensInvnetory.AddLicenseToInventory(r_inner.GetInt32(1), r_inner.GetInt32(2));
                    }
                    list_licenseinventories.Add(currentLicensInvnetory);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Reading LicenseInventory", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            return list_licenseinventories;
        }

        public void SaveClientSystem(ClientSystem c)
        {
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO clientsystem (clientSystemNumber, networknumber, computername, type, serial, clientIP) VALUES(@clientSystemNumber, @networknumber, @computername, @type, @serial, @clientIP);";
                command.Parameters.AddWithValue("@clientSystemNumber", c.ClientSystemNumber);
                command.Parameters.AddWithValue("@networknumber", c.Networknumber);
                command.Parameters.AddWithValue("@computername", c.Computername);
                command.Parameters.AddWithValue("@type", c.Type);
                command.Parameters.AddWithValue("@serial", c.Serial);
                command.Parameters.AddWithValue("@clientIP", c.ClientIP.ToString());
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Write Clientsystem", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }

        public void UpdateClientSystem(ClientSystem c)
        {
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "UPDATE clientsystem SET computername=@computername, computername=@computername, type=@type, serial=@serial WHERE clientSystemNumber=@clientSystemNumber ;";
                command.Parameters.AddWithValue("@clientSystemNumber", c.ClientSystemNumber);
                command.Parameters.AddWithValue("@computername", c.Computername);
                command.Parameters.AddWithValue("@type", c.Type);
                command.Parameters.AddWithValue("@serial", c.Serial);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Update ClientSystem", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }

        public ArrayList GetClientSystems()
        {
            ArrayList list_ClientSystems = new ArrayList();
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM clientsystem;";
                SQLiteDataReader r = command.ExecuteReader();
                while (r.Read())
                {
                    ClientSystem c = new ClientSystem(r.GetInt32(0), IPAddress.Parse((string)r["clientIP"]), r.GetInt32(1));
                    string type = (string)r["type"];
                    if (type != null && !(type.Equals("")))
                    {
                        c.Type = type;
                        c.Computername= (string)r["computername"];
                        c.Serial = (string)r["serial"];
                    }
                    else
                    {
                        c.Type = null;
                        c.Computername = null;
                        c.Serial = null;
                    }
                    list_ClientSystems.Add(c);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error SQL Reading Customers", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return list_ClientSystems;


        }

        public void SaveSystemInventoriesOverride(ArrayList list_systeminventories)
        {
            //If File doesn't exist create it
            checkFile(pathSystemInventory);
            //Save SystemInventory
            Console.WriteLine("Database.SaveSystemInventoryOverride called");
            try
            {
                FileStream fs = new FileStream(pathSystemInventory, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                //to avoid inconsistency write all inventories each time
                foreach (SystemInventory si in list_systeminventories)
                {
                    string towrite;
                    //Customernumber;Systeminventorynumber;Number of ClientSystems in inventory, date
                    //Clientsystemnumber
                    //Clientsystemnumber
                    //...
                    towrite = String.Format("{0};{1};{2};{3}", si.Customernumber, si.SystemInventoryNumber, si.List_Systems.Count, si.Date);
                    Console.WriteLine(towrite);
                    sw.WriteLine(towrite);
                    //Write belonging Clientsystems
                    for (int i = 0; i < si.List_Systems.Count; i++)
                    {
                        ClientSystem c = (ClientSystem)si.List_Systems[i];
                        towrite = String.Format("{0}", c.ClientSystemNumber);
                        sw.WriteLine(towrite);
                    }
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing System Inventory: {0}", e.Message);
            }
        }

        public void SaveSystemInventory(SystemInventory si)
        {
            //If File doesn't exist create it
            checkFile(pathSystemInventory);
            //Save SystemInventory
            Console.WriteLine("Database.SaveSystemInventory called");
            try
            {
                FileStream fs = new FileStream(pathSystemInventory, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                string towrite;
                //Customernumber;Systeminventorynumber;Number of ClientSystems in inventory, date
                //Clientsystemnumber
                //Clientsystemnumber
                //...
                towrite = String.Format("{0};{1};{2};{3}", si.Customernumber, si.SystemInventoryNumber, si.List_Systems.Count, si.Date);
                Console.WriteLine(towrite);
                sw.WriteLine(towrite);
                //Write belonging Clientsystems
                for (int i = 0; i < si.List_Systems.Count; i++)
                {
                    ClientSystem c = (ClientSystem)si.List_Systems[i];
                    towrite = String.Format("{0}", c.ClientSystemNumber);
                    sw.WriteLine(towrite);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing System Inventory: {0}", e.Message);
            }
        }

        public ArrayList GetSystemInventories()
        {
            //If File doesn't exist create it
            checkFile(pathSystemInventory);
            //Get System Inventories
            Console.WriteLine("Database.GetSystemInventories called");
            try
            {
                FileStream fs = new FileStream(pathSystemInventory, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string read;
                ArrayList list_systeminventories = new ArrayList();
                ArrayList list_clientsystems = GetClientSystems();
                while (sr.Peek() != -1)
                {
                    read = sr.ReadLine();
                    string[] input = read.Split(';');
                    SystemInventory si = new SystemInventory(int.Parse(input[0]), int.Parse(input[1]));
                    si.Date = DateTime.Parse(input[3]);
                    int i = int.Parse(input[2]);
                    for (int x = 0; x < i; x++)
                    {
                        //add ClientSystems to System Inventory
                        read = sr.ReadLine();
                        int clientsystemnumber = int.Parse(read);
                        //Console.WriteLine(clientsystemnumber);
                        ClientSystem currentsystem = null;
                        foreach (ClientSystem c in list_clientsystems)
                        {
                            //Console.WriteLine("Comparing ClientSystem {0} against clientsystemnumber", c.ClientSystemNumber);
                            if (c.ClientSystemNumber == clientsystemnumber)
                            {
                                currentsystem = c;
                                Console.WriteLine("Clientsystem {0} found.", currentsystem.ClientSystemNumber);
                                break;
                            }
                            else
                            {
                                currentsystem = null;
                            }
                        }
                        if (currentsystem != null)
                        {
                            si.List_Systems.Add(currentsystem);
                        }
                        Console.WriteLine("ClientSystem {0} zu SystemInventory {1} hinzugefügt.", currentsystem.ClientSystemNumber, si.SystemInventoryNumber);
                    }
                    list_systeminventories.Add(si);
                    Console.WriteLine("SystemInventory {0} added to list", si.SystemInventoryNumber);
                }
                sr.Close();
                return list_systeminventories;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading System Inventories: {0}", e.Message);
                return null;
            }
        }

        public void SaveAudit(Audit a)
        {
            //If File doesn't exist create it
            checkFile(pathAudit);
            //Save Audit
            Console.WriteLine("Database.SaveAudit called");
            try
            {
                FileStream fs = new FileStream(pathAudit, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                string towrite;
                //Auditnumber;Customernumber;Systeminventorynumber;Number of results, date
                //resulttuple
                //resulttuple
                //...
                towrite = String.Format("{0};{1};{2};{3};{4}", a.AuditNumber, a.CustomerNumber, a.SystemInventoryNumber, a.Results.Count, a.Date);
                Console.WriteLine(towrite);
                sw.WriteLine(towrite);
                //Write belonging Results
                for (int i = 0; i < a.Results.Count; i++)
                {
                    Tuple<int, int> t = (Tuple<int, int>)a.Results[i];
                    towrite = String.Format("{0};{1}", t.Item1, t.Item2);
                    sw.WriteLine(towrite);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing Audit: {0}", e.Message);
            }
        }

        public ArrayList GetAudits()
        {
            //If File doesn't exist create it
            checkFile(pathAudit);
            //Get Audits
            Console.WriteLine("Database.GetAudits called");
            try
            {
                FileStream fs = new FileStream(pathAudit, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string read;
                ArrayList list_audits = new ArrayList();
                while (sr.Peek() != -1)
                {
                    read = sr.ReadLine();
                    string[] input = read.Split(';');
                    Audit a = new Audit(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));
                    a.Date = DateTime.Parse(input[4]);
                    int i = int.Parse(input[3]);
                    for (int x = 0; x < i; x++)
                    {
                        //add tuples to results
                        read = sr.ReadLine();
                        input = read.Split(';');
                        Tuple<int, int> t = new Tuple<int, int>(int.Parse(input[0]), int.Parse(input[1]));
                        a.Results.Add(t);
                    }
                    list_audits.Add(a);
                    Console.WriteLine("Audit {0} added to list", a.AuditNumber);
                }
                sr.Close();
                return list_audits;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading Network Inventories: {0}", e.Message);
                return null;
            }
        }
    }
}
