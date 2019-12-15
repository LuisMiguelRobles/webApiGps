using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDPAPI.Models;

namespace GDPAPI.Repository.Interfaces
{
    public interface ICompany
    {
        void AddCompany(Company company);
        IEnumerable<Company> GetAllCompanies();
        Company GetCompany(string nit);
        void DeleteCompany(string nit);
    }
}
