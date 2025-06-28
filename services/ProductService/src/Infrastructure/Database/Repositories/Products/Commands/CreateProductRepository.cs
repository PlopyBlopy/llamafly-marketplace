using Domain.Interfaces.Repositories;
using Domain.Product;
using FluentResults;
using Infrastructure.Database.Abstractions;

namespace Infrastructure.Database.Repositories.Products.Commands
{
    internal sealed class CreateProductRepository : ICreateProductRepository
    {
        private readonly IDataBaseContext _context;

        public CreateProductRepository(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<Result<Guid>> CreateAsync(ProductModel model, CancellationToken ct)
        {
            await _context.Products.AddAsync(model, ct);
            await _context.SaveChangesAsync(ct);

            return Result.Ok(model.Id);
        }
    }
}