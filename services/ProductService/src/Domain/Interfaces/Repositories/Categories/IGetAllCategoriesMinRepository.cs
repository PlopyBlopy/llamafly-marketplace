using Domain.DTO;
using FluentResults;

namespace Domain.Interfaces.Repositories.Categories
{
    public interface IGetAllCategoriesMinRepository : IRepository
    {
        Task<Result<List<CategoryWithSubMinDto>>> GetAllMinAsync(CancellationToken ct);
    }
}