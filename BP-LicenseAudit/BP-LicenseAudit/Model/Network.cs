using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_LicenseAudit.Model
{
    public class Network
    {
        private int networkNumber;
        private int inputType;
        private string name;
        private ArrayList ipAddresses = new ArrayList();
        //properties

        public int NetworkNumber
        {
            get
            {
                return networkNumber;
            }
            private set
            {
                networkNumber = value;
            }
        }

        public ArrayList IpAddresses
        {
            get
            {
                return ipAddresses;
            }
            set
            {
                ipAddresses = value;
            }
        }

        //1=Start-/EndAddress
        //2=Host only
        //3=Cidr
        public int InputType
        {
            get
            {
                return inputType;
            }
            set
            {
                if (value > 0 && value <= 3) inputType = value;
                else throw new Exception("Networkinputtype missleading");
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        //Constructor
        public Network(int nr, string name, int inputType, ArrayList ipAddresses)
        {
            this.networkNumber = nr;
            this.name = name;
            this.inputType = inputType;
            this.ipAddresses = ipAddresses;
        }
    }
}
