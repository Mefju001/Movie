using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Review()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required int Rating { get; set; }
        public required string Comment { get; set; }
        public virtual int MovieId { get; set; }
        public void SetReview(Review review)
        {
            this.Rating = review.Rating;
            this.Comment = review.Comment;
            this.MovieId = review.MovieId;
        }
    }
}