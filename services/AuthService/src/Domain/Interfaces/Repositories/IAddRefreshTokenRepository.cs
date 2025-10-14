using Domain.Models.RefreshToken;
using FluentResults;

namespace Domain.Interfaces.Repositories
{
    public interface IAddRefreshTokenRepository : IRepository
    {
        Task<Result> AddAsync(RefreshTokenModel model, CancellationToken ct);

        Task<Result> AddSqlAsync(RefreshTokenModel model, CancellationToken ct);
    }
}