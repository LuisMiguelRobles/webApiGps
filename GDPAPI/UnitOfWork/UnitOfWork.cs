using GDPAPI.Persistence.Context;
using GDPAPI.Repository;
using GDPAPI.Repository.Interfaces;

namespace GDPAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public UnitOfWork(Context context)
        {
            _context = context;
            User = new UserRepository(_context);
        }

        public IUser User { get; }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
