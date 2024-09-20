using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Models;

namespace TaskManagement.Infrastructure.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }

        // Fetch all projects for a specific company
        public async Task<List<Project>> GetProjectsByCompanyIdAsync(int companyId)
        {
            return await _context.Projects.Where(p => p.CompanyId == companyId).ToListAsync();
        }

        // Create the company in the database
        public async Task<Company> CreateCompanyAsync(Company company)
        {
            // Add company to the context and save
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return company;
        }

        public async Task<bool> AnyAsync(Expression<Func<Company, bool>> predicate)
        {
            return await _context.Companies.AnyAsync(predicate);
        }
    }
}


