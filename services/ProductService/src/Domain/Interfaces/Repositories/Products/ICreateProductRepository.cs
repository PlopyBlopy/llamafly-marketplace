using Domain.Product;
using FluentResults;

namespace Domain.Interfaces.Repositories.Products
{
    public interface ICreateProductRepository : IRepository
    {
        Task<Result<Guid>> CreateAsync(ProductModel model, CancellationToken ct);
    }
}