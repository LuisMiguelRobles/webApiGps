using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDPAPI.Models
{
    public class Destination
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public ICollection<DestinationOffered> DestinationOffers { get; set; }
    }
}
