using GDPAPI.Repository.Interfaces;

namespace GDPAPI.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUser User { get; }
    
        void Complete();
    }
}
