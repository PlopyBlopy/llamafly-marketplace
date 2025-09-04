using Domain.DTO;
using FluentResults;

namespace Domain.Interfaces.Repositories.Products
{
    public interface IGetAllProductsCardsRepository
    {
        Task<Result<List<ProductCardDto>>> GetAllCardsAsync(int? limit, CancellationToken ct);
    }
}