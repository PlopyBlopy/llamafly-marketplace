using Domain.Models.Profile;
using Domain.Models.Role;
using Domain.Models.Seller;
using Domain.Models.User;
using Domain.Models.UserRole;

namespace Domain.DTO
{
    public sealed record CreateSellerModelDto(UserModel User, ProfileModel Profile, SellerModel Seller, RoleModel Role, UserRoleModel UserRole);
}