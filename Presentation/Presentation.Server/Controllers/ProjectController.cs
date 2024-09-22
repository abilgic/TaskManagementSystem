using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Server.Controllers
{   
    //[ApiController]
    //[Route("api/[controller]")]
    //public class ProjectController : ControllerBase
    //{
    //    private readonly IProjectRepository _projectRepository;

    //    public ProjectController(IProjectRepository projectRepository)
    //    {
    //        _projectRepository = projectRepository;
    //    }

    //    [HttpGet("{companyId}")]
    //    public async Task<IActionResult> GetProjectsByCompanyId(int companyId)
    //    {
    //        var projects = await _projectRepository.GetProjectsByCompanyIdAsync(companyId);
    //        return Ok(projects);
    //    }
    //}

}
