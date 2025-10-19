using Domain.Product;
using Domain.Queries.Products;
using FluentResults;

namespace Domain.Interfaces.Repositories.Products
{
    public interface IGetByIdProductRepository : IRepository
    {
        Task<Result<ProductModel>> GetByIdAsync(GetByIdProductQuery query, CancellationToken ct);
    }
}