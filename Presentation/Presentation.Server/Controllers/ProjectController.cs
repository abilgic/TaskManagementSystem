using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: api/project/{companyId}
        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetProjectsByCompanyId(int companyId)
        {
            var projects = await _projectService.GetProjectsByCompanyIdAsync(companyId);

            if (projects == null)
            {
                return NotFound($"No projects found for company with ID {companyId}");
            }

            return Ok(projects);
        }

        // POST: api/project
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Project newProject)
        {
            if (newProject == null || newProject.CompanyId == 0 || string.IsNullOrEmpty(newProject.Name))
            {
                return BadRequest("Invalid project data.");
            }

            var createdProject = await _projectService.CreateProjectAsync(newProject);
            return CreatedAtAction(nameof(GetProjectsByCompanyId), new { companyId = createdProject.CompanyId }, createdProject);
        }

        // DELETE: api/project/{projectId}
        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            var project = await _projectService.GetProjectByIdAsync(projectId);

            if (project == null)
            {
                return NotFound($"No project found with ID {projectId}");
            }

            await _projectService.DeleteProjectAsync(projectId);
            return NoContent();
        }

        // PUT: api/project/{projectId}
        [HttpPut("{projectId}")]
        public async Task<IActionResult> UpdateProject(int projectId, [FromBody] Project updatedProject)
        {
            if (updatedProject == null || updatedProject.CompanyId == 0 || string.IsNullOrEmpty(updatedProject.Name))
            {
                return BadRequest("Invalid project data.");
            }

            var existingProject = await _projectService.GetProjectByIdAsync(projectId);
            if (existingProject == null)
            {
                return NotFound($"No project found with ID {projectId}");
            }

            var updated = await _projectService.UpdateProjectAsync(projectId, updatedProject);
            return Ok(updated);
        }
    }
}
