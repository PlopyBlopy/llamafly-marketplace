using Domain.DTO;
using Domain.Interfaces.Repositories.Categories;
using FluentResults;
using Infrastructure.Database.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.Queries.Categories
{
    internal sealed class GetAllSubCategoriesMinRepository : IGetAllSubCategoriesMinRepository
    {
        private readonly IDataBaseContext _context;

        public GetAllSubCategoriesMinRepository(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<Result<List<CategoryWithSubMinDto>>> GetAllSubMinAsync(Guid rootCategoryId, CancellationToken ct)
        {
            var result = await _context.Categories.FromSqlRaw(
                @"
                    WITH RECURSIVE category_tree AS (
                        SELECT id, title, parent_category_id
                        FROM categories
                        WHERE parent_category_id = {0}::uuid

                        UNION ALL

                        SELECT c.id, c.title, c.parent_category_id
                        FROM categories c
                        INNER JOIN category_tree ct ON c.parent_category_id = ct.id
                    )
                    SELECT * FROM category_tree
            ", rootCategoryId)
            .AsNoTracking()
            .Select(c => new CategoryWithSubMinDto(c.Id, c.Title, c.ParentCategoryId))
            .ToListAsync(ct);

            return Result.Ok(result);
        }
    }
}