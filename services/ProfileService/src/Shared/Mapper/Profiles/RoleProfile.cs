using AutoMapper;
using Domain.Models.Role;
using Shared.Mapper.Converters;
using static Domain.Models.Role.RoleModelConstraints;

namespace Shared.Mapper.Profiles
{
    internal class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleVariants, RoleModel>().ConvertUsing<RoleToRoleModelConverter>();
        }
    }
}