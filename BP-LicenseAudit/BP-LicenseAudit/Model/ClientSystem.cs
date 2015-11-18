using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_LicenseAudit.Model
{
    class ClientSystem
    {
        //properties
        private int clientSystemNumber;
        public int ClientSystemNumber
        {
            get
            {
                return clientSystemNumber;
            }
            private set
            {
                clientSystemNumber = value;
            }
        }

        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        private string ipAddress;
        public string IpAddress
        {
            get
            {
                return ipAddress;
            }
            set
            {
                ipAddress = value;
            }
        }

        private ArrayList software;
        public ArrayList Software
        {
            get
            {
                return software;
            }
            set
            {
                software = value;
            }
        }

        private int cores;
        public int Cores
        {
            get
            {
                return cores;
            }
            set
            {
                cores = value;
            }
        }

        //constructor
        public ClientSystem(int number)
        {
            clientSystemNumber = number;
            type = null;
            ipAddress = null;
            software = new ArrayList();
            cores = 0;
        }

    }
}
