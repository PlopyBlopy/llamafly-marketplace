using Domain.DTO;
using FluentResults;

namespace Domain.Interfaces.Repositories.Products
{
    public interface ICreateProductsRangeRepository
    {
        Task<Result<Guid>> CreateRangeAsync(CreateProductsRangeModelDto dto, CancellationToken ct);
    }
}