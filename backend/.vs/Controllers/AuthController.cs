using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MessagingSystemAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MessagingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User { UserId = "123456789" },
            new User { UserId = "987654321" },
            new User { UserId = "111111111" },
            new User { UserId = "222222222" },
            new User { UserId = "333333333" },
            new User { UserId = "444444444" },
            new User { UserId = "303202505" },
            new User { UserId = "605980589" },
            new User { UserId = "253544545" }
        };


        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] User user)
        {
            if (string.IsNullOrWhiteSpace(user.UserId))
            {
                return BadRequest(new { error = "UserId is required" });
            }

            var authenticated = users.Any(u => u.UserId == user.UserId);
            if (authenticated)
            {
                var token = GenerateJwtToken(user.UserId);
                return Ok(new { token });
            }

            return Unauthorized();
        }
        private string GenerateJwtToken(string userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this_is_a_very_secure_key_123456789012"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, userId)
    };

            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }
}
