using Domain.DTO;
using FluentResults;

namespace Domain.Interfaces.Repositories
{
    public interface ICreateAdminRepository : IRepository
    {
        Task<Result<Guid>> AddAsync(CreateAdminModelDto model, CancellationToken ct);
    }
}