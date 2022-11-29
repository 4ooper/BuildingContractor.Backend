﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Domain
{
    public class listOfWork
    {
        public int id { get; set; }
        public string name { get; set; }
        public int licenseID { get; set; }
        public License license { get; set; }

        public IList<Service> services { get; set; }
    }
}
