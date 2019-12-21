using System.Collections.Generic;

namespace GDPAPI.Models
{
    public class Vehicle
    {
        public string Plaque { get; set; }
        public string InternalIdentifier { get; set; }
        public int NumberSeats { get; set; }
        public string CompanyNit { get; set; }
        public Company Company { get; set; }
        public int SeatsAvailable { get; set; }
        public virtual ICollection<VehicleDeparture>  VehicleDepartures { get; set; }

    }
}
