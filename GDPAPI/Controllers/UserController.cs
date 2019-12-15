using System.Collections.Generic;
using System.Security.Cryptography;
using GDPAPI.Models;
using GDPAPI.UnitOfWork;
using GDPAPI.Utilities;
using GDPAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GDPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUtilities _utilities;

        public UserController(IUnitOfWork unitOfWork, IUtilities utilities)
        {
            _unitOfWork = unitOfWork;
            _utilities = utilities;
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
        public IActionResult SaveUser(UserViewModel viewModel)
        {
            if (viewModel == null || !_unitOfWork.User.IsValid(viewModel)) return BadRequest();
            var user = new User
            {
                Name = viewModel.Name,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                City = viewModel.City,
                Password = _utilities.EncryptPassword(viewModel.Password),
                Phone = viewModel.Phone,

            };
            _unitOfWork.User.AddUser(user);
            _unitOfWork.Complete();

            return Ok(user);

        }
    }
}