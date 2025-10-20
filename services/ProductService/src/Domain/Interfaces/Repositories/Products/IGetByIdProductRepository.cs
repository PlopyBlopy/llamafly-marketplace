using Domain.Product;
using FluentResults;

namespace Domain.Interfaces.Repositories.Products
{
    public interface IGetByIdProductRepository : IRepository
    {
        Task<Result<ProductModel>> GetByIdAsync(Guid productId, CancellationToken ct);
    }
}