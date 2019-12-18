using GDPAPI.Models;
using GDPAPI.Persistence.Context;
using GDPAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GDPAPI.Repository
{
    public class VehicleRepository : IVehicle
    {
        private readonly ApiContext _apiContext;

        public VehicleRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _apiContext.Add(vehicle);
        }

        public void DeleteVehicle(string plaque)
        {
            var vehicle = _apiContext.Vehicles.FirstOrDefault(vehicle => vehicle.Plaque == plaque);
            _apiContext.Remove(vehicle);
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _apiContext.Vehicles;
        }

        public Vehicle GetVehicle(string plaque)
        {
            var vehicle = _apiContext.Vehicles.FirstOrDefault(vehicle => vehicle.Plaque == plaque);
            return vehicle;
        }

        public IEnumerable<Vehicle> GetVehicle()
        {
            return _apiContext.Vehicles;
        }
    }
}
