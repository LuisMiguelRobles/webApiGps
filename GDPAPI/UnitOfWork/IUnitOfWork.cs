using GDPAPI.Repository.Interfaces;

namespace GDPAPI.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUser User { get; }
        IStation Station { get; }
        IDestinationOffered DestinationOffered { get; }
        ICompany Company { get; }
        void Complete();

    }
}
