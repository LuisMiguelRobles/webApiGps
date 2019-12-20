using GDPAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace GDPAPI.Repository.Interfaces {
    public interface ISearch {
        IEnumerable<SearcherViewModel> GetAllDestinationOffered(int id, DateTime date);
    }
}
