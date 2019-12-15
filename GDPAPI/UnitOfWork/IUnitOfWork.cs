using GDPAPI.Repository.Interfaces;

namespace GDPAPI.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUser User { get; }
        IStation Station { get; }
        ICompany Company { get; }
        void Complete();
    }
}
