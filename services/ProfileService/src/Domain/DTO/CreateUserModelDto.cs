using Domain.Models.Profile;
using Domain.Models.Role;
using Domain.Models.User;
using Domain.Models.UserRole;

namespace Domain.DTO
{
    public sealed record CreateUserModelDto(UserModel User, ProfileModel Profile, RoleModel Role, UserRoleModel UserRole);
}