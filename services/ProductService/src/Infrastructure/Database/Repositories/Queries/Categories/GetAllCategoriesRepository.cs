using Domain.DTO;
using Domain.Interfaces.Repositories.Categories;
using FluentResults;
using Infrastructure.Database.Abstractions;
using Microsoft.EntityFrameworkCore;
using Shared.Helpers;

namespace Infrastructure.Database.Repositories.Queries.Categories
{
    internal sealed class GetAllCategoriesRepository : IGetAllCategoriesRepository
    {
        private readonly IDataBaseContext _context;
        private readonly CategoriesHierarchyFormatter _categoriesHierarchyFormatter;

        public GetAllCategoriesRepository(IDataBaseContext context, CategoriesHierarchyFormatter categoriesHierarchyFormatter)
        {
            _context = context;
            _categoriesHierarchyFormatter = categoriesHierarchyFormatter;
        }

        public async Task<Result<List<CategoryWithSubDto>>> GetAllAsync(CancellationToken ct)
        {
            var result = await _context.Categories.FromSqlRaw(
            @"
                WITH RECURSIVE category_tree AS (
                    SELECT id, title, parent_category_id, updated_at, created_at
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
            .Select(c => new CategoryWithSubDto(c.Id, c.Title, c.ParentCategoryId, c.UpdatedAt, c.CreatedAt))
            .ToListAsync(ct);

            var hierarchyList = _categoriesHierarchyFormatter.Formate(result);

            return Result.Ok(hierarchyList);
        }
    }
}