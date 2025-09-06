using Domain.DTO;
using Domain.Interfaces.Repositories.Categories;
using FluentResults;
using Infrastructure.Database.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.Queries.Categories
{
    internal sealed class GetAllCategoriesMinRepository : IGetAllCategoriesMinRepository
    {
        private readonly IDataBaseContext _context;

        public GetAllCategoriesMinRepository(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<Result<List<CategoryWithSubMinDto>>> GetAllMinAsync(CancellationToken ct)
        {
            var result = await _context.Categories.FromSqlRaw(
            @"
                WITH RECURSIVE category_tree AS (
                    SELECT id, title,parent_category_id, updated_at, created_at
                    FROM categories
                    WHERE parent_category_id IS NULL

                    UNION ALL

                    SELECT c.id, c.title, c.parent_category_id, c.updated_at, c.created_at
                    FROM categories c
                    INNER JOIN category_tree ct ON c.parent_category_id = ct.id
                )
                SELECT * FROM category_tree
            ")
            .AsNoTracking()
            .Select(c => new CategoryWithSubMinDto(c.Id, c.Title, c.ParentCategoryId))
            .ToListAsync(ct);

            return Result.Ok(result);
        }
    }
}