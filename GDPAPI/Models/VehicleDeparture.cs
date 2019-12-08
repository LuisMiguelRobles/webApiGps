using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDPAPI.Models
{
    public class VehicleDeparture
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public bool State { get; set; }
    }
}
