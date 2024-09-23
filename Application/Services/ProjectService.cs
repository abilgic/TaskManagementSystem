using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // Get projects by companyId
        public async Task<IEnumerable<Project>> GetProjectsByCompanyIdAsync(int companyId)
        {
            return await _projectRepository.GetProjectsForCompanyAsync(companyId);
        }

        // Create a new project
        public async Task<Project> CreateProjectAsync(Project newProject)
        {
            if (newProject == null || newProject.CompanyId == 0 || string.IsNullOrEmpty(newProject.Name))
            {
                throw new ArgumentException("Invalid project data");
            }

            await _projectRepository.AddProjectAsync(newProject);
            return newProject;
        }

        // Delete a project by projectId
        public async System.Threading.Tasks.Task DeleteProjectAsync(int projectId)
        {
            var project = await _projectRepository.GetProjectByIdAsync(projectId);
            if (project == null)
            {
                throw new KeyNotFoundException($"No project found with ID {projectId}");
            }

            await _projectRepository.DeleteProjectAsync(projectId);
        }

        // Update an existing project
        public async Task<Project> UpdateProjectAsync(int projectId, Project updatedProject)
        {
            var existingProject = await _projectRepository.GetProjectByIdAsync(projectId);
            if (existingProject == null)
            {
                throw new KeyNotFoundException($"No project found with ID {projectId}");
            }

            existingProject.Name = updatedProject.Name;
            existingProject.CompanyId = updatedProject.CompanyId;
            existingProject.Description = updatedProject.Description;
            // Update other fields if needed

            await _projectRepository.UpdateProjectAsync(existingProject);
            return existingProject;
        }

        // Get a project by projectId
        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            var project = await _projectRepository.GetProjectByIdAsync(projectId);
            if (project == null)
            {
                throw new KeyNotFoundException($"No project found with ID {projectId}");
            }
            return project;
        }
    }
}
