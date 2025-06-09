using Domain.Interfaces;
using Domain.Product;
using FluentResults;
using Infrastructure.Database.Abstractions;

namespace Infrastructure.Database.Repositories.Products.Create
{
    public class CreateProductRepository : ICreateProductRepository
    {
        private readonly IDataBaseContext _context;

        public CreateProductRepository(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<Result<Guid>> CreateAsync(ProductModel product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return Result.Ok(product.Id);
        }
    }
}