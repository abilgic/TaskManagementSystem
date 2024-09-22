﻿using Microsoft.AspNetCore.Http;
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


    }
}
