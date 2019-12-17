using System.Collections.Generic;
using GDPAPI.Models;
using GDPAPI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace GDPAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleDepartureController : ControllerBase {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleDepartureController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("~/api/GetVehicleDeparture")]
        public IActionResult ListVehicleDeparture(string plaque) {
            var vehicleDeparture = _unitOfWork.VehicleDeparture.GetVehicleDeparture(plaque);

            if(vehicleDeparture == null) {
                return BadRequest();
            }

            return Ok(vehicleDeparture);
        }

        [HttpPost]
        [Route("~/api/SaveVehicleDeparture")]
        public IActionResult SaveVehicleDeparture(VehicleDeparture vehicle) {
            if(!ModelState.IsValid) {
                return BadRequest();
            }

            _unitOfWork.VehicleDeparture.AddVehicleDeparture(vehicle);
            _unitOfWork.Complete();

            return Ok(vehicle);
        }

        [HttpGet]
        [Route("~/api/GetAllVehicleDeparture")]
        public IActionResult ListAllVehicleDeparture() {
            var vehicleDeparture = _unitOfWork.VehicleDeparture.GetAllVehicleDepartures();

            if(vehicleDeparture != null) {
                return Ok(vehicleDeparture);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("~/api/RemoveVehicleDeparture")]
        public IActionResult RemoveVehicleDeparture(string plaque) {
            if(string.IsNullOrEmpty(plaque)) {
                return BadRequest();
            }

            _unitOfWork.VehicleDeparture.DeleteVehicleDepartures(plaque);
            _unitOfWork.Complete();

            return Ok("Salida Vehiculo Eliminada");
        }
    }
}