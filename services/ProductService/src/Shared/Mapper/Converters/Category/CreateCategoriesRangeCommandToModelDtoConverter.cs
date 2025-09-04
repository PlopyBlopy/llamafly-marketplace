using AutoMapper;
using Domain.Category;
using Domain.Commands.Categories;
using Domain.DTO;

namespace Shared.Mapper.Converters.Category
{
    //A converter that converts a Command object into a Model.
    //Returns a Dto with a list of Models in the order of category nesting.
    //Parent → Child element 1 → Child element 1.1 → Child element 2 → OtherParent → ...
    internal sealed class CreateCategoriesRangeCommandToModelDtoConverter : ITypeConverter<CreateCategoriesRangeCommand, CreateCategoriesRangeModelDto>
    {
        public CreateCategoriesRangeModelDto Convert(CreateCategoriesRangeCommand source, CreateCategoriesRangeModelDto destination, ResolutionContext context)
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

        private void ConvertCategory(List<CategoryModel> categories, CreateCategoryDto category, Guid? parentCategoryId)
        {
            CategoryModel model = new CategoryModel
            {
                Id = Guid.NewGuid(),
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