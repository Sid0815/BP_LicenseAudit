using System;
using System.Collections.Generic;
using BP_LicenseAudit.Model;
using BP_LicenseAudit.View;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.Text;

namespace BP_LicenseAudit.Controller
{
    public class ControllerAudit : ControllerParent
    {
        //properties
        private FormAudit view;
        private SystemInventory currentSystemInventory;
        private LicenseInventory currentLicenseInventory;
        private Audit currentAudit;
        private ArrayList list_licenseInventories;
        private ArrayList list_systemInventories;
        private ArrayList list_audits;
        private ArrayList list_allAvailableLicenses;

        //constructor
        public ControllerAudit(ControllerParent calling, FormAudit view, ArrayList list_customers, ArrayList list_licenseinventories, ArrayList list_systeminventories, ArrayList list_audits, ArrayList list_licenses) : base(calling, list_customers)
        {
            //connect controller to its view
            this.view = view;
            this.list_licenseInventories = list_licenseinventories;
            this.list_systemInventories = list_systeminventories;
            this.list_audits = list_audits;
            this.list_allAvailableLicenses = list_licenses;
            currentAudit = null;
            currentLicenseInventory = null;
            currentSystemInventory = null;
        }

        //functions
        public void Compare()
        {
            if (currentCustomer == null)
            {
                MessageBox.Show("Kein Kunde ausgewählt. Bitte einen Kunden auswählen und Audit erneut starten.", "Kein Kunde ausgewählt.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                currentAudit = new Audit(list_audits.Count, currentCustomer.Cnumber);
                //Count Systems
                //
                //get List of system types
                List<string> types = new List<string>();
                foreach (ClientSystem c in currentSystemInventory.List_Systems)
                {
                    //Add  only types of systems with detailed Information and types which aren't in the list already
                    if ((!types.Contains(c.Type)) && (c.Type != null) && !(c.Type.Equals("")))
                    {
                        types.Add(c.Type);
                    }
                }
                //count occurence of types in Systeminventory
                int[] count = new int[types.Count];
                for (int i = 0; i < types.Count; i++)
                {
                    count[i] = 0;
                    foreach (ClientSystem c in currentSystemInventory.List_Systems)
                    {
                        //do this only for systems with detailed information
                        if (c.Type != null && !(c.Type.Equals("")))
                        {
                            if (c.Type.Equals(types[i]))
                            {
                                count[i]++;
                                Console.WriteLine("{0} occures {1} times", types[i], count[i]);
                            }
                        }
                    }
                }
                //Compare against Licennse Inventory
                for (int i = 0; i < types.Count; i++)
                {
                    int licenses = 0;
                    //Get the licensenumber of the current type (if licensetype is known)
                    int licensenumber = -1;
                    foreach (License l in list_allAvailableLicenses)
                    {
                        if (l.Name.Equals(types[i]))
                        {
                            licensenumber = l.LicenseNumber;
                        }
                    }
                    if (licensenumber == -1)
                    {
                        //licensetype unknown, learn it
                        License newlicense = new License(list_allAvailableLicenses.Count, types[i]);
                        list_allAvailableLicenses.Add(newlicense);
                        db.SaveLicense(newlicense);
                        licensenumber = newlicense.LicenseNumber;
                    }
                    //Get the corresponding count of the licensinventory, if the license isn't in the inventory the count is 0 (initialised)
                    for (int x = 0; x < currentLicenseInventory.Inventory.Count; x++)
                    {
                        Tuple<int, int> t = (Tuple<int, int>)currentLicenseInventory.Inventory[x];
                        if (t.Item1 == licensenumber)
                        {
                            licenses = t.Item2;
                            x = currentLicenseInventory.Inventory.Count;
                        }
                    }
                    //Add result to Audit, Licensenumber and number of free licenses of this type
                    currentAudit.AddResult(licensenumber, licenses - count[i]);
                }
                //Add licenses of invetory which aren't already added
                ArrayList helpList = new ArrayList();
                foreach (Tuple<int, int> tuplelicense in currentLicenseInventory.Inventory)
                {
                    bool contains = false;
                    Tuple<int, int> helpTuple = new Tuple<int, int>(-1, -1);
                    foreach (Tuple<int, int> t in currentAudit.Results)
                    {
                        helpTuple = (Tuple<int, int>)t;
                        if (helpTuple.Item1 == tuplelicense.Item1)
                        {
                            contains = true;
                            break;
                        }
                    }
                    if (!contains)
                    {
                        currentAudit.AddResult(tuplelicense.Item1, tuplelicense.Item2);
                    }
                }
                list_audits.Add(currentAudit);
                db.SaveAudit(currentAudit);
                callingController.UpdateInformation();
                MessageBox.Show("Audit abgeschlossen.", "Audit abgeschlossen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateView(false);

        }

        public void PrintResults()
        {
            if (currentAudit != null)
            {
                XmlTextWriter writer = new XmlTextWriter("..\\..\\audit.xml", new UnicodeEncoding());
                writer.WriteStartDocument();
                writer.WriteStartElement("Audit");
                writer.WriteAttributeString("Datum", currentAudit.Date.ToString());
                //Write customer
                writer.WriteStartElement("Kunde");
                writer.WriteAttributeString("Kundennummer", currentCustomer.Cnumber.ToString());
                writer.WriteAttributeString("Name", currentCustomer.Name);
                writer.WriteAttributeString("Strasse", currentCustomer.Street);
                writer.WriteAttributeString("Hausnummer", currentCustomer.Streetnumber);
                writer.WriteAttributeString("Ort", currentCustomer.City);
                writer.WriteAttributeString("Postleitzahl", currentCustomer.Zip);
                writer.WriteEndElement(); //END Customer
                //Systeminventory
                writer.WriteStartElement("Systeminventar");
                writer.WriteAttributeString("Systeminventarnummer", currentSystemInventory.SystemInventoryNumber.ToString());
                writer.WriteAttributeString("Datum", currentSystemInventory.Date.ToString());
                foreach (ClientSystem c in currentSystemInventory.List_Systems)
                {
                    //Write only Systems with detailed informations
                    if ((c.Type != null) && !(c.Type.Equals("")))
                    {
                        writer.WriteStartElement("Client-System");
                        writer.WriteAttributeString("Clientsystemnummer", c.ClientSystemNumber.ToString());
                        writer.WriteAttributeString("Netzwerknummer", c.Networknumber.ToString());
                        writer.WriteAttributeString("Computername", c.Computername);
                        writer.WriteAttributeString("Betriebssystemtyp", c.Type);
                        writer.WriteAttributeString("Betriebssytem-Seriennummer", c.Serial);
                        writer.WriteAttributeString("IP-Adresse", c.ClientIP.ToString());
                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndElement(); //END Systeminventory
                //Licenseinventory
                writer.WriteStartElement("Lizenzinventar");
                writer.WriteAttributeString("Lizenzinventarnummer", currentLicenseInventory.LicenseInventoryNumber.ToString());
                foreach (Tuple<int, int> t in currentLicenseInventory.Inventory)
                {
                    foreach (License l in list_allAvailableLicenses)
                    {
                        if (t.Item1 == l.LicenseNumber)
                        {
                            writer.WriteStartElement("Lizenz");
                            writer.WriteAttributeString("Lizenzmnummer", l.LicenseNumber.ToString());
                            writer.WriteAttributeString("Lizenzname", l.Name);
                            writer.WriteAttributeString("Anzahl", t.Item2.ToString());
                            writer.WriteEndElement();
                        }
                    }
                }
                writer.WriteEndElement(); //END Licensinventory
                //Auditresults
                writer.WriteStartElement("Auditergebnis");
                foreach (Tuple<int, int> t in currentAudit.Results)
                {
                    foreach (License l in list_allAvailableLicenses)
                    {
                        if (t.Item1 == l.LicenseNumber)
                        {
                            writer.WriteStartElement("Ergebnis");
                            writer.WriteAttributeString("Lizenzmnummer", l.LicenseNumber.ToString());
                            writer.WriteAttributeString("Lizenzname", l.Name);
                            if (t.Item2 > 0)
                            {
                                writer.WriteAttributeString("Ergebnis", String.Format("+{0}", t.Item2.ToString()));
                            }
                            else
                            {
                                writer.WriteAttributeString("Ergebnis", t.Item2.ToString());
                            }
                            if (t.Item2 < 0)
                            {
                                writer.WriteString("unterlizensiert");
                            }
                            else if (t.Item2 > 0)
                            {
                                writer.WriteString("überlizensiert");
                            }
                            else
                            {
                                writer.WriteString("ausreichend lizensiert");
                            }
                            writer.WriteEndElement();
                        }
                    }
                }
                writer.WriteEndElement();//END Auditresults
                writer.WriteEndDocument();
                writer.Close();
            }
        }



        public void GetSystemInventoryFromDB()
        {

        }

        public void GetListSystemInventories()
        {

        }

        public void saveAuditToDB()
        {

        }

        public override void UpdateView(bool customerUpdated)
        {
            //Customer
            if (customerUpdated)
            {
                view.ClearCustomers();
                foreach (Customer c in list_customers)
                {
                    view.AddCustomer(c);
                }
            }
            //LicenseInventory
            view.ClearLicenses();
            if (currentLicenseInventory != null)
            {
                foreach (Tuple<int, int> t in currentLicenseInventory.Inventory)
                {
                    int licensenumber = t.Item1;
                    int count = t.Item2;
                    foreach (License l in list_allAvailableLicenses)
                    {
                        if (l.LicenseNumber == licensenumber)
                        {
                            view.AddLicense(l.Name, count);
                        }
                    }

                }

            }
            //SystemInventory
            view.ClearSystemInventory();
            if (currentSystemInventory != null)
            {
                view.AddSystemInventory(string.Format("Inventarisierung {0}", currentSystemInventory.Date));
                foreach (ClientSystem c in currentSystemInventory.List_Systems)
                {
                    if (c.Type != null && !(c.Type.Equals("")))
                    {
                        view.AddClientSystem(c);
                    }
                }
            }
            //Audit
            view.ClearAudit();
            if (currentAudit != null)
            {
                foreach (Tuple<int, int> t in currentAudit.Results)
                {
                    int licensenumber = t.Item1;
                    int count = t.Item2;
                    foreach (License l in list_allAvailableLicenses)
                    {
                        if (l.LicenseNumber == licensenumber)
                        {
                            view.AddResult(l.Name, count);
                        }
                    }

                }
            }

        }

        public override void UpdateInformation()
        {

        }

        public override void SelectedCustomerChanged(Object customer)
        {
            base.SelectedCustomerChanged(customer);
            currentLicenseInventory = null;
            currentSystemInventory = null;
            currentAudit = null;
            Console.WriteLine("Customer changed successfully: New Customer: {0}", currentCustomer.Name);
            //Get Licenseinventory of the customer or Display Message
            foreach (LicenseInventory li in list_licenseInventories)
            {
                if (li.Customernumber == currentCustomer.Cnumber)
                {
                    currentLicenseInventory = li;
                    Console.WriteLine("Licenseinventory for customer {0} found", currentCustomer.Name);
                    view.EnableAudit();
                }
            }
            if (currentLicenseInventory == null)
            {
                MessageBox.Show("Kein Lizenzinventar für diesen Kunden gefunden. Bitte erstellen Sie zuerst ein Lizenzinventar.", "Kein Lizenzinventar gefunden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                view.DisableAudit();
            }
            //Get Systeminventory of the customer or Display Message
            foreach (SystemInventory si in list_systemInventories)
            {
                if (si.Customernumber == currentCustomer.Cnumber)
                {
                    currentSystemInventory = si;
                    Console.WriteLine("Systeminventory for customer {0} found", currentCustomer.Name);
                    view.EnableAudit();
                }
            }
            if (currentSystemInventory == null)
            {
                MessageBox.Show("Kein Systeminventar für diesen Kunden gefunden. Bitte führen Sie zuerst ein Netzwerkinventarisierung durch.", "Kein Systeminventar gefunden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                view.DisableAudit();
            }
            //Get Audit
            foreach (Audit a in list_audits)
            {
                if (a.CustomerNumber == currentCustomer.Cnumber)
                {
                    currentAudit = a;
                }
            }
            if (currentAudit != null)
            {
                Console.WriteLine("Audit for customer {0} found", currentCustomer.Name);
                MessageBox.Show(String.Format("Audit für diesen Kunden gefunden. Audit vom {0} wird dargestellt.", currentAudit.Date), "Audit vorhanden", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateView(false);
        }

    }
}
