using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http; // Add this line

namespace TaskManagement.Application.Services
{
    public class LoginService:ILoginService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        public LoginService(IRepository<User> userRepository, IConfiguration configuration)
        {
            _userRepository=userRepository;
            _configuration=configuration;
        }
        public async Task<string> AuthenticateAsync(string username, string password)
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user == null)
                {
                    return null;
                }

                var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserId", user.Id.ToString()),
                new Claim("IsAdmin", user.IsAdmin.ToString())
            };

                foreach (var role in user.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {
                // Handle exceptions appropriately
                throw;
            }
        }
    }
}
