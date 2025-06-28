using Domain.Product;
using FluentResults;

namespace Domain.Interfaces.Repositories
{
    public interface ICreateProductRepository
    {
        Task<Result<Guid>> CreateAsync(ProductModel model, CancellationToken ct);
    }
}