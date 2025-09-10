using Domain.DTO;
using Domain.Interfaces.Repositories.Categories;
using FluentResults;
using Infrastructure.Database.Abstractions;

namespace Infrastructure.Database.Repositories.Commands.Categories
{
    internal sealed class CreateCategoriesRangeRepository : ICreateCategoriesRangeRepository
    {
        private readonly IDataBaseContext _context;

        public CreateCategoriesRangeRepository(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<Result> CreateRangeAsync(CreateCategoriesRangeModelDto dto, CancellationToken ct)
        {
            await _context.Categories.AddRangeAsync(dto.Categories, ct);
            await _context.SaveChangesAsync(ct);

            return Result.Ok();
        }
    }
}