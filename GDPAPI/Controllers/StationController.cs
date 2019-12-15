using System.Collections.Generic;
using GDPAPI.Models;
using GDPAPI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace GDPAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase {
        private readonly IUnitOfWork _unitOfWork;

        public StationController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult ListStation(string code) {
            var station = _unitOfWork.Station.GetStation(code);

            if(station == null) {
                return BadRequest();
            }

            return Ok(station);
        }

        [HttpPost]
        [Route("~/api/SaveStation")]
        public IActionResult SaveStation(Station station) {
            if(!ModelState.IsValid) {
                return BadRequest();
            }

            _unitOfWork.Station.AddStation(station);
            _unitOfWork.Complete();

            return Ok(station);
        }

        [HttpGet]
        [Route("~/api/GetAllStation")]
        public IActionResult ListAllStation() {
            var station = _unitOfWork.Station.GetAllStations();

            if(station != null) {
                return Ok(station);
            } 

            return BadRequest();
        }

        [HttpPost]
        [Route("~/api/RemoveStation")]
        public IActionResult RemoveStation(string code) {

            if (string.IsNullOrEmpty(code)) {
                return BadRequest();
            }

            _unitOfWork.Station.DeleteStation(code);
            _unitOfWork.Complete();

            return Ok("Estacion eliminada");
        }
    }
}