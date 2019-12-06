using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDPAPI.Models
{
    public class VehicleDeparture
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } //Duda de tipo.

        public string FK_Vehicle { get; set; }

        public string FK_Driver { get; set; }

        public int FK_DestinationOffered { get; set; }
    }
}
