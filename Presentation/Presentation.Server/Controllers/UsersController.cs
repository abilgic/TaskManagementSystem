using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.DTO;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Get all users
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // Get user by id
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //// Authenticate user
        //[HttpPost("authenticate")]
        //public async Task<ActionResult<string>> Authenticate([FromBody] LoginModel login)
        //{
        //    var token = await _userService.AuthenticateAsync(login.Username, login.Password);
        //    return Ok(token);
        //}

        // Get current user
        [HttpGet("me")]
        public async Task<ActionResult<User>> GetCurrentUser()
        {
            var user = await _userService.GetCurrentUserAsync();
            return Ok(user);
        }

        // Create a new user
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User newUser)
        {
            var user = await _userService.CreateUserAsync(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }
    }

    
}
