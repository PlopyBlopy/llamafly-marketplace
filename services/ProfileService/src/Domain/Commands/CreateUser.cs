using Domain.DTO;
using MediatoR.Alternative.Lite;

namespace Domain.Commands
{
    public sealed record CreateUserRequest(CreateUserDto User, CreateProfileDto Profile);
    public sealed record CreateUserResponse(Guid UserId);
    public sealed record CreateUserCommand(CreateUserDto User, CreateProfileDto Profile) : ICommand<CreateUserResponse>;
}