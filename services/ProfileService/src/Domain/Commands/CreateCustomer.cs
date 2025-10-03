using Domain.DTO;
using MediatoR.Alternative.Lite;

namespace Domain.Commands
{
    public sealed record CreateCustomerRequest(CreateUserDto User, CreateProfileDto Profile, CreateCustomerDto Customer);
    public sealed record CreateCustomerResponse(Guid UserId);
    public sealed record CreateCustomerCommand(CreateUserDto User, CreateProfileDto Profile, CreateCustomerDto Customer) : ICommand<CreateCustomerResponse>;
}