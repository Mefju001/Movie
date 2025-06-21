using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.DTO.Mapping
{
    public static class UserMapping
    {
        public static UserResponse ToResponse(User user)
        {
            return new UserResponse(
                user.username,
                user.password,
                user.name,
                user.surname,
                user.email,
                user.UserRoles.Select(ur => RoleMapping.ToResponse(ur.Role)).ToList(),
                user.Reviews.Select(r => ReviewMapping.ToResponse(r)).ToList());

        }
    }
}
