using Domain.DTO;
using FluentResults;

namespace Domain.Interfaces.Repositories
{
    public interface IGetUserIdRepository : IRepository
    {
        Task<Result<Guid>> GetAsync(LoginDto dto, CancellationToken ct);

        Task<Result<Guid>> GetQueryAsync(LoginDto dto, CancellationToken ct);

        Task<Result<Guid>> GetSqlAsync(LoginDto dto, CancellationToken ct);
    }
}