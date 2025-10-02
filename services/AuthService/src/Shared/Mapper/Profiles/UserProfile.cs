using Domain.DTO;
using Domain.DTO.Services;
using Domain.Models.Password;

namespace Shared.Mapper.Profiles
{
    internal class UserProfile : ProfileDtoProfile
    {
        public UserProfile()
        {
            CreateMap<UserDto, CreateUserDto>().ConstructUsing(src => new CreateUserDto(src.Login, src.PhoneNumber, src.Email));
            CreateMap<(Guid userId, string passwordHash), PasswordModel>().ConstructUsing(src => new PasswordModel(src.userId, src.passwordHash));
        }
    }
}