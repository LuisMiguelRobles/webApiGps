
using System.Collections.Generic;

namespace GDPAPI.Models
{
    public class DestinationOffered
    {
        public int Id { get; set; }
        public double DestinationPrice { get; set; }
        public bool Direct { get; set; }
        public string CompanyNit { get; set; }
        public Company Company { get; set; }
        public int DestinationId{ get; set; }
        public Station Station { get; set; }
        public virtual  ICollection<VehicleDeparture> VehicleDepartures { get; set; }
    }
}
