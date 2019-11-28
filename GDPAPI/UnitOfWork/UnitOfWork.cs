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
        }

        public IUser User { get; }
        public void Complete()
        {
            _apiContext.SaveChanges();
        }
    }
}
