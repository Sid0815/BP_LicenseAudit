using System.Net;

namespace BP_LicenseAudit.Model
{
    public class ClientSystem
    {
        private int clientSystemNumber;
        private int networknumber;
        private string computername;
        private string type;
        private string serial;
        private IPAddress clientIP;

        //properties

        public int ClientSystemNumber
        {
            get { return clientSystemNumber; }
            private set { clientSystemNumber = value; }
        }

        public int Networknumber
        {
            get { return networknumber; }
            set { networknumber = value; }
        }

        public string Computername
        {
            get
            {
                return computername;
            }
            set
            {
                computername = value;
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

        public string Serial
        {
            get
            {
                return serial;
            }
            set
            {
                serial = value;
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

        //constructor
        public ClientSystem(int number, IPAddress clientIP, int networknumber)
        {
            clientSystemNumber = number;
            type = null;
            serial = null;
            this.clientIP = clientIP;
            this.networknumber = networknumber;
        }
    }
}
