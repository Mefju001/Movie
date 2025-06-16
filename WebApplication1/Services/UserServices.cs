using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTO.Mapping;
using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserServices : IUserServices
    {
        private AppDbContext dbContext;
        public UserServices(AppDbContext dbContext) {
            this.dbContext = dbContext;
        }
        public Task<Movie> Add(MovieRequest movie)
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
                .ToListAsync();
            return users.Select(UserMapping.ToResponse).ToList();
        }

        public Task<User?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Movie updatedMovie, int id)
        {
            throw new NotImplementedException();
        }
    }
}
