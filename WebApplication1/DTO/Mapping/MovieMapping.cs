using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;
namespace WebApplication1.DTO.Mapping
{
    public static class MovieMapping
    {
        public static MovieResponse ToResponse(Movie movie)
        {
            return new MovieResponse
            {
                Title = movie.title,
                Description = movie.description,
                Genre = movie.genre.name,
                Director = movie.director.name,
                Reviews = movie.reviews
            };
        }
    }
}