using GDPAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDPAPI.Repository.Interfaces
{
    public interface IVehicle
    {
        Vehicle GetVehicle(string plaque);

        void AddVehicle(Vehicle vehicle);

        IEnumerable<Vehicle> GetAllVehicles();

        void DeleteVehicle(string plaque);
    }
}
