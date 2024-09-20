using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTO;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<Company>> GetCompaniesAsync() => await _companyRepository.GetAllAsync();

        public async Task<Company> GetCompanyAsync(int id) => await _companyRepository.GetByIdAsync(id);

        //public async Task<Company> AddCompanyAsync(Company company)
        //{
        //    await _companyRepository.AddAsync(company);
        //    return company;
        //}

        public async Task<Company> CreateCompanyAsync(CompanyDto companyDto, User adminUser)
        {
            // Check if the admin user already has a company
            var existingCompany = await _companyRepository.AnyAsync(c => c.AdminUserId == adminUser.Id);
            if (existingCompany)
            {
                throw new InvalidOperationException("This admin user already has a company.");
            }

            // Create the company
            var company = new Company
            {
                Name = companyDto.Name,
                UserLimit = companyDto.UserLimit,
                ProjectLimit = companyDto.ProjectLimit,
                ActiveDuration = companyDto.ActiveDuration,
                AdminUserId = adminUser.Id // Link the admin user to the new company
            };

            // Use the repository to add the company
            await _companyRepository.AddAsync(company);

            // The repository should handle saving changes, so no need for explicit _context.SaveChangesAsync()

            return company;
        }

    }

}
