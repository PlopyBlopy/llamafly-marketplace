using Domain.Commands.Products;
using Domain.Product;
using FluentResults;

namespace Domain.Interfaces.Repositories.Products
{
    public interface IUpdateProductRepository
    {
        Task<Result<ProductModel>> UpdateAsync(UpdateProductCommand command, CancellationToken ct);
    }
}