using GDPAPI.Models;
using GDPAPI.Persistence.Context;
using GDPAPI.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GDPAPI.Repository {
    public class StationRepository : IStation {
        private readonly ApiContext _apiContext;

        public StationRepository(ApiContext apiContext) {
            _apiContext = apiContext;
        }

        public void AddStation(Station station) {
            _apiContext.Add(station);
        }

        public IEnumerable<Station> GetAllStations() {
            return _apiContext.Destinations;
        }

        public Station GetStation(string code) {
            var station = _apiContext.Destinations.FirstOrDefault(station => station.Code == code);

            return station;
        }
    }
}
