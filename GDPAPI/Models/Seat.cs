
namespace GDPAPI.Models
{
    public class Seat
    {
        public int Id { get; set; }

        public int SeatNumber { get; set; }

        public string VehiclePlaque { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
