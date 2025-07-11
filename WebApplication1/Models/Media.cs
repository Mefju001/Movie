using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Media
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public virtual required Genre Genre { get; set; }
        public virtual required Director Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Language { get; set; }
        public virtual List<Review> Reviews { get; set; } = [];
    }
}
