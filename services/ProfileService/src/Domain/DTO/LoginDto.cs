using static Domain.Models.User.UserModelConstraints;

namespace Domain.DTO
{
    public sealed record LoginDto(string LoginValue, LoginVariants LoginType);
}