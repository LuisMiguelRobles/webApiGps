using GDPAPI.Models;
using GDPAPI.Persistence.Context;
using GDPAPI.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GDPAPI.Repository {
    public class VehicleDepartureRepository : IVehicleDeparture {
        private readonly ApiContext _apiContext;

        public VehicleDepartureRepository(ApiContext apiContext) {
            _apiContext = apiContext;
        }

        public void AddVehicleDeparture(VehicleDeparture vehicleDeparture) {
            _apiContext.Add(vehicleDeparture);
        }

        public IEnumerable<VehicleDeparture> GetAllVehicleDepartures() {
            return _apiContext.VehicleDepartures;
        }

        public VehicleDeparture GetVehicleDeparture(string plaque) {
            var vehicleDeparture = _apiContext.VehicleDepartures.FirstOrDefault(vehicleDeparture => vehicleDeparture.Plaque == plaque);

            return vehicleDeparture;
        }

        public void DeleteVehicleDepartures(string plaque) {
            var vehicleDeparture = _apiContext.VehicleDepartures.FirstOrDefault(vehicleDeparture => vehicleDeparture.Plaque == plaque);

            _apiContext.Remove(vehicleDeparture);
        }
    }
}
