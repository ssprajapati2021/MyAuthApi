using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyAuthApi.NewFolder;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserInfo user)
        {
            if (user.Username == "test" && user.Password == "1234")
            {
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString("yyyy-MM-dd")),
                new Claim(ClaimTypes.Country, user.Country)
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super_secret_key_that_is_very_long_123456"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: null,
                    audience: null,
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }
    }
}
