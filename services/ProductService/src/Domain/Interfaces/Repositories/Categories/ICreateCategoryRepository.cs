using Domain.Category;
using FluentResults;

namespace Domain.Interfaces.Repositories.Categories
{
    public interface ICreateCategoryRepository
    {
        Task<Result<Guid>> CreateAsync(CategoryModel model, CancellationToken ct);
    }
}