using Microsoft.EntityFrameworkCore.Update.Internal;

namespace WebApplication1.Models
{
    public class Movie()
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Genre genre { get; set; }
        public Director director { get; set; }
        public List<Review> reviews { get; set; }
        public void updateMovie(Movie movie)
        {
            title = movie.title;
            description = movie.description;
            genre = movie.genre;
            director = movie.director;
        }
    }
}