using Domain.DTO.Services;

namespace Domain.Commands.Services
{
    public sealed record CreateCustomerRequest(CreateUserDto User, CreateProfileDto Profile, CreateCustomerDto Customer);
    public sealed record CreateCustomerResponse(Guid UserId);
}