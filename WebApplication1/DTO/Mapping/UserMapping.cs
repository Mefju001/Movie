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
                user.username,
                user.surname,
                user.email,
                RoleMapping.ToResponse(user.UserRoles.Role),
                user.Reviews.Select(r=>ReviewMapping.ToResponse(r)).ToList());

        }
    }
}
