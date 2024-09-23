using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Models;

namespace TaskManagement.Infrastructure.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly AppDbContext _context;
        public ProjectRepository(AppDbContext context) : base(context)
        {
            _context = context;  // Now uses AppDbContext instead of DbContext
        }
        
        public async Task<List<Project>> GetProjectsForCompanyAsync(int companyId)
        {
            var list = await GetAllAsync();
            return  list.Where(p => p.CompanyId == companyId).ToList();
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            return await GetByIdAsync(projectId);
        }

        public async System.Threading.Tasks.Task AddProjectAsync(Project project)
        {
            await AddAsync(project);
        }

        public async System.Threading.Tasks.Task UpdateProjectAsync(Project project)
        {
            await UpdateAsync(project);
        }

        public async System.Threading.Tasks.Task DeleteProjectAsync(int projectId)
        {
            var project = await GetProjectByIdAsync(projectId);
            if (project != null)
            {
                await DeleteAsync(project);
            }
        }
    }
}
