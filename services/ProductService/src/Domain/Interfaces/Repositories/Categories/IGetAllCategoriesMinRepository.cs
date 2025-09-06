using Domain.DTO;
using FluentResults;

namespace Domain.Interfaces.Repositories.Categories
{
    public interface IGetAllCategoriesMinRepository
    {
        Task<Result<List<CategoryWithSubMinDto>>> GetAllMinAsync(CancellationToken ct);
    }
}