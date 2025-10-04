using FluentResults;

namespace Domain.Interfaces.Repositories
{
    public interface ICheckPasswordRepository : IRepository
    {
        Task<Result<string>> CheckPasswordAsync(Guid userId, CancellationToken ct);
    }
}