﻿using System;
using BP_LicenseAudit.Controller;
using BP_LicenseAudit.Model;

namespace BP_LicenseAudit.View
{
    public partial class FormNetwork : FormParent
    {
        private ControllerNetwork currentcontroller;
        public ControllerNetwork Currentcontroller
        {
            private get
            {
                return currentcontroller;
            }
            set
            {
                currentcontroller = value;
            }
        }
        public FormNetwork()
        {
            InitializeComponent();
        }

        private void btnNetworkAdd_Click(object sender, EventArgs e)
        {
            currentcontroller.AddNetworkToInventory();
        }

        public int GetInputtype()
        {
            //Start- Endaddress
            if (tabNetwork.SelectedTab == tabPage1) return 1;
            //Host
            else if (tabNetwork.SelectedTab == tabPage2) return 2;
            //Cidr
            else if (tabNetwork.SelectedTab == tabPage3) return 3;
            //Errror
            else return 0;
        }

        //returns the input of the startaddress in a string[]
        public string[] GetStartAddress()
        {
            string[] startaddress = new string[4];
            startaddress[0] = txtNetwokSAByte1.Text;
            startaddress[1] = txtNetwokSAByte2.Text;
            startaddress[2] = txtNetwokSAByte3.Text;
            startaddress[3] = txtNetwokSAByte4.Text;
            return startaddress;
        }

        //returns the input of the endaddress in a string[]
        public string[] GetEndAddress()
        {
            string[] endaddress = new string[4];
            endaddress[0] = txtNetwokEAByte1.Text;
            endaddress[1] = txtNetwokEAByte2.Text;
            endaddress[2] = txtNetwokEAByte3.Text;
            endaddress[3] = txtNetwokEAByte4.Text;
            return endaddress;
        }

        //returns the input of the hostaddress in a string[]
        public string[] GetHostAddress()
        {
            string[] hostaddress = new string[4];
            hostaddress[0] = txtNetwokCByte1.Text;
            hostaddress[1] = txtNetwokCByte2.Text;
            hostaddress[2] = txtNetwokCByte3.Text;
            hostaddress[3] = txtNetwokCByte4.Text;
            return hostaddress;
        }

        //returns the input of the cidr address in a string[], last part is the networksize
        public string[] GetCidrAddress()
        {
            string[] cidraddress = new string[5];
            cidraddress[0] = txtNetwokCidrByte1.Text;
            cidraddress[1] = txtNetwokCidrByte2.Text;
            cidraddress[2] = txtNetwokCidrByte3.Text;
            cidraddress[3] = txtNetwokCidrByte4.Text;
            cidraddress[4] = txtNetwokCidrCidr.Text;
            return cidraddress;
        }

        //Adds a network to the list
        public void AddNetwork(Network network)
        {
            lstNetworks.Items.Add(network);
        }

        public void ClearNetworks()
        {
            lstNetworks.Items.Clear();
        }

        protected override void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedItem != null)currentcontroller.SelectedCustomerChanged(cmbCustomer.SelectedItem);
        }

        public void ClearStartEndInput()
        {
            txtNetwokSAByte1.Clear();
            txtNetwokSAByte2.Clear();
            txtNetwokSAByte3.Clear();
            txtNetwokSAByte4.Clear();
            txtNetwokEAByte1.Clear();
            txtNetwokEAByte2.Clear();
            txtNetwokEAByte3.Clear();
            txtNetwokEAByte4.Clear();
        }

        public void ClearHostInput()
        {
            txtNetwokCByte1.Clear();
            txtNetwokCByte2.Clear();
            txtNetwokCByte3.Clear();
            txtNetwokCByte4.Clear();
        }

        public void ClearCidrInput()
        {
            txtNetwokCidrByte1.Clear();
            txtNetwokCidrByte2.Clear();
            txtNetwokCidrByte3.Clear();
            txtNetwokCidrByte4.Clear();
            txtNetwokCidrCidr.Clear();
        }

        public System.Windows.Forms.ProgressBar GetProgressBar()
        {
            return this.progressBarNetwork;
        }
    }
}
