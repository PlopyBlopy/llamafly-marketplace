using Domain.Category;
using Domain.Interfaces.Repositories.Categories;
using FluentResults;
using FluentResults.Errors;
using Infrastructure.Database.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.Queries.Categories
{
    internal sealed class GetByIdCategoryRepository : IGetByIdCategoryRepository
    {
        private readonly IDataBaseContext _context;

        public GetByIdCategoryRepository(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<Result<CategoryModel>> GetByIdAsync(Guid categoryId, CancellationToken ct)
        {
            CategoryModel model = null;

            if (categoryId != Guid.Empty)
                model = await _context.Categories
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == categoryId, ct);

            return model is null
                ? Result.Fail<CategoryModel>(new NotFoundError(categoryId.ToString(), "Category"))
                : Result.Ok(model);
        }
    }
}