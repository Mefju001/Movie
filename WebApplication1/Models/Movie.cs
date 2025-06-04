using Microsoft.EntityFrameworkCore.Update.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Movie()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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