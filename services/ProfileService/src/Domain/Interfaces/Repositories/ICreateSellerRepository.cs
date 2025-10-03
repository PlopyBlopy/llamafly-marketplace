using Domain.DTO;
using FluentResults;

namespace Domain.Interfaces.Repositories
{
    public interface ICreateSellerRepository : IRepository
    {
        Task<Result<Guid>> AddAsync(CreateSellerModelDto model, CancellationToken ct);
    }
}