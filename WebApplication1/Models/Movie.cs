using Microsoft.EntityFrameworkCore.Update.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string title { get; set; }
        public required string description { get; set; }
        public virtual Genre genre { get; set; }
        public virtual Director director { get; set; }
        public virtual List<Review> reviews { get; set; }
        public void UpdateMovie(Movie movie)
        {
            title = movie.title;
            description = movie.description;
            genre = movie.genre;
            director = movie.director;
        }
    }
}