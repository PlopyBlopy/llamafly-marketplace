using FluentResults;

namespace Domain.Interfaces
{
    public interface IRefreshToken
    {
        Task<Result<(string refreshToken, DateTime expiresAt)>> GenerateRefreshTokenAsync(Guid userId, CancellationToken ct);

        Result<bool> ValidateRefreshToken(string token);
    }
}