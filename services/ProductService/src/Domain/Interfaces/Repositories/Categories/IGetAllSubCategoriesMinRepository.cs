using Domain.DTO;
using FluentResults;

namespace Domain.Interfaces.Repositories.Categories
{
    public interface IGetAllSubCategoriesMinRepository : IRepository
    {
        Task<Result<List<CategoryWithSubMinDto>>> GetAllSubMinAsync(Guid rootCategoryId, CancellationToken ct);
    }
}