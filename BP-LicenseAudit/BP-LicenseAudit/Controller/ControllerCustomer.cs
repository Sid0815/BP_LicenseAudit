using System;
using System.Collections;
using BP_LicenseAudit.Model;
using BP_LicenseAudit.View;
using System.Windows.Forms;

namespace BP_LicenseAudit.Controller
{
    public class ControllerCustomer : ControllerParent
    {
        private FormCustomer view;


        //Constructor
        public ControllerCustomer(ControllerParent calling, FormCustomer view, ArrayList list_customers):base(calling)
        {
            //connect controller to its view
            this.view = view;
            this.list_customers = list_customers;
        }

        //Functions
        public void AddCustomer(int nr, string name, string street, string streetnr, string city, string zip)
        {
            list_customers.Add(new Customer(nr, name, street, streetnr, city, zip));
        }

        public void UpdateCustomer()
        {

        }

        public void RemoveCustomer()
        {

        }

        public object SearchCustomer()
        {
            Customer foundCustomer = new Customer(-1, "a", "a", "a", "a", "a");
            return foundCustomer;
        }

        public override void UpdateView(bool customerChanged)
        {
            //Update number of customers
            view.UpdateCustomerNumber(Convert.ToString(list_customers.Count));
        }

        public override void UpdateInformation()
        {//Updates all neccesary properties of the controller (could be caled by a controller who self was caled by this)
        }


        public void SaveNext()
        {
            string name = view.GetCustomerName().Trim();
            string street = view.GetCustomerStreet().Trim();
            string streetnr = view.GetCustomerStreetNr().Trim();
            string city = view.GetCustomerCity().Trim();
            string zip = view.GetCustomerZIP().Trim();
            if(checkInput(name, street, streetnr, city, zip))
            {                
                AddCustomer(list_customers.Count, name, street, streetnr, city, zip);
                UpdateView(true);
                MessageBox.Show("Kunde erfolgreich hinzugefügt", "OK", MessageBoxButtons.OK);
                view.ClearInput();
                //Communicate to calling controller
                callingController.UpdateView(true);
            }
            else
            {
                Console.WriteLine("Error while adding User");
            }


        }

        public void SaveEnd()
        {
            string name = view.GetCustomerName().Trim();
            string street = view.GetCustomerStreet().Trim();
            string streetnr = view.GetCustomerStreetNr().Trim();
            string city = view.GetCustomerCity().Trim();
            string zip = view.GetCustomerZIP().Trim();
            if (checkInput(name, street, streetnr, city, zip))
            {
                AddCustomer(list_customers.Count, name, street, streetnr, city, zip);
                UpdateView(true);
                MessageBox.Show("Kunde erfolgreich hinzugefügt", "OK", MessageBoxButtons.OK);
                view.ClearInput();
                view.Close();
                //Communicate to calling controller
                callingController.UpdateView(true);
            }
            else
            {
                Console.WriteLine("Error while adding User");
            }

        }

        private bool checkInput(string name, string street, string streetnr, string city, string zip)
        {
            if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show("Fehler bei der Eingabe des Namens", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrEmpty(street))
            {
                MessageBox.Show("Fehler bei der Eingabe der Straße", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrEmpty(streetnr))
            {
                MessageBox.Show("Fehler bei der Eingabe der Straßennummer", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrEmpty(city))
            {
                MessageBox.Show("Fehler bei der Eingabe der Stadt", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrEmpty(zip))
            {
                MessageBox.Show("Fehler bei der Eingabe der Postleitzahl", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }


    }
}
