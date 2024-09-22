using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // Example endpoint to get users
        [HttpGet]
        public IActionResult GetUsers()
        {
            // Logic to retrieve users
            return Ok(new List<string> { "User1", "User2" });
        }
    }
}
