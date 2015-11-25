﻿using System.Windows.Forms;
using BP_LicenseAudit.View;
using BP_LicenseAudit.Model;
using System;
using System.Collections;

namespace BP_LicenseAudit.Controller
{
    public class ControllerMain : ControllerParent
    {
        private FormMain view;
        private FormAudit fAudit;
        private FormChange fChanges;
        private FormCustomer fCustomer;
        private FormLicense fLicense;
        private FormNetwork fNetwork;
        private FormSystemInventory fSystemInventory;
        private ControllerAudit cAudit;
        private ControllerChanges cChanges;
        private ControllerCustomer cCustomer;
        private ControllerLicense cLicense;
        private ControllerNetwork cNetwork;
        private ControllerSystemInventory cSystemInventory;
        private ArrayList list_networks;
        private ArrayList list_networkinventories;

        //constructor
        public ControllerMain(FormMain view):base(null)
        {
            //connect controller to its view
            this.view = view;

            list_networks = new ArrayList();
            list_networkinventories = new ArrayList();

            //Creating Forms
            fAudit = new FormAudit();
            fChanges = new FormChange();
            fCustomer = new FormCustomer();
            fLicense = new FormLicense();
            fNetwork = new FormNetwork();
            fSystemInventory = new FormSystemInventory();
            fAudit.Visible = false;
            fChanges.Visible = false;
            fCustomer.Visible = false;
            fLicense.Visible = false;
            fNetwork.Visible = false;
            fSystemInventory.Visible = false;

            //Creating Controllers and connect data
            cAudit = new ControllerAudit(this, fAudit, list_customers);
            cChanges = new ControllerChanges(this, fChanges, list_customers);
            cCustomer = new ControllerCustomer(this, fCustomer, list_customers);
            cLicense = new ControllerLicense(this, fLicense, list_customers);
            cNetwork = new ControllerNetwork(this, fNetwork, list_customers, list_networks, list_networkinventories);
            cSystemInventory = new ControllerSystemInventory(this, fSystemInventory, list_customers);

            //Connect Controller to View
            fAudit.Currentcontroller = cAudit;
            fChanges.Currentcontroller = cChanges;
            fCustomer.Currentcontroller = cCustomer;
            fLicense.Currentcontroller = cLicense;
            fNetwork.Currentcontroller = cNetwork;
            fSystemInventory.Currentcontroller = cSystemInventory;

            //TODO: initialising by database


        }

        //functions
        public void CollectInformation()
        {

        }

        public void ConnectToDatabase()
        {

        }

        public void OpenForm(string view)
        {
            switch (view)
            {
                case "Audit":
                    cAudit.UpdateView();
                    fAudit.ShowDialog();
                    break;
                case "Changes":
                    cChanges.UpdateView();
                    fChanges.ShowDialog();
                    break;
                case "Customer":
                    cCustomer.UpdateView();
                    fCustomer.ShowDialog();
                    break;
                case "License":
                    cLicense.UpdateView();
                    fLicense.ShowDialog();
                    break;
                case "Network":
                    cNetwork.UpdateView();
                    fNetwork.ShowDialog();
                    break;
                case "SystemInventory":
                    cSystemInventory.UpdateView();
                    fSystemInventory.ShowDialog();
                    break;
                default:
                    Console.WriteLine("No proper Formsubmitted");
                    break;
            }
        }

        public override void UpdateView()
        {
            //Customer
            view.ClearCustomerList();
            foreach(Customer c in list_customers)
            {
                view.AddCustomer(c);
            }
        }

        public override void UpdateInformation()
        {
            
        }
    }
}
