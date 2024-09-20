using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<Company> AddCompanyAsync(Company company)
        {
            await _companyRepository.AddAsync(company);
            return company;
        }
    }

}
