using Domain.DTO;
using FluentResults;

namespace Domain.Interfaces.Repositories.Products
{
    public interface IGetAllProductsCardsFilteredRepository : IRepository
    {
        Task<Result<List<ProductCardDto>>> GetAllCardsFilteredAsync(ProductCardFiltersDto dto, CancellationToken ct);
    }
}