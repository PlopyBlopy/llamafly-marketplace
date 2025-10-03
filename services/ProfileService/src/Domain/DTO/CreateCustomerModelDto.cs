using Domain.Models.Customer;
using Domain.Models.Profile;
using Domain.Models.Role;
using Domain.Models.User;
using Domain.Models.UserRole;

namespace Domain.DTO
{
    public sealed record CreateCustomerModelDto(UserModel User, ProfileModel Profile, CustomerModel Customer, RoleModel Role, UserRoleModel UserRole);
}