using AutoMapper;
using Domain.Models.Role;
using Shared.Extensions;
using static Domain.Models.Role.RoleModelConstraints;

namespace Shared.Mapper.Converters
{
    internal class RoleToRoleModelConverter : ITypeConverter<RoleVariants, RoleModel>
    {
        public RoleModel Convert(RoleVariants source, RoleModel destination, ResolutionContext context)
        {
            var roleId = context.GetRequiredItem<Guid>(ContextKeys.RoleId);

            var roleModel = new RoleModel(roleId, source);

            return roleModel;
        }
    }
}