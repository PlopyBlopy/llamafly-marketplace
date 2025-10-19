using FluentResults;

namespace Domain.Interfaces
{
    public interface ICacheService
    {
        Task<Result> SetAsync<TRequest, TResponse>(TRequest request);

        Task<TResponse> GetOrCreateAsync<TResponse>(string key, Func<CancellationToken, ValueTask<Result<TResponse>>> valueFactory, CancellationToken ct);

        Task<Result> RemoveAsync<TRequest>(TRequest request);

        Task<Result> RemoveByTagAsync<TRequest>(TRequest request);
    }
}