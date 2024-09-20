using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Models;
using TaskManagement.Infrastructure.Repositories;

namespace TaskManagement.Infrastructure.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Project>> GetProjectsByCompanyIdAsync(int companyId)
        {
            return await _context.Projects.Where(p => p.CompanyId == companyId).ToListAsync();
        }
    }

}

public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    public CompanyRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Project>> GetProjectsByCompanyIdAsync(int companyId)
    {
        return await _context.Projects.Where(p => p.CompanyId == companyId).ToListAsync();
    }
}