using System.Collections.Generic;
using GDPAPI.Models;
using System;
using GDPAPI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using GDPAPI.ViewModels;

namespace GDPAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase {
        private readonly IUnitOfWork _unitOfWork;

        public SearchController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("~/api/GetAvailability")]
        public IActionResult ListAvailability(QueryViewModel query) {
            try {
                var search = _unitOfWork.Search.GetAllDestinationOffered(query.StationId, query.DepartureDate);

                if (search != null) {
                    return Ok(search);
                } else {
                    return BadRequest();
                }
            } catch(Exception ex) {
                return BadRequest(ex);
            }
        }
    }
}