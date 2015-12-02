using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BP_LicenseAudit.Model
{
    public class ClientSystem
    {
        private int clientSystemNumber;
        private string type;
        private IPAddress clientIP;
        private ArrayList software;
        private int cores;

        //properties

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

        public IPAddress ClientIP
        {
            get
            {
                return clientIP;
            }
            set
            {
                clientIP = value;
            }
        }

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
        public ClientSystem(int number, IPAddress clientIP)
        {
            clientSystemNumber = number;
            type = null;
            this.clientIP = clientIP;
            software = new ArrayList();
            cores = 0;
        }

    }
}
