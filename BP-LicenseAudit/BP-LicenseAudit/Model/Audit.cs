using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_LicenseAudit.Model
{
    class Audit
    {
        private int auditNumber;
        private int customerNumber;
        private DateTime date;
        private int[] results;
        //propperties
        public int AuditNumber
        {
            get
            {
                return auditNumber;
            }
            private set
            {
                auditNumber = value;
            }
        }

        public int CustomerNumber
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

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        //constructor
        public Audit(int number)
        {
            auditNumber = number;
            date = DateTime.Now;
        }
    }
}
