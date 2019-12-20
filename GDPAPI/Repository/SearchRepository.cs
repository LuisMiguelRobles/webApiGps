using GDPAPI.Models;
using GDPAPI.Persistence.Context;
using GDPAPI.Repository.Interfaces;
using GDPAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GDPAPI.Repository {
    public class SearchRepository : ISearch {
        private readonly ApiContext _apiContext;
        private readonly IDestinationOffered _destinationOffered;
        private readonly IVehicleDeparture _vehicleDeparture;

        public SearchRepository(ApiContext apiContext, IDestinationOffered destinationOffered, IVehicleDeparture vehicleDeparture) {
            _apiContext = apiContext;
            _destinationOffered = destinationOffered;
            _vehicleDeparture = vehicleDeparture;
        }

        public IEnumerable<SearcherViewModel> GetAllDestinationOffered(int id, DateTime date) {
            List<SearcherViewModel> listSearcher = new List<SearcherViewModel>();
            IEnumerable<DestinationOffered> destinations = _destinationOffered.GetDestinationOfferedsByStationID(id);
            if(destinations != null && destinations.Any()) {
                foreach (DestinationOffered destination in destinations) {
                    List<AvailabilityViewModel> availabilities = new List<AvailabilityViewModel>();
                    IEnumerable<VehicleDeparture> vehicles = _vehicleDeparture.GetVehicleDeparturesByDestinationId(destination.Id);
                    if(vehicles != null && vehicles.Any()) {
                        foreach (VehicleDeparture vehicle in vehicles) {
                            AvailabilityViewModel availability = new AvailabilityViewModel() {
                                 Id = vehicle.Id,
                                 DepartureDate = vehicle.DateTime,
                                 Status = vehicle.State,
                                 VehiclePlaque = vehicle.Plaque
                            };
                            availabilities.Add(availability);
                        }
                    }
                    SearcherViewModel searcherView = new SearcherViewModel() {
                        StationId = destination.DestinationId,
                        CompanyName = destination.CompanyNit,
                        Price = destination.DestinationPrice,
                        Availability = availabilities.AsEnumerable()
                    };
                    listSearcher.Add(searcherView);
                }
            }
            return listSearcher.AsEnumerable();
        }
    }
}
