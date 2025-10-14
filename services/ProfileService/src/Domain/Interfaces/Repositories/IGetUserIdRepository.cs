using Domain.DTO;
using FluentResults;

namespace Domain.Interfaces.Repositories
{
    public interface IGetUserIdRepository : IRepository
    {
        Task<Result<LoginResultDto>> GetAsync(LoginDto dto, CancellationToken ct);

        Task<Result<LoginResultDto>> GetQueryAsync(LoginDto dto, CancellationToken ct);

        Task<Result<LoginResultDto>> GetSqlAsync(LoginDto dto, CancellationToken ct);
    }
}