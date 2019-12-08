using System.Collections.Generic;

namespace GDPAPI.Models
{
    public class Vehicle
    {
        public string Plaque { get; set; }
        public string InternalIdentifier { get; set; }
        public string CompanyNit { get; set; }
        public Company Company { get; set; }
        public Driver Driver { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}
