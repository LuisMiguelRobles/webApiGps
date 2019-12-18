using GDPAPI.Repository.Interfaces;

namespace GDPAPI.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUser User { get; }
        IStation Station { get; }
        ICompany Company { get; }
        IVehicle Vehicle { get; }
        ITicket Ticket { get; }
        void Complete();
    }
}
