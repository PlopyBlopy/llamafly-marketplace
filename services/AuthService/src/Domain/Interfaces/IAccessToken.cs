using FluentResults;
using static Domain.Models.CommonConstraints;

namespace Domain.Interfaces
{
    public interface IAccessToken
    {
        Result<(string accessToken, DateTime expiresAt)> GenerateAccessToken(Guid userId, RoleVariants userRole);

        Result<bool> ValidateAccessToken(string token);
    }
}