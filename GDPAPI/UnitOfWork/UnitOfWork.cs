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
            Company = new CompanyRepository(_apiContext);
            Vehicle = new VehicleRepository(_apiContext);
            Ticket = new TicketRepository(_apiContext);
        }

        public IUser User { get; }

        public IStation Station { get; }
        public ICompany Company { get; }

        public IVehicle Vehicle { get; }

        public ITicket Ticket { get; }

        public void Complete()
        {
            _apiContext.SaveChanges();
        }
    }
}
