using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDPAPI.Models
{
    public class Seat
    {
        public int Id { get; set; }

        public int SeatNumber { get; set; }

        public string FK_Vehicle { get; set; }
    }
}
