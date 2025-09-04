using Domain.DTO;
using FluentResults;

namespace Domain.Interfaces.Repositories.Products
{
    public interface IGetAllProductsCardsFilteredRepository
    {
        Task<Result<List<ProductCardDto>>> GetAllCardsFilteredAsync(ProductCardFiltersDto dto, CancellationToken ct);
    }
}