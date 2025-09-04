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

        public async Task<Result<ProductModel>> UpdateAsync(UpdateProductCommand command, CancellationToken ct)
        {
            var entity = await _context.Products.FindAsync(command.Id);

            if (entity == null)
            {
                return Result.Fail<ProductModel>(new NotFoundError("UpdateProductRepository", "ProductModel"));
            }

            bool isModified = false;

            if (!string.IsNullOrEmpty(command.Title) && entity.Title != command.Title)
            {
                entity.Title = command.Title;
                isModified = true;
            }

            if (!string.IsNullOrEmpty(command.Description) && entity.Description != command.Description)
            {
                entity.Description = command.Description;
                isModified = true;
            }

            if (command.Price != null && command.Price != entity.Price)
            {
                entity.Price = command.Price.Value;
                isModified = true;
            }

            if (command.CategoryId != null && command.CategoryId != Guid.Empty && command.CategoryId != entity.CategoryId)
            {
                var categoryExist = await _context.Categories.AsNoTracking().Where(category => category.Id == command.CategoryId).AnyAsync(ct);

                if (categoryExist)
                {
                    entity.CategoryId = command.CategoryId.Value;
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