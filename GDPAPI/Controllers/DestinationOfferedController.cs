using System;
using System.Collections.Generic;
using GDPAPI.Models;
using GDPAPI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace GDPAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationOfferedController : ControllerBase {
        private readonly IUnitOfWork _unitOfWork;

        public DestinationOfferedController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult ListDestinationOffered(int id) {
            var destinationOffered = _unitOfWork.DestinationOffered.GetDestinationOffered(id);

            if(destinationOffered == null) {
                return BadRequest();
            }
            
            return Ok(destinationOffered);
        }

        [HttpPost]
        [Route("~/api/SaveDestinationOffered")]
        public IActionResult SaveDestinationOffered(DestinationOffered destinationOffered) {
            if(!ModelState.IsValid) {
                return BadRequest();
            }

            _unitOfWork.DestinationOffered.AddDestinationOffered(destinationOffered);
            _unitOfWork.Complete();

            return Ok(destinationOffered);
        }

        [HttpGet]
        [Route("~/api/GetAllDestinationOffereds")]
        public IActionResult ListAllDestinationOffered() {
            var destinationOffered = _unitOfWork.DestinationOffered.GetAllDestinationOffereds();

            if(destinationOffered != null) {
                return Ok(destinationOffered);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("~/api/RemoveDestinationOffereds")]
        public IActionResult RemoveDestinationOffereds(int id) {
            try {
                _unitOfWork.DestinationOffered.DeleteDestinationOffereds(id);
                _unitOfWork.Complete();

                return Ok("Destino eliminado");

            } catch (NullReferenceException err) {
                return BadRequest(err);
            };
        }
    }
}
