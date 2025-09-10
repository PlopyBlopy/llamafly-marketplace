using Domain.DTO;
using FluentResults;

namespace Domain.Interfaces.Repositories.Categories
{
    public interface ICreateCategoriesRangeRepository
    {
        Task<Result> CreateRangeAsync(CreateCategoriesRangeModelDto dto, CancellationToken ct);
    }
}