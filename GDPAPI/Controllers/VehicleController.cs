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
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult ListVehicle(string plaque)
        {
            var vehicle = _unitOfWork.Vehicle.GetVehicle(plaque);

            if(vehicle == null)
            {
                return BadRequest();
            }
            return Ok(vehicle);
        }

        [HttpPost]
        [Route("~/api/SaveVehicle")]

        public IActionResult SaveVehicle(Vehicle vehicle)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            _unitOfWork.Vehicle.AddVehicle(vehicle);
            _unitOfWork.Complete();

            return Ok(vehicle);
        }
        [HttpGet]
        [Route("~/api/GetAllVehicle")]
        
        public IActionResult ListAllVehicle()
        {
            var vehicle = _unitOfWork.Vehicle.GetAllVehicles();

            if(vehicle != null)
            {
                return Ok(vehicle);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("~/api/RemoveVehicle")]

        public IActionResult RemoveVehicle(string plaque)
        {
            try
            {
                _unitOfWork.Vehicle.DeleteVehicle(plaque);
                _unitOfWork.Complete();

                return Ok("Vehiculo eliminado");
            } catch (NullReferenceException err)
            {
                return BadRequest(err);
            }; 
        }
    }
}