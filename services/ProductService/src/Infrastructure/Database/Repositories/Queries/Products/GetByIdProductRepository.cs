using Domain.Interfaces.Repositories.Products;
using Domain.Product;
using FluentResults;
using FluentResults.Errors;
using Infrastructure.Database.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.Queries.Products
{
    internal sealed class GetByIdProductRepository : IGetByIdProductRepository
    {
        private readonly IDataBaseContext _context;

        public GetByIdProductRepository(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<Result<ProductModel>> GetByIdAsync(Guid productId, CancellationToken ct)
        {
            var entity = await _context.Products.AsNoTracking().Where(e => e.Id == productId).FirstOrDefaultAsync();

            return entity == null
                ? Result.Fail<ProductModel>(new NotFoundError("GetByIdProductRepository", "ProductModel"))
                : Result.Ok(entity);
        }
    }
}