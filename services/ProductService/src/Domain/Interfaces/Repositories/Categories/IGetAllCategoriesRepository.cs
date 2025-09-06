using Domain.DTO;
using FluentResults;

namespace Domain.Interfaces.Repositories.Categories
{
    public interface IGetAllCategoriesRepository
    {
        Task<Result<List<CategoryWithSubDto>>> GetAllAsync(CancellationToken ct);
    }
}