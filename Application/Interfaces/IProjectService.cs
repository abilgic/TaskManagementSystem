using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjectsByCompanyIdAsync(int companyId);
        Task<Project> CreateProjectAsync(Project newProject);
        System.Threading.Tasks.Task DeleteProjectAsync(int projectId);
        Task<Project> GetProjectByIdAsync(int projectId);
        Task<Project> UpdateProjectAsync(int projectId, Project updatedProject);
    }
}
