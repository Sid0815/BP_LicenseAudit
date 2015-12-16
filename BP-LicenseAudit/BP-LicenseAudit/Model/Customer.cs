
namespace BP_LicenseAudit.Model
{
    public class Customer
    {
        private int cnumber;
        private string name;
        private string street;
        private string streetnumber;
        private string city;
        private string zip;
        //properties
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
        public Customer(int cnumber, string name, string street, string streetnr, string city, string zip)
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