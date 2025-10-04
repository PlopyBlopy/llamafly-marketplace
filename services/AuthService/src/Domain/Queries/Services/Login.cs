namespace Domain.Queries.Services
{
    public sealed record LoginRequest(string LoginValue, LoginType LoginType);
    public sealed record LoginResponse(bool IsVerified, Guid UserId);

    public enum LoginType
    {
        Login,
        PhoneNumber,
        Email
    }
}