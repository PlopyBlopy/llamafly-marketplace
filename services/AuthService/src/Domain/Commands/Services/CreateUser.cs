using Domain.DTO;

namespace Domain.Commands.Services
{
    public sealed record CreateUserRequest(CreateUserDto User, CreateProfileDto Profile);
    public sealed record CreateUserResponse(Guid UserId);
}