using Domain.Queries.Products.GetAll;
using FluentResults;

namespace Domain.Interfaces.Repositories
{
    public interface IGetAllProductRepository
    {
        Task<Result<GetAllProductResponse>> GetAllAsync(CancellationToken ct);
    }
}