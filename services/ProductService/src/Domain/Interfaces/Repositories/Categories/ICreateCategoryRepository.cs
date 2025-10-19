using Domain.Category;
using FluentResults;

namespace Domain.Interfaces.Repositories.Categories
{
    public interface ICreateCategoryRepository : IRepository
    {
        Task<Result<Guid>> CreateAsync(CategoryModel model, CancellationToken ct);
    }
}