using System.Collections.Generic;
using GDPAPI.Models;

namespace GDPAPI.Repository.Interfaces 
    {
    public interface IStation 
    {
        Station GetStation(string code);

        void AddStation(Station station);

        IEnumerable<Station> GetAllStations();
    }
}
