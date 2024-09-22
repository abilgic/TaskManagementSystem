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
        private readonly IRepository<Company> _companyRepository;

        public CompanyService(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _companyRepository.GetAllAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
            {
                throw new KeyNotFoundException("Company not found.");
            }
            return company;
        }

        public async Task<Company> CreateAsync(CompanyDto companyDto)
        {
            var company = new Company
            {
                Name = companyDto.Name,
                UserLimit = companyDto.UserLimit,
                ProjectLimit = companyDto.ProjectLimit,
                ActiveUntil = companyDto.ActiveUntil
            };

            await _companyRepository.AddAsync(company);
            return company;
        }

        public async Task<Company> UpdateAsync(int id, CompanyDto companyDto)
        {
            var existingCompany = await _companyRepository.GetByIdAsync(id);
            if (existingCompany == null)
            {
                throw new KeyNotFoundException("Company not found.");
            }

            existingCompany.Name = companyDto.Name;
            existingCompany.UserLimit = companyDto.UserLimit;
            existingCompany.ProjectLimit = companyDto.ProjectLimit;
            existingCompany.ActiveUntil = companyDto.ActiveUntil;

            await _companyRepository.UpdateAsync(existingCompany);
            return existingCompany;
        }

        public async System.Threading.Tasks.Task DeleteAsync(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
            {
                throw new KeyNotFoundException("Company not found.");
            }

            await _companyRepository.DeleteAsync(company);
        }
    }

}


