using AutoMapper;
using Domain.Commands;
using Domain.DTO;
using Domain.Models.Profile;
using Domain.Models.Role;
using Domain.Models.Seller;
using Domain.Models.User;
using Domain.Models.UserRole;
using Shared.Extensions;
using static Domain.Models.Role.RoleModelConstraints;

namespace Shared.Mapper.Converters
{
    internal class CreateSellerCommandToCreateDtoConverter : ITypeConverter<CreateSellerCommand, CreateSellerModelDto>
    {
        public CreateSellerModelDto Convert(CreateSellerCommand source, CreateSellerModelDto destination, ResolutionContext context)
        {
            var userModel = context.Mapper.Map<UserModel>(source.User);
            var profileModel = context.Mapper.Map<ProfileModel>(source.Profile);
            var sellerModel = context.Mapper.Map<SellerModel>(source.Seller);
            var roleModel = context.Mapper.Map<RoleModel>(Roles.Seller);

            var userId = context.GetRequiredItem<Guid>(ContextKeys.UserId);
            var roleId = context.GetRequiredItem<Guid>(ContextKeys.RoleId);

            var userRoleModel = new UserRoleModel(userId, roleId);

            return new CreateSellerModelDto(userModel, profileModel, sellerModel, roleModel, userRoleModel);
        }
    }
}