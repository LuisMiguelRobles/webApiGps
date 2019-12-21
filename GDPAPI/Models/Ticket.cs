using System.Collections.Generic;

namespace GDPAPI.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public string Status { get; set; }
        public double TicketPrice { get; set; }
        public int VehicleDepartureId { get; set; }
        public VehicleDeparture VehicleDeparture { get; set; }
        public int UserId{ get; set; }
        public User User { get; set; }
    }
}
