using Domain.DTO;
using Domain.Interfaces;
using Domain.Interfaces.Repositories.Categories;
using FluentResults;

namespace Shared.Decorators.Сaches
{
    internal class GetAllCategoriesMinRepositoryCacheDecorator : IGetAllCategoriesMinRepository, ICacheDecorator
    {
        private readonly IGetAllCategoriesMinRepository _decorated;
        private readonly ICacheService _cache;

        public GetAllCategoriesMinRepositoryCacheDecorator(IGetAllCategoriesMinRepository decorated, ICacheService cache)
        {
            _decorated = decorated;
            _cache = cache;
        }

        public async Task<Result<List<CategoryWithSubMinDto>>> GetAllMinAsync(CancellationToken ct)
        {
            return await _cache.GetOrCreateAsync(Keys.ALL_CATEGORIES_MIN, async ct => await _decorated.GetAllMinAsync(ct), ct);
        }
    }
}