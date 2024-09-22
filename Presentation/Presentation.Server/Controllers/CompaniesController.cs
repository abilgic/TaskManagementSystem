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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            // Returning an empty list explicitly
            return Ok(new List<Company>());
        }
        [HttpPost]
        public async Task<ActionResult<Company>> AddCompany([FromBody] CompanyDto companyDto)
        {
            if (companyDto == null)
            {
                return BadRequest("Company data is required.");
            }

            var newCompany = new Company
            {
                Name = companyDto.Name,
                UserLimit = companyDto.UserLimit,
                ProjectLimit = companyDto.ProjectLimit,
                ActiveUntil = companyDto.ActiveUntil
            };

            //await _companyService.AddCompanyAsync(newCompany); // Call the service to add the company

            return CreatedAtAction(nameof(GetCompanies), new { id = newCompany.Id }, newCompany); // Return the created company
        }

    }
}
