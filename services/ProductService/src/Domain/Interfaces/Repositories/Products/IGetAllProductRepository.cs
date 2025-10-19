using Domain.Queries.Products;
using FluentResults;

namespace Domain.Interfaces.Repositories.Products
{
    public interface IGetAllProductRepository : IRepository
    {
        Task<Result<GetAllProductsResponse>> GetAllAsync(CancellationToken ct);
    }
}