using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public required string username { get; set; }
        public required string password { get; set; }
        public required string name { get; set; }
        public required string surname { get; set; }
        public required string email { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public List<Review> Reviews { get; set; } = new List<Review>();

    }
}
