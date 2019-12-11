using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDPAPI.Models
{
    public class Company
    {
        public string Nit { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual ICollection<DestinationOffered> DestinationOffers { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
