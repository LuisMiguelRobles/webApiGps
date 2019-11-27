using System.Collections.Generic;
using GDPAPI.Models;
using GDPAPI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace GDPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public IActionResult ListUser()
        {
            var users = _unitOfWork.User.GetAllUser();
            if (users == null)
            {
                return BadRequest();
            }
            return Ok(users);
        }

        [HttpPost]
        public IActionResult SaveUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _unitOfWork.User.AddUser(user);
            _unitOfWork.Complete();

            return Ok(user);
        } 
    }
}