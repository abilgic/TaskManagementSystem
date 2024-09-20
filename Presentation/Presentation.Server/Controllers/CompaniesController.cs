using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.DTO;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService; // Declare the user service

        public CompaniesController(ICompanyService companyService, IUserService userService)
        {
            _companyService = companyService;
            _userService = userService; // Inject the user service
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _companyService.GetCompanyAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyDto companyDto)
        {
            // Assuming you have a way to get the logged-in admin user's ID (e.g., from claims or session)
            int adminUserId = int.Parse(User.FindFirst("UserId").Value); // Example of fetching user ID from claims
            var adminUser = await _userService.GetUserByIdAsync(adminUserId); // Use a user service instead of context

            if (adminUser == null || !adminUser.IsAdmin)
            {
                return Unauthorized("Only admin users can create companies.");
            }

            try
            {
                // Use the company service to create the company
                var company = await _companyService.CreateCompanyAsync(companyDto, adminUser);
                return CreatedAtAction(nameof(CreateCompany), new { id = company.Id }, company);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[HttpPost]
        //public async Task<ActionResult<Company>> AddCompany(Company company)
        //{
        //    var newCompany = await _companyService.AddCompanyAsync(company);
        //    return CreatedAtAction(nameof(GetCompany), new { id = newCompany.Id }, newCompany);
        //}
        [HttpGet]
        public async Task<ActionResult<List<Company>>> GetCompanies()
        {
            // Hardcoded list of companies with projects, users, and assigned tasks
            var companies = new List<Company>
    {
        new Company
        {
            Id = 1,
            Name = "Tech Innovators",
            ProjectLimit = 5,
            UserLimit = 50,
            ActiveUntil = new DateTime(2025, 12, 31),
            Projects = new List<Project>
            {
                new Project
                {
                    Id = 1,
                    Name = "AI Research",
                    Description = "Research and development for AI solutions.",
                    CompanyId = 1,
                    Tasks = new List<TaskItem>
                    {
                        new TaskItem
                        {
                            Id = 1,
                            Description = "Build AI Model",
                            EstimatedHours = 100,
                            EffortHours = 50,
                            Priority = TaskPriority.High,
                            Status = TaskStatus.Canceled
                        },
                        new TaskItem
                        {
                            Id = 2,
                            Description = "Data Collection",
                            EstimatedHours = 30,
                            EffortHours = 15,
                            Priority = TaskPriority.Medium,
                            Status = TaskStatus.Running
                        }
                    }
                }
            },
            Users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Username = "alicej",
                    Password = "pass123",
                    CompanyId = 1,
                    AssignedTasks = new List<TaskItem>
                    {
                        new TaskItem
                        {
                            Id = 1,
                            Description = "Build AI Model",
                            EstimatedHours = 100,
                            EffortHours = 50,
                            Priority = TaskPriority.High,
                            Status = TaskStatus.RanToCompletion
                        }
                    }
                }
            }
        },
        new Company
        {
            Id = 2,
            Name = "Green Energy Corp",
            ProjectLimit = 3,
            UserLimit = 20,
            ActiveUntil = new DateTime(2024, 06, 30),
            Projects = new List<Project>
            {
                new Project
                {
                    Id = 2,
                    Name = "Solar Panel Initiative",
                    Description = "Development of next-gen solar panels.",
                    CompanyId = 2,
                    Tasks = new List<TaskItem>
                    {
                        new TaskItem
                        {
                            Id = 3,
                            Description = "Solar Panel Research",
                            EstimatedHours = 80,
                            EffortHours = 40,
                            Priority = TaskPriority.High,
                            Status = TaskStatus.Running
                        }
                    }
                }
            },
            Users = new List<User>
            {
                new User
                {
                    Id = 3,
                    FirstName = "Charlie",
                    LastName = "Lee",
                    Username = "charliel",
                    Password = "energy2023",
                    CompanyId = 2,
                    AssignedTasks = new List<TaskItem>
                    {
                        new TaskItem
                        {
                            Id = 3,
                            Description = "Solar Panel Research",
                            EstimatedHours = 80,
                            EffortHours = 40,
                            Priority = TaskPriority.High,
                            Status = TaskStatus.Created
                        }
                    }
                }
            }
        }
    };

            return Ok(companies);
        }

    }
}
