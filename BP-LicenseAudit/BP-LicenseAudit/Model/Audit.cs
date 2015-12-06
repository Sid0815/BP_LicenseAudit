using System;
using System.Collections;


namespace BP_LicenseAudit.Model
{
    public class Audit
    {
        private int auditNumber;
        private int customerNumber;
        private DateTime date;
        private ArrayList results;
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

        public ArrayList Results
        {
            get
            {
                return results;
            }
            private set
            {
                results = value;
            }
        }

        //constructor
        public Audit(int auditNumber, int customerNumber)
        {
            this.auditNumber = auditNumber;
            this.customerNumber = customerNumber;
            this.date = DateTime.Now;
            this.results = new ArrayList();
        }

        //result is the number of free licenses
        public void AddResult(int licensenumber, int result)
        {
            Tuple<int, int> t = new Tuple<int, int>(licensenumber, result);
            results.Add(t);
        }
    }
}
