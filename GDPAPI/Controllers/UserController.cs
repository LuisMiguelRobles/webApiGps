using System.Net;
using GDPAPI.Models;
using GDPAPI.UnitOfWork;
using GDPAPI.Utilities;
using GDPAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GDPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUtilities _utilities;

        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration,IUnitOfWork unitOfWork, IUtilities utilities)
        {
            _configuration = configuration;
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
        [Route("~/Api/SaveUser")]
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

        [HttpPost]
        [Route("~/Api/Login")]
        public IActionResult Login(UserViewModel viewModel)
        {
            var user = _unitOfWork.User.GetUser(_utilities.EncryptPassword(viewModel.Password), viewModel.Email);
            if (!ModelState.IsValid)
                return BadRequest(HttpStatusCode.NotFound);

            if (user == null)
                return NotFound();


            return Ok(_utilities.Token.GetToken(user));
        }

        
    }
}