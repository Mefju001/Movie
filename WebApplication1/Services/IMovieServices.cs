using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;

public interface IMovieServices
{
    Task<List<user>> GetAllAsync();
    Task<List<user>> GetSortAll(string sort);
    Task<List<user>> GetMoviesByAvrRating();
    Task<List<user>> GetMovies(string? name, string? genreId, string? directorId,int?movieid);
    Task<user?> GetById(int id);
    Task<Movie> Add(MovieRequest movie);
    Task<bool> Delete(int id);
    Task<bool> Update(MovieRequest updatedMovie, int id);
}