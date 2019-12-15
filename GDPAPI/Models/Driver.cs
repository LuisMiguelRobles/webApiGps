using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GDPAPI.Models
{
    public class Driver
    {
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
