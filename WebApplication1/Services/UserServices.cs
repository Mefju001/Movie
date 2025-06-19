using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Data;
using WebApplication1.DTO.Mapping;
using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class UserServices : IUserServices
    {
        private readonly IPasswordHasher<User> Hasher;
        private AppDbContext dbContext;
        public UserServices(AppDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            this.dbContext = dbContext;
            Hasher = passwordHasher;
        }
        public Task<UserResponse> Add(UserRequest userRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> changePassword(string newPassword, string confirmPassword, string oldPassword, int userId)
        {
            if (!string.IsNullOrEmpty(newPassword) && !string.IsNullOrEmpty(confirmPassword) && !string.IsNullOrEmpty(oldPassword))
            {
                var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
                if (user != null)
                {
                    var passwordVerification = Hasher.VerifyHashedPassword(user, user.password, oldPassword);
                    if (string.Equals(newPassword,confirmPassword,StringComparison.Ordinal) && passwordVerification.Equals(PasswordVerificationResult.Success)&&!string.Equals(oldPassword, newPassword,StringComparison.Ordinal))
                    {
                        user.password = Hasher.HashPassword(user, newPassword);
                        await dbContext.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        public async Task<bool>changedetails(int userId, UserRequest userRequest)
        {
            var emailExists = await dbContext.Users.AnyAsync(u=>u.email == userRequest.email&&u.Id!=userId);
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user is null || emailExists)
                return false;
                user.setUser(userRequest);
                await dbContext.SaveChangesAsync();
            return true;
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserResponse>> GetAllAsync()
        {
            var users = await dbContext.Users
                .Include(u=>u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .Include(u=>u.Reviews)
                .ThenInclude(r=>r.Movie)
                .ToListAsync();
            return users.Select(UserMapping.ToResponse).ToList();
        }

        public Task<UserResponse?> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Update(UserRequest userRequest, int id)
        {
            throw new NotImplementedException();
        }
    }
}
