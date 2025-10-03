using AutoMapper;
using Domain.Commands;
using Domain.DTO;
using Domain.Models.Customer;
using Domain.Models.Profile;
using Domain.Models.Role;
using Domain.Models.User;
using Domain.Models.UserRole;
using Shared.Extensions;
using static Domain.Models.Role.RoleModelConstraints;

namespace Shared.Mapper.Converters
{
    internal class CreateCustomerCommandToCreateDtoConverter : ITypeConverter<CreateCustomerCommand, CreateCustomerModelDto>
    {
        public CreateCustomerModelDto Convert(CreateCustomerCommand source, CreateCustomerModelDto destination, ResolutionContext context)
        {
            var userModel = context.Mapper.Map<UserModel>(source.User);
            var profileModel = context.Mapper.Map<ProfileModel>(source.Profile);
            var customerModel = context.Mapper.Map<CustomerModel>(source.Customer);
            var roleModel = context.Mapper.Map<RoleModel>(Roles.Admin);

            var userId = context.GetRequiredItem<Guid>(ContextKeys.UserId);
            var roleId = context.GetRequiredItem<Guid>(ContextKeys.RoleId);

            var userRoleModel = new UserRoleModel(userId, roleId);

            return new CreateCustomerModelDto(userModel, profileModel, customerModel, roleModel, userRoleModel);
        }
    }
}