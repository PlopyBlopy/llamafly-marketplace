using Domain.Interfaces;
using Domain.Interfaces.Repositories.Products;
using Domain.Product;
using FluentResults;

namespace Shared.Decorators.Сaches
{
    internal class GetByIdProductRepositoryCacheDecorator : IGetByIdProductRepository, ICacheDecorator
    {
        private readonly IGetByIdProductRepository _decorated;
        private readonly ICacheService _cache;

        public GetByIdProductRepositoryCacheDecorator(IGetByIdProductRepository decorated, ICacheService cache)
        {
            _decorated = decorated;
            _cache = cache;
        }

        public async Task<Result<ProductModel>> GetByIdAsync(Guid productId, CancellationToken ct)
        {
            return await _cache.GetOrCreateAsync(Keys.ProductById(productId), async ct => await _decorated.GetByIdAsync(productId, ct), ct);
        }
    }
}