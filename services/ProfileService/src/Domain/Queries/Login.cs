using MediatoR.Alternative.Lite;

namespace Domain.Queries
{
    public sealed record LoginResponse(bool IsVerified, Guid UserId);
    public sealed record LoginQuery(string LoginValue, LoginType LoginType) : IQuery<LoginResponse>;

    public enum LoginType
    {
        Login,
        PhoneNumber,
        Email
    }
}