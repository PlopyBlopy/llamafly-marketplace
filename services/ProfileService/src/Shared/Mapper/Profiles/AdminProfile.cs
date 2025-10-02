using Domain.Commands;

namespace Shared.Mapper.Profiles
{
    internal class AdminProfile : ProfileDtoProfile
    {
        public AdminProfile()
        {
            CreateMap<CreateAdminRequest, CreateAdminCommand>().ConstructUsing(src => new CreateAdminCommand(src.User, src.Profile, src.Admin));
        }
    }
}