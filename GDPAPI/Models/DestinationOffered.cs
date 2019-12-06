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

        public bool Direct { get; set; }

        public string CompanyNit { get; set; }

        public Company Company { get; set; }

        public int DestinationID{ get; set; }

        public Destination Destination { get; set; }
    }
}
