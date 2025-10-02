using Domain.DTO.Services;

namespace Domain.Commands.Services
{
    public sealed record CreateAdminRequest(CreateUserDto User, CreateProfileDto Profile, CreateAdminDto Admin);
    public sealed record CreateAdminResponse(Guid UserId);
}