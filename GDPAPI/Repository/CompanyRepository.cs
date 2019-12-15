using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDPAPI.Models;
using GDPAPI.Persistence.Context;
using GDPAPI.Repository.Interfaces;

namespace GDPAPI.Repository
{
    public class CompanyRepository : ICompany
    {
        private readonly ApiContext _apiContext;
        public CompanyRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }
        public void AddCompany(Company company)
        {
            _apiContext.Add(company);
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _apiContext.Companies;
        }

        public Company GetCompany(string nit)
        {
            return _apiContext.Companies.FirstOrDefault(company => company.Nit.Equals(nit));
        }

        public void DeleteCompany(string nit)
        {
            var company = _apiContext.Companies.FirstOrDefault(c => c.Nit == nit);
            _apiContext.Remove(company ?? throw new InvalidOperationException());
        }
    }
}
