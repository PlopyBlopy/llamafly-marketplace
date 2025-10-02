using Domain.DTO;
using MediatoR.Alternative.Lite;

namespace Domain.Commands
{
    public sealed record RegisterSellerRequest(UserDto User, ProfileDto Profile, SellerDto Seller);
    public sealed record RegisterSellerResponse(Guid UserId);
    public sealed record RegisterSellerCommand(UserDto User, ProfileDto Profile, SellerDto Seller) : ICommand<RegisterSellerResponse>;
}