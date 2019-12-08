using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDPAPI.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public int SeatNumber { get; set; }

        public string Status { get; set; }

        public double TicketPrice { get; set; }

        public int FK_VehicleDeparture { get; set; }

        public string FK_Client { get; set; }

        public string FK_User { get; set; }
    }
}
