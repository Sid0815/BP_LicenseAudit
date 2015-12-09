
namespace BP_LicenseAudit.Model
{
    public class Customer
    {
        //properties
        private int cnumber;
        public int Cnumber
        {
            get
            {
                return cnumber;
            }

            private set
            {
                cnumber = value;
            }
        }
        private string name;
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

        private string street;
        public string Street
        {
            get
            {
                return street;
            }

            set
            {
                street = value;
            }
        }

        private string city;
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }

        private string zip;
        public string Zip
        {
            get
            {
                return zip;
            }
            set
            {
                zip = value;
            }
        }

        private string streetnumber;
        public string Streetnumber
        {
            get
            {
                return streetnumber;
            }
            set
            {
                streetnumber = value;
            }
        }

        //Constructor
        public Customer (int cnumber, string name, string street, string streetnr, string city, string zip)
        {
            this.cnumber = cnumber;
            this.name = name;
            this.street = street;
            this.city = city;
            this.zip = zip;
            this.streetnumber = streetnr;
        }

    }

}