using GDPAPI.Helpers;
using GDPAPI.Models;
using GDPAPI.Persistence.Context;
using GDPAPI.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GDPAPI.Repository {
    public class DestinationOfferedRepository : IDestinationOffered {
        private readonly ApiContext _apiContext;

        public DestinationOfferedRepository(ApiContext apiContext) {
            _apiContext = apiContext;
        }

        public void AddDestinationOffered(DestinationOffered destinationOfferred) {
            _apiContext.Add(destinationOfferred);
        }

        public IEnumerable<DestinationOffered> GetAllDestinationOffereds() {
            return _apiContext.DestinationsOffered;
        }

        public DestinationOffered GetDestinationOffered(int id) {
            var destination = _apiContext.DestinationsOffered.FirstOrDefault(destination => destination.Id == id);

            return destination;
        }

        public void DeleteDestinationOffereds(int id) {
            var destinationOffered = _apiContext.DestinationsOffered.FirstOrDefault(destinationOffered => destinationOffered.Id == id);
            _apiContext.Remove(destinationOffered);
        }

        public IEnumerable<DestinationOffered> GetDestinationOfferedsByStationID(int id) {
            return _apiContext.DestinationsOffered.Where(destinationOffered => destinationOffered.DestinationId == id);
        }
    }
}
