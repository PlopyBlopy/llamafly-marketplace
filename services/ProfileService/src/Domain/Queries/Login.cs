using MediatoR.Alternative.Lite;
using static Domain.Models.Role.RoleModelConstraints;
using static Domain.Models.User.UserModelConstraints;

namespace Domain.Queries
{
    public sealed record LoginResponse(bool IsVerified, Guid UserId, RoleVariants UserRole);
    public sealed record LoginQuery(string LoginValue, LoginVariants LoginType) : IQuery<LoginResponse>;
}