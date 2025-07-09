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
                movie.title,
                movie.description,
                movie.genre.name?? "nieznany rodzaj",
                movie.director.name ??"Nieznany autor",
                movie.director.surname ?? "Nieznany autor",
                movie.reviews?.Select(r => ReviewMapping.ToResponse(r)).ToList() ?? new List<ReviewResponse>());
        }
    }
}