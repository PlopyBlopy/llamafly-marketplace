using AutoMapper;
using Domain.Models.Role;
using Shared.Extensions;
using static Domain.Models.Role.RoleModelConstraints;

namespace Shared.Mapper.Converters
{
    internal class RoleToRoleModelConverter : ITypeConverter<Roles, RoleModel>
    {
        public RoleModel Convert(Roles source, RoleModel destination, ResolutionContext context)
        {
            var roleId = context.GetRequiredItem<Guid>(ContextKeys.RoleId);

            var roleModel = new RoleModel(roleId, source);

            return roleModel;
        }
    }
}