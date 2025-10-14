using FluentResults;

namespace Domain.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string password);

        Result<bool> Verify(string password, string passwordHash);
    }
}