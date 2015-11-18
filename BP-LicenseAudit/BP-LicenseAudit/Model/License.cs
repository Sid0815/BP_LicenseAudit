﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_LicenseAudit.Model
{
    class License
    {
        //properties
        private int licenseNumber;
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
        private String name;
        public String Name
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
