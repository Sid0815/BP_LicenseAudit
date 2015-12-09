namespace BP_LicenseAudit.Model
{
    public class License
    {
        private string name;
        private int licenseNumber;
        //properties
        public int LicenseNumber
        {
            get
            {
                return licenseNumber;
            }
            private set
            {
                licenseNumber = value;
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

        //constructor
        public License(int number, string name)
        {
            licenseNumber = number;
            this.name = name;
        }
    }
}
