using System;
using BP_LicenseAudit.Controller;
using BP_LicenseAudit.Model;
using System.Windows.Forms;

namespace BP_LicenseAudit.View
{
    public partial class FormChange : FormParent
    {
        private ControllerChanges currentcontroller;
        public ControllerChanges Currentcontroller
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
        public FormChange()
        {
            InitializeComponent();
        }

        private void FormChange_Load(object sender, EventArgs e)
        {

        }

        protected override void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedItem != null) currentcontroller.SelectedCustomerChanged(cmbCustomer.SelectedItem);
        }

        private void dgvLicense_SelectionChanged(Object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection row = dgvLicense.SelectedRows;
            if (row.Count>0 &&(row[0].Cells[0].Value!= null)&& (row[0].Cells[1].Value != null))
            {
                currentcontroller.SelectedLicenseChanged(row[0].Cells[0].Value.ToString(), row[0].Cells[1].Value.ToString());
                Console.WriteLine("License Selected: {0}, {1}", row[0].Cells[0].Value.ToString(), row[0].Cells[1].Value.ToString());
            }

        }

        public void ClearCustomer()
        {
            txtCCity.Clear();
            txtCName.Clear();
            txtCStreet.Clear();
            txtCzip.Clear();
            txtCStreetNr.Clear();
        }

        public void UpdateCustomer(string name, string City, string zip, string Street, string StretNr)
        {
            txtCCity.Text = City;
            txtCName.Text = name;
            txtCStreet.Text = Street;
            txtCzip.Text = zip;
            txtCStreetNr.Text = StretNr;
        }

        public void ClearLicenses()
        {
            dgvLicense.Rows.Clear();
            numCount.Value = 0;
        }

        public void AddLicenseType(License l)
        {
            cmbLicense.Items.Add(l);
        }

        public int CountLicenseTypes()
        {
            return cmbLicense.Items.Count;
        }

        public void ClearLicenseTypes()
        {
            cmbLicense.Items.Clear();
        }

        public void AddLicense(string license, int count)
        {
            int i = dgvLicense.Rows.Add();
            dgvLicense.Rows[i].Cells[0].Value = license;
            dgvLicense.Rows[i].Cells[1].Value = count;
            dgvLicense.ClearSelection();

        }

        public void UpdateLicense(License l, int count)
        {
            cmbLicense.SelectedItem = l;
            numCount.Value = count;
        }

        private void btnLicense_Click(Object sender, EventArgs e)
        {
            currentcontroller.UpdateLicenseInventory(cmbLicense.SelectedItem, numCount.Value);
        }

        public void AddNetwork(Network network)
        {
            lstNetwork.Items.Add(network);
        }

        public void ClearNetworks()
        {
            lstNetwork.Items.Clear();
            ClearCidrInput();
            ClearHostInput();
            ClearStartEndInput();
        }

        public void ClearStartEndInput()
        {
            txtSAByte1.Clear();
            txtSAByte2.Clear();
            txtSAByte3.Clear();
            txtSAByte4.Clear();
            txtEAByte1.Clear();
            txtEAByte2.Clear();
            txtEAByte3.Clear();
            txtEAByte4.Clear();
        }

        public void ClearHostInput()
        {
            txtHostByte1.Clear();
            txtHostByte2.Clear();
            txtHostByte3.Clear();
            txtHostByte4.Clear();
        }

        public void ClearCidrInput()
        {
            txtCidrByte1.Clear();
            txtCidrByte2.Clear();
            txtCidrByte3.Clear();
            txtCidrByte4.Clear();
            txtCidrCidr.Clear();
        }

        public int GetNetworkInputtype()
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
            startaddress[0] = txtSAByte1.Text;
            startaddress[1] = txtSAByte2.Text;
            startaddress[2] = txtSAByte3.Text;
            startaddress[3] = txtSAByte4.Text;
            return startaddress;
        }

        //returns the input of the endaddress in a string[]
        public string[] GetEndAddress()
        {
            string[] endaddress = new string[4];
            endaddress[0] = txtEAByte1.Text;
            endaddress[1] = txtEAByte2.Text;
            endaddress[2] = txtEAByte3.Text;
            endaddress[3] = txtEAByte4.Text;
            return endaddress;
        }

        //returns the input of the hostaddress in a string[]
        public string[] GetHostAddress()
        {
            string[] hostaddress = new string[4];
            hostaddress[0] = txtHostByte1.Text;
            hostaddress[1] = txtHostByte2.Text;
            hostaddress[2] = txtHostByte3.Text;
            hostaddress[3] = txtHostByte4.Text;
            return hostaddress;
        }

        //returns the input of the cidr address in a string[], last part is the networksize
        public string[] GetCidrAddress()
        {
            string[] cidraddress = new string[5];
            cidraddress[0] = txtCidrByte1.Text;
            cidraddress[1] = txtCidrByte2.Text;
            cidraddress[2] = txtCidrByte3.Text;
            cidraddress[3] = txtCidrByte4.Text;
            cidraddress[4] = txtCidrCidr.Text;
            return cidraddress;
        }


    }
}
