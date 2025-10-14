using Domain.DTO;
using MediatoR.Alternative.Lite;

namespace Domain.Commands
{
    public sealed record RegisterUserRequest(UserDto User, ProfileDto Profile);
    public sealed record RegisterUserResponse(Guid UserId);
    public sealed record RegisterUserCommand(UserDto User, ProfileDto Profile) : ICommand<RegisterUserResponse>;
}