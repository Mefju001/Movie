using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;

public interface IMovieServices
{
    Task<List<MovieResponse>> GetAllAsync();
    Task<List<MovieResponse>> GetSortAll(string sort);
    Task<List<MovieResponse>> GetMoviesByAvrRating();
    Task<List<MovieResponse>> GetMovies(string? name, string? genreId, string? directorId,int?movieid);
    Task<MovieResponse?> GetById(int id);
    Task<MovieResponse> Add(MovieRequest movie);
    Task<bool> Delete(int id);
    Task<bool> Update(MovieRequest updatedMovie, int id);
}