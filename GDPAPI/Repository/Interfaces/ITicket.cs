using GDPAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDPAPI.Repository.Interfaces
{
    public interface ITicket
    {
        Ticket GetTicket(int id);

        void AddTicket(Ticket ticket);

        IEnumerable<Ticket> GetAllTickets();

        void DeleteTicket(int id);
    }
}
