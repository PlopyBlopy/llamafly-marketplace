using Domain.DTO;
using MediatoR.Alternative.Lite;

namespace Domain.Commands
{
    public sealed record CreateAdminRequest(CreateUserDto User, CreateProfileDto Profile, CreateAdminDto Admin);
    public sealed record CreateAdminResponse(Guid UserId);
    public sealed record CreateAdminCommand(CreateUserDto User, CreateProfileDto Profile, CreateAdminDto Admin) : ICommand<CreateAdminResponse>;
}