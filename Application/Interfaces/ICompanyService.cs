using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTO;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<List<Company>> GetCompaniesAsync();
        Task<Company> GetCompanyAsync(int id);
        //Task<Company> AddCompanyAsync(Company company);
        Task<Company> CreateCompanyAsync(CompanyDto companyDto, User adminUser);
    }

}
