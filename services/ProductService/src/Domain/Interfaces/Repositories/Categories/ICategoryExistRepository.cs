using FluentResults;

namespace Domain.Interfaces.Repositories.Categories
{
    public interface ICategoryExistRepository : IRepository
    {
        Task<Result<bool>> IsExistAsync(Guid categoryId, CancellationToken ct);
    }
}