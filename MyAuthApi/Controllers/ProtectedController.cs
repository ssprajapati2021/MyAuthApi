using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        [HttpGet("secure")]
        [Authorize(Policy = "AdultFromIndia")]
        public IActionResult GetSecureData()
        {
            return Ok("You are over 18 and from India!");
        }
        [Authorize]
        [HttpGet("testclaims")]      
        public IActionResult TestClaims()
        {
            return Ok(User.Claims.Select(c => new { c.Type, c.Value }));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("admin/data")]
        public IActionResult GetAdminData()
        {
            return Ok("Hello Admin, here is your secret data.");
        }
        [Authorize(Roles = "Admin", Policy = "AdultFromIndia")]
        [HttpGet("adminPolicy/data")]
        public IActionResult GetAdminWithPolicy()
        {
            return Ok("Hello Admin, here is your secret data.");
        }
    }
}
