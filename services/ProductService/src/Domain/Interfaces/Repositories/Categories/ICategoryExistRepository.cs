using FluentResults;

namespace Domain.Interfaces.Repositories.Categories
{
    public interface ICategoryExistRepository
    {
        Task<Result<bool>> IsExistAsync(Guid categoryId, CancellationToken ct);
    }
}