using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers.Security
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly AuthService authService;
        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest.Username == "admin" && loginRequest.Password == "password")
            {
                var token = authService.GenerateJwtToken(loginRequest.Username, "Admin");
                return Ok(new {Token = token});
            }
            return Unauthorized("Invalid credentials");
        }
    }
}
public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
