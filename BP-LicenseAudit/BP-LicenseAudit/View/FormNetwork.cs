using System;
using BP_LicenseAudit.Controller;

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
    }
}
