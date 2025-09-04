using Domain.Category;
using FluentResults;

namespace Domain.Interfaces.Repositories.Categories
{
    public interface IGetByIdCategoryRepository
    {
        Task<Result<CategoryModel>> GetByIdAsync(Guid categoryId, CancellationToken ct);
    }
}