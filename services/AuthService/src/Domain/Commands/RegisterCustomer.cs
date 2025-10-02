using Domain.DTO;
using MediatoR.Alternative.Lite;

namespace Domain.Commands
{
    public sealed record RegisterCustomerRequest(UserDto User, ProfileDto Profile, CustomerDto Customer);
    public sealed record RegisterCustomerResponse(Guid UserId);
    public sealed record RegisterCustomerCommand(UserDto User, ProfileDto Profile, CustomerDto Customer) : ICommand<RegisterCustomerResponse>;
}