using WebApplication1.Models;

public interface IMovieServices
{
    Task<List<Movie>> GetAllAsync();
    Task<Movie?> GetById(int id);
    Task<Movie> Add(Movie movie);
    Task<bool> Delete(int id);
    Task<bool> Update(Movie updatedMovie, int id);
}