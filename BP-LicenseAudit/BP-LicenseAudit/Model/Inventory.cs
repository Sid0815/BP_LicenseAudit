using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_LicenseAudit.Model
{
    public class Inventory
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
