using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Data;
using WebApplication1.DTO.Request;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        public AuthService(IConfiguration config, AppDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _configuration = config;
        }
        public async Task<string>Login(UserRequest userRequest)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.username == userRequest.username);
            if (user == null)
            {
                return null;
            }
            var passwordVerification = _passwordHasher.VerifyHashedPassword(user, user.password, userRequest.password);
            if(passwordVerification == PasswordVerificationResult.Failed)
            {
                return null;
            }
            var token = GenerateJwtToken(userRequest.username, userRequest.password);
            return token;
        }
        public string GenerateJwtToken(string username,string role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role,role.ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
