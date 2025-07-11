using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;
namespace WebApplication1.DTO.Mapping
{
    public static class MovieMapping
    {
        public static MovieResponse ToResponse(Movie movie)
        {
            return new MovieResponse(
                movie.Title,
                movie.Description,
                GenreMapping.ToResponse(movie.Genre),
                DirectorMapping.ToResponse(movie.Director),
                movie.ReleaseDate,
                movie.Language,
                movie.Reviews?.Select(r => ReviewMapping.ToResponse(r)).ToList() ?? new List<ReviewResponse>(),
                movie.Duration,
                movie.IsCinemaRelease);
        }
    }
}