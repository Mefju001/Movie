using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUserServices
    {
        Task<List<UserResponse>> GetAllAsync();
        Task<User?> GetById(int id);
        Task<Movie> Add(MovieRequest movie);
        Task<bool> Delete(int id);
        Task<bool> Update(Movie updatedMovie, int id);
    }
}
