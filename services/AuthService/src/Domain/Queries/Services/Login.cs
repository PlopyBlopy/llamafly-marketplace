using static Domain.Models.CommonConstraints;

namespace Domain.Queries.Services
{
    public sealed record LoginRequest(string LoginValue, LoginVariants LoginType);
    public sealed record LoginResponse(bool IsVerified, Guid UserId, RoleVariants UserRole);
}