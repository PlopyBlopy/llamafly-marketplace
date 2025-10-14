using MediatoR.Alternative.Lite;
using static Domain.Models.CommonConstraints;

namespace Domain.Queries
{
    public sealed record LoginUserResponse(string AccessToken, string RefreshToken, DateTime AccessTokenExpiresAt, DateTime RefreshTokenExpiresAt);
    public sealed record LoginUserQuery(string LoginValue, LoginVariants LoginType, string Password) : IQuery<LoginUserResponse>;
}