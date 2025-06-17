using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.DTO.Request;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers.Security
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly AuthService authService;
        private readonly AppDbContext appDbContext;
        private readonly IPasswordHasher<User>passwordHasher;
        public AuthController(AuthService authService, AppDbContext appDbContext,IPasswordHasher<User>password)
        {
            this.authService = authService;
            this.appDbContext = appDbContext;
            this.passwordHasher = password;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserRequest loginRequest)
        {
            var token = await authService.Login(loginRequest);
            if (token == null)
            {
                return Unauthorized("Nieprawidłowe dane");
            }
            return Ok(new {Token =  token});
        }
        [HttpPost("AddRolesAndUsers")]
        public async Task<IActionResult> AddUserAndRole()
        {
            var User = new User { username = "Mati",password = passwordHasher.HashPassword(null,"Starwars2"),name = "Mateusz",surname = "Jureczko",email = "jureczkomateusz@wp.pl"};
            var Role = new Role { role = ERole.User };

            appDbContext.Users.Add(User);
            appDbContext.Roles.Add(Role);
            await appDbContext.SaveChangesAsync();
            var UserRole = new UserRole
            {
                UserId = User.Id,
                RoleId = Role.Id
            };
            appDbContext.UsersRoles.Add(UserRole);
            await appDbContext.SaveChangesAsync();
            return Ok("Dane zostały dodane.");
        }
    }
}
public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
