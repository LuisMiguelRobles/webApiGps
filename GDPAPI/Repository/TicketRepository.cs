using GDPAPI.Models;
using GDPAPI.Persistence.Context;
using GDPAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GDPAPI.Repository
{
    public class TicketRepository : ITicket
    {
        private readonly ApiContext _apiContext;

        public TicketRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }
        public void AddTicket(Ticket ticket)
        {
            _apiContext.Add(ticket);
        }

        public void DeleteTicket(int id)
        {
            var ticket = _apiContext.Tickets.FirstOrDefault(ticket => ticket.Id == id);
            _apiContext.Remove(ticket);
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _apiContext.Tickets;
        }

        public Ticket GetTicket(int id)
        {
            var ticket = _apiContext.Tickets.FirstOrDefault(ticket => ticket.Id == id);
            return ticket;
        }
    }
}
