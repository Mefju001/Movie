using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Review()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int MovieId { get; set; }
        public void SetReview(Review review)
        {
            this.Rating = review.Rating;
            this.Comment = review.Comment;
            this.MovieId = review.MovieId;
        }
    }
}