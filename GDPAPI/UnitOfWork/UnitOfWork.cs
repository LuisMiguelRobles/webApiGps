using GDPAPI.Persistence.Context;
using GDPAPI.Repository;
using GDPAPI.Repository.Interfaces;

namespace GDPAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiContext _apiContext;
        public UnitOfWork(ApiContext apiContext)
        {
            _apiContext = apiContext;
            User = new UserRepository(_apiContext);
            Station = new StationRepository(_apiContext);
            DestinationOffered = new DestinationOfferedRepository(_apiContext);
            VehicleDeparture = new VehicleDepartureRepository(_apiContext);
            Company = new CompanyRepository(_apiContext);
        }

        public IUser User { get; }

        public IStation Station { get; }
        public ICompany Company { get; }
        public IDestinationOffered DestinationOffered { get; }

        public IVehicleDeparture VehicleDeparture { get; }

        public void Complete()
        {
            _apiContext.SaveChanges();
        }
    }
}
