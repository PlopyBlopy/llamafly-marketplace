using Domain.DTO;
using MediatoR.Alternative.Lite;

namespace Domain.Commands
{
    public sealed record RegisterAdminRequest(UserDto User, ProfileDto Profile, AdminDto Admin);
    public sealed record RegisterAdminResponse(Guid UserId);
    public sealed record RegisterAdminCommand(UserDto User, ProfileDto Profile, AdminDto Admin) : ICommand<RegisterAdminResponse>;
}