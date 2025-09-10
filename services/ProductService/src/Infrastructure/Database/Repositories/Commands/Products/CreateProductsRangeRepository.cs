using Domain.DTO;
using Domain.Interfaces.Repositories.Products;
using FluentResults;
using Infrastructure.Database.Abstractions;

namespace Infrastructure.Database.Repositories.Commands.Products
{
    internal sealed class CreateProductsRangeRepository : ICreateProductsRangeRepository
    {
        private readonly IDataBaseContext _context;

        public CreateProductsRangeRepository(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<Result<Guid>> CreateRangeAsync(CreateProductsRangeModelDto dto, CancellationToken ct)
        {
            await _context.Products.AddRangeAsync(dto.Products, ct);
            await _context.SaveChangesAsync(ct);

            return Result.Ok();
        }
    }
}