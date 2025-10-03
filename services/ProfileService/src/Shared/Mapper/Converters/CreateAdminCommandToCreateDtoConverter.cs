using AutoMapper;
using Domain.Commands;
using Domain.DTO;
using Domain.Models.Admin;
using Domain.Models.Profile;
using Domain.Models.Role;
using Domain.Models.User;
using Domain.Models.UserRole;
using Shared.Extensions;
using static Domain.Models.Role.RoleModelConstraints;

namespace Shared.Mapper.Converters
{
    internal class CreateAdminCommandToCreateDtoConverter : ITypeConverter<CreateAdminCommand, CreateAdminModelDto>
    {
        public CreateAdminModelDto Convert(CreateAdminCommand src, CreateAdminModelDto destination, ResolutionContext context)
        {
            var userModel = context.Mapper.Map<UserModel>(src.User);
            var profileModel = context.Mapper.Map<ProfileModel>(src.Profile);
            var adminModel = context.Mapper.Map<AdminModel>(src.Admin);
            var roleModel = context.Mapper.Map<RoleModel>(Roles.Admin);

            var userId = context.GetRequiredItem<Guid>(ContextKeys.UserId);
            var roleId = context.GetRequiredItem<Guid>(ContextKeys.RoleId);

            var userRoleModel = new UserRoleModel(userId, roleId);

            return new CreateAdminModelDto(userModel, profileModel, adminModel, roleModel, userRoleModel);
        }
    }
}