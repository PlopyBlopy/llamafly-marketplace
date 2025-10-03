using Domain.DTO;
using MediatoR.Alternative.Lite;

namespace Domain.Commands
{
    public sealed record CreateSellerRequest(CreateUserDto User, CreateProfileDto Profile, CreateSellerDto Seller);
    public sealed record CreateSellerResponse(Guid UserId);
    public sealed record CreateSellerCommand(CreateUserDto User, CreateProfileDto Profile, CreateSellerDto Seller) : ICommand<CreateSellerResponse>;
}