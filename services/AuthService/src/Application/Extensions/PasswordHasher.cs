using Domain.Interfaces;
using Domain.Models.Password;
using FluentResults;

namespace Application.Extensions
{
    internal sealed class PasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public Result<bool> Verify(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash) is true
                ? Result.Ok(true)
                : Result.Fail(PasswordModelErrors.IS_NOT_VERIFIED);
        }
    }
}