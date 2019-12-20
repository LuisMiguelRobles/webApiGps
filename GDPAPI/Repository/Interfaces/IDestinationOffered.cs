using System;
using System.Collections.Generic;
using GDPAPI.Models;

namespace GDPAPI.Repository.Interfaces {
    public interface IDestinationOffered {
        DestinationOffered GetDestinationOffered(int id);

        void AddDestinationOffered(DestinationOffered destinationOfferred);

        IEnumerable<DestinationOffered> GetAllDestinationOffereds();

        void DeleteDestinationOffereds(int id);
        IEnumerable<DestinationOffered> GetDestinationOfferedsByStationID(int id);
    }
}
