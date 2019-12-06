using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDPAPI.Models
{
    public class Vehicle
    {
        public string Plaque { get; set; }

        public string InternalIdentifier { get; set; }

        public string FK_Company { get; set; }
    }
}
