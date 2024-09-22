using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTO;
using TaskManagement.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<List<Company>> GetAllAsync();
        Task<Company> GetByIdAsync(int id);
        Task<Company> CreateAsync(CompanyDto companyDto);
        Task<Company> UpdateAsync(int id, CompanyDto companyDto);
        Task DeleteAsync(int id);
    }

}
