using Domain.Interfaces.Repositories.Categories;
using Infrastructure.Database.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.Queries.Categories
{
    internal sealed class CategoryExistRepository : ICategoryExistRepository
    {
        private readonly IDataBaseContext _context;

        public CategoryExistRepository(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<bool> IsExistAsync(Guid categoryId, CancellationToken ct)
        {
            if (categoryId == Guid.Empty)
                return false;

            var result = await _context.Categories
                .AsNoTracking()
                .FirstAsync(ct);

            return result is null ? false : true;
        }
    }
}