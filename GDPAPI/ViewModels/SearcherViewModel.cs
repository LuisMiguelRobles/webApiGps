using System;
using System.Collections;
using System.Collections.Generic;

namespace GDPAPI.ViewModels {
    public class SearcherViewModel {
        public int StationId { get; set; }
        public string CompanyName { get; set; }
        public double Price { get; set; }
        public IEnumerable<AvailabilityViewModel> Availability { get; set; }
    }

    public class AvailabilityViewModel {
        public int Id { get; set; }
        public DateTime DepartureDate { get; set; }
        public bool Status { get; set; }
        public string VehiclePlaque { get; set; }
    }
}
