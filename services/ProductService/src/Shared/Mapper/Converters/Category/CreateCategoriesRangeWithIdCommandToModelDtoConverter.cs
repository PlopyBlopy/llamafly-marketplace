using AutoMapper;
using Domain.Category;
using Domain.Commands.Categories;
using Domain.DTO;

namespace Shared.Mapper.Converters.Category
{
    internal class CreateCategoriesRangeWithIdCommandToModelDtoConverter : ITypeConverter<CreateCategoriesRangeWithIdCommand, CreateCategoriesRangeModelDto>
    {
        public CreateCategoriesRangeModelDto Convert(CreateCategoriesRangeWithIdCommand source, CreateCategoriesRangeModelDto destination, ResolutionContext context)
        {
            List<CategoryModel> categories = new List<CategoryModel>();

            if (!source.Categories.Any())
                return new CreateCategoriesRangeModelDto(categories);

            foreach (var category in source.Categories)
            {
                ConvertCategory(categories, category, null);
            }

            return new CreateCategoriesRangeModelDto(categories);
        }

        private void ConvertCategory(List<CategoryModel> categories, CategoryWithIdDTO category, Guid? parentCategoryId)
        {
            CategoryModel model = new CategoryModel
            {
                Id = category.Id,
                Title = category.Title,
                ParentCategoryId = parentCategoryId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            categories.Add(model);

            if (category.SubCategories.Any())
            {
                foreach (var subCategory in category.SubCategories)
                {
                    ConvertCategory(categories, subCategory, model.Id);
                }
            }
        }
    }
}