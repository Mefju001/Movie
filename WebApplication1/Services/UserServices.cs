using Microsoft.EntityFrameworkCore;
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
        private AppDbContext dbContext;
        public UserServices(AppDbContext dbContext) {
            this.dbContext = dbContext;
        }
        public Task<UserResponse> Add(UserRequest userRequest)
        {
            throw new NotImplementedException();
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
