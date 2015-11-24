using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_LicenseAudit.Model
{
    class Network
    {
        //properties
        private int networkNumber;
        public int NetworkNumber
        {
            get
            {
                return networkNumber;
            }
            set
            {
                networkNumber = value;
            }
        }

        private ArrayList ipAddresses = new ArrayList();
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
        private int inputType;
        public int InputType
        {
            get
            {
                return inputType;
            }
            set
            {
                if (value >= 0 && value < 3) inputType = value;
                else throw new Exception();
            }
        }
        private String name;
        public String Name
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
