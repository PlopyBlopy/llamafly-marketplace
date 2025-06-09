using Domain.Product;
using FluentResults;

namespace Domain.Interfaces
{
    public interface ICreateProductRepository
    {
        Task<Result<Guid>> CreateAsync(ProductModel product);
    }
}