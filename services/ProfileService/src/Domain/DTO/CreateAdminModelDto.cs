using Domain.Models.Admin;
using Domain.Models.Profile;
using Domain.Models.Role;
using Domain.Models.User;
using Domain.Models.UserRole;

namespace Domain.DTO
{
    public sealed record CreateAdminModelDto(UserModel User, ProfileModel Profile, AdminModel Admin, RoleModel Role, UserRoleModel UserRole);
}