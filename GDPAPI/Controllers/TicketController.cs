using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GDPAPI.Models;
using GDPAPI.UnitOfWork;

namespace GDPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult ListTicket(int id)
        {
            var ticket = _unitOfWork.Ticket.GetTicket(id);

            if (ticket == null)
            {
                return BadRequest();
            }
            return Ok(ticket);
        }

        [HttpPost]
        [Route("~/api/SaveTicket")]

        public IActionResult SaveTicket(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _unitOfWork.Ticket.AddTicket(ticket);
            _unitOfWork.Complete();

            return Ok(ticket);
        }
        [HttpGet]
        [Route("~/api/GetAllTickets")]

        public IActionResult ListAllTicket()
        {
            var ticket = _unitOfWork.Ticket.GetAllTickets();

            if (ticket != null)
            {
                return Ok(ticket);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("~/api/RemoveTicket")]

        public IActionResult RemoveTicket(int id)
        {
            try
            {
                _unitOfWork.Ticket.DeleteTicket(id);
                _unitOfWork.Complete();

                return Ok("Tiquete eliminado");
            }
            catch (NullReferenceException err)
            {
                return BadRequest(err);
            };
        }
    }
}