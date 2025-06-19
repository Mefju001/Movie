using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.DTO.Request;

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
        public UserRole UserRoles { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public void setUser(UserRequest userRequest)
        {
            name = userRequest.name;
            surname = userRequest.surname;
            email = userRequest.email;
        }
    }
}
