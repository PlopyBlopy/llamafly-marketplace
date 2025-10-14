using AutoMapper;

namespace Shared.Mapper.Profiles
{
    internal class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            //CreateMap<RoleVariants, UserRoleModel>().ConstructUsing((src, context) => new UserRoleModel())
        }
    }
}