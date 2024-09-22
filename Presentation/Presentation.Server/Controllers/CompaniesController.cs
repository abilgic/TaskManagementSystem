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
            var companies = await _companyService.GetAllAsync(); // Assuming this method exists
            return Ok(companies);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> AddCompany([FromBody] CompanyDto companyDto)
        {
            if (companyDto == null)
            {
                return BadRequest("Company data is required.");
            }

            // Call the service to create the company and return the created entity with Id
            var newCompany = await _companyService.CreateAsync(companyDto);

            // Return a 201 Created response with the location of the new company and the company details
            return CreatedAtAction(nameof(GetCompanies), new { id = newCompany.Id }, newCompany);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            // Check if the company exists
            var company = await _companyService.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound($"Company with ID {id} not found.");
            }

            // Call the service to delete the company
            await _companyService.DeleteAsync(id);

            // Return a No Content response indicating successful deletion
            return NoContent();
        }


    }
}
