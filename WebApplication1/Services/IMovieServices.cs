using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;

public interface IMovieServices
{
    Task<List<MovieResponse>> GetAllAsync();
    Task<MovieResponse?> GetById(int id);
    Task<Movie> Add(MovieRequest movie);
    Task<bool> Delete(int id);
    Task<bool> Update(Movie updatedMovie, int id);
}