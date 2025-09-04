using Domain.Queries.Products;
using FluentResults;

namespace Domain.Interfaces.Repositories.Products
{
    public interface IGetAllProductRepository
    {
        Task<Result<GetAllProductsResponse>> GetAllAsync(CancellationToken ct);
    }
}