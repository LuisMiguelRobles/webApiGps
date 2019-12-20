using System.Collections.Generic;
using GDPAPI.Models;
using System;

namespace GDPAPI.Repository.Interfaces {
    public interface IVehicleDeparture {
        VehicleDeparture GetVehicleDeparture(string plaque);

        void AddVehicleDeparture(VehicleDeparture vehicleDeparture);

        IEnumerable<VehicleDeparture> GetAllVehicleDepartures();

        void DeleteVehicleDepartures(string plaque);

        IEnumerable<VehicleDeparture> GetVehicleDeparturesByDestinationId(int id, DateTime date);
    }
}
