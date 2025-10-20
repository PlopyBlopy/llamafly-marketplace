using Domain.Category;
using Domain.Interfaces;
using Domain.Interfaces.Repositories.Categories;
using FluentResults;

namespace Shared.Decorators.Сaches
{
    internal class GetByIdCategoryRepositoryCacheDecorator : IGetByIdCategoryRepository, ICacheDecorator
    {
        private readonly IGetByIdCategoryRepository _decorated;
        private readonly ICacheService _cache;

        public GetByIdCategoryRepositoryCacheDecorator(IGetByIdCategoryRepository decorated, ICacheService cache)
        {
            _decorated = decorated;
            _cache = cache;
        }

        public async Task<Result<CategoryModel>> GetByIdAsync(Guid categoryId, CancellationToken ct)
        {
            return await _cache.GetOrCreateAsync(Keys.CategoryById(categoryId), async ct => await _decorated.GetByIdAsync(categoryId, ct), ct);
        }
    }
}