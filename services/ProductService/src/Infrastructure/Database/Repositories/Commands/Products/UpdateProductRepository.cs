using Domain.Commands.Products;
using Domain.Interfaces.Repositories.Products;
using Domain.Product;
using FluentResults;
using FluentResults.Errors;
using Infrastructure.Database.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.Commands.Products
{
    internal sealed class UpdateProductRepository : IUpdateProductRepository
    {
        private readonly IDataBaseContext _context;

        public UpdateProductRepository(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<Result<ProductModel>> UpdateAsync(UpdateProductCommand model, CancellationToken ct)
        {
            var entity = await _context.Products.FindAsync(model.Id);

            if (entity == null)
            {
                return Result.Fail<ProductModel>(new NotFoundError("UpdateProductRepository", "ProductModel"));
            }

            bool isModified = false;

            if (!string.IsNullOrEmpty(model.Title) && entity.Title != model.Title)
            {
                entity.Title = model.Title;
                isModified = true;
            }

            if (!string.IsNullOrEmpty(model.Description) && entity.Description != model.Description)
            {
                entity.Description = model.Description;
                isModified = true;
            }

            if (model.Price != null && model.Price != entity.Price)
            {
                entity.Price = model.Price.Value;
                isModified = true;
            }

            if (model.CategoryId != null && model.CategoryId != Guid.Empty && model.CategoryId != entity.CategoryId)
            {
                var categoryExist = await _context.Categories.AsNoTracking().Where(category => category.Id == model.CategoryId).AnyAsync(ct);

                if (categoryExist)
                {
                    entity.CategoryId = model.CategoryId.Value;
                    isModified = true;
                }
            }

            if (isModified)
            {
                entity.UpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync(ct);
            }

            _context.Detach(entity);

            return Result.Ok(entity);
        }
    }
}