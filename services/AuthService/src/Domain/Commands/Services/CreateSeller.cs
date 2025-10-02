using Domain.DTO.Services;

namespace Domain.Commands.Services
{
    public sealed record CreateSellerRequest(CreateUserDto User, CreateProfileDto Profile, CreateSellerDto Seller);
    public sealed record CreateSellerResponse(Guid UserId);
}