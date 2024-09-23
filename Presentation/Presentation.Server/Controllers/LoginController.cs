using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.DTO;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Services;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest)
        {
            var token = await _loginService.AuthenticateAsync(loginRequest.Username, loginRequest.Password);
            if (token == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(new { Token = token });
        }
    }


}
