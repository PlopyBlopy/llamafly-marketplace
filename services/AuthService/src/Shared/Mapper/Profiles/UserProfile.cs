using Domain.Commands;
using Domain.DTO;
using Domain.Models.Password;

namespace Shared.Mapper.Profiles
{
    internal class UserProfile : ProfileDtoProfile
    {
        public UserProfile()
        {
            CreateMap<UserDto, CreateUserDto>().ConstructUsing(src => new CreateUserDto(src.Login, src.PhoneNumber, src.Email));
            CreateMap<(Guid userId, string passwordHash), PasswordModel>().ConstructUsing(src => new PasswordModel(src.userId, src.passwordHash));

            CreateMap<RegisterUserRequest, RegisterUserCommand>().ConstructUsing(src => new RegisterUserCommand(src.User, src.Profile));
            CreateMap<Guid, RegisterUserResponse>().ConstructUsing(src => new RegisterUserResponse(src));
            CreateMap<RegisterUserCommand, RegisterUserRequest>().ConstructUsing(src => new RegisterUserRequest(src.User, src.Profile));
        }
    }
}