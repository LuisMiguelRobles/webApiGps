using GDPAPI.Repository.Interfaces;

namespace GDPAPI.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUser User { get; }
        IStation Station { get; }
        IDestinationOffered DestinationOffered { get; }
        ICompany Company { get; }
        IVehicleDeparture VehicleDeparture { get; }
        IVehicle Vehicle { get; }
        ITicket Ticket { get; }
        void Complete();

    }
}
