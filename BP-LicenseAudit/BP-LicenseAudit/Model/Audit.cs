using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_LicenseAudit.Model
{
    class Audit
    {
        //propperties
        private int auditNumber;
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

        private int customerNumber;
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

        private DateTime date;
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

        private int[] results;

        //constructor
        public Audit(int number)
        {
            auditNumber = number;
            date = DateTime.Now;
        }
    }
}
