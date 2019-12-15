using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDPAPI.Models;
using GDPAPI.UnitOfWork;
using GDPAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GDPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("~/api/AddCompany")]
        public IActionResult AddCompany(CompanyViewModel viewModel)
        {
            if (viewModel == null)
            {
                return BadRequest();
            }

            var company = new Company
            {
                Nit = viewModel.Nit,
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone
                
            };
            _unitOfWork.Company.AddCompany(company);
            _unitOfWork.Complete();
            return Ok(company);
      }

        [HttpGet]
        [Route("~/api/GetAllCompanies")]
        public IActionResult GetAllCompanies()
        {
            var companies = _unitOfWork.Company.GetAllCompanies();

            if (companies == null)
            {
                return NotFound();
            }

            return Ok(companies);
        }

        [HttpGet]
        [Route("~/api/GetCompany")]
        public IActionResult GetCompany(string nit)
        {
            var company = _unitOfWork.Company.GetCompany(nit);
            
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPost]
        [Route("~/api/DeleteCompany")]
        public IActionResult DeleteCompany(string nit)
        {
            if (string.IsNullOrEmpty(nit))
            {
                return BadRequest();
            }
            _unitOfWork.Company.DeleteCompany(nit);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}