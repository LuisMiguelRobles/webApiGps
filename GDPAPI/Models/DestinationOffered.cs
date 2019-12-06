using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDPAPI.Models
{
    public class DestinationOffered
    {
        public int Id { get; set; }

        public double DestinationPrice { get; set; }

        public string FK_Company { get; set; }

        public int FK_Destination { get; set; }

        public bool Direct { get; set; }
    }
}
