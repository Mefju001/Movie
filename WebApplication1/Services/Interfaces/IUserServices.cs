using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IUserServices
    {
        Task<List<UserResponse>> GetAllAsync();
        Task<User?> GetById(int id);
        Task<User> Add(User movie);
        Task<bool> Delete(int id);
        Task<bool> Update(User updatedMovie, int id);
    }
}
