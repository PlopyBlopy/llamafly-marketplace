using Domain.Product;
using Domain.Queries.Products;
using FluentResults;

namespace Domain.Interfaces.Repositories
{
    public interface IGetByIdProductRepository
    {
        Task<Result<ProductModel>> GetByIdAsync(GetByIdProductQuery query, CancellationToken ct);
    }
}