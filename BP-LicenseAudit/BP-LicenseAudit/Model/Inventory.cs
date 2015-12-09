
namespace BP_LicenseAudit.Model
{
    public abstract class Inventory
    {
        //properties
        private int customerNumber;
        public int Customernumber
        {
            get
            {
                return customerNumber;
            }
            set
            {
                customerNumber = value;
            }
        }
        //constructor
        public Inventory (int customerNumber)
        {
            this.customerNumber = customerNumber;
        }
        
    }
}
