using AutoMapper;
using Domain.Category;
using Domain.Commands.Categories;

namespace Shared.Mapper.Converters.Category
{
    internal class CreateCategoryCommandToModelConverter : ITypeConverter<CreateCategoryCommand, CategoryModel>
    {
        public CategoryModel Convert(CreateCategoryCommand source, CategoryModel destination, ResolutionContext context)
        {
            return new CategoryModel()
            {
                Id = Guid.NewGuid(),
                Title = source.Title,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                ParentCategoryId = source.ParentCategoryId,
            };
        }
    }
}