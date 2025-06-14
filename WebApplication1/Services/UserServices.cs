using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserServices : IUserServices
    {
        public Task<Movie> Add(MovieRequest movie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MovieResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MovieResponse?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Movie updatedMovie, int id)
        {
            throw new NotImplementedException();
        }
    }
}
