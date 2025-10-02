using Domain.Commands;
using Domain.Commands.Services;
using Domain.DTO;
using Domain.DTO.Services;

namespace Shared.Mapper.Profiles
{
    internal class AdminProfile : ProfileDtoProfile
    {
        public AdminProfile()
        {
            CreateMap<AdminDto, CreateAdminDto>().ConstructUsing(src => new CreateAdminDto());

            CreateMap<RegisterAdminRequest, RegisterAdminCommand>().ConstructUsing(src => new RegisterAdminCommand(src.User, src.Profile, src.Admin));
            CreateMap<RegisterAdminCommand, CreateAdminRequest>()
                .ConvertUsing((src, dest, context) => new CreateAdminRequest(
                    context.Mapper.Map<CreateUserDto>(src.User),
                    context.Mapper.Map<CreateProfileDto>(src.Profile),
                    context.Mapper.Map<CreateAdminDto>(src.Admin)
                ));
        }
    }
}