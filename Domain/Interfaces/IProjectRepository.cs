using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Domain.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {

        Task<List<Project>> GetProjectsForCompanyAsync(int companyId);
        Task<Project> GetProjectByIdAsync(int projectId);
        Task AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int projectId);
    }

}
