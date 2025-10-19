using Domain.Category;
using Domain.Interfaces.Repositories.Categories;
using FluentResults;
using FluentResults.Errors;
using Infrastructure.Database.Abstractions;

namespace Infrastructure.Database.Repositories.Commands.Categories
{
    internal sealed class CreateCategoryRepository : ICreateCategoryRepository
    {
        private readonly IDataBaseContext _context;
        private readonly IGetByIdCategoryRepository _repository;

        public CreateCategoryRepository(IDataBaseContext context, IGetByIdCategoryRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<Result<Guid>> CreateAsync(CategoryModel model, CancellationToken ct)
        {
            if (model.ParentCategoryId != null && model.ParentCategoryId != Guid.Empty)
            {
                var parentCategory = await _repository.GetByIdAsync(model.ParentCategoryId.Value, ct);

                if (parentCategory == null)
                    return Result.Fail<Guid>(new NotFoundError(model.ParentCategoryId.ToString(), "ParentCategory"));
            }

            await _context.Categories.AddAsync(model, ct);
            await _context.SaveChangesAsync(ct);

            return Result.Ok(model.Id);
        }
    }
}