using Domain.Interfaces;
using FluentResults;
using Microsoft.Extensions.Caching.Hybrid;

namespace Infrastructure.Cache
{
    internal class CacheService : ICacheService
    {
        private readonly HybridCache _cache;

        public CacheService(HybridCache cache)
        {
            _cache = cache;
        }

        //TODO: обработка ответа Result
        public async Task<TResponse> GetOrCreateAsync<TResponse>(string key, Func<CancellationToken, ValueTask<Result<TResponse>>> valueFactory, CancellationToken ct)
        {
            var result = await _cache.GetOrCreateAsync(
                $"{key}",
                async cancelToken =>
                {
                    var functionResult = await valueFactory(cancelToken);

                    if (!functionResult.IsSuccess)
                        throw new Exception($"Operation failed: {functionResult.Errors}");

                    return functionResult.Value;
                },
                cancellationToken: ct
            );

            return result;
        }

        public Task<Result> RemoveAsync<TRequest>(TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Result> RemoveByTagAsync<TRequest>(TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Result> SetAsync<TRequest, TResponse>(TRequest request)
        {
            throw new NotImplementedException();
        }
    }
}