using AutoMapper;
using Domain.Category;
using Domain.Queries.Categories;

namespace Shared.Mapper.Converters.Category
{
    internal sealed class CategoryModelToGetByIdResponseConverter : ITypeConverter<CategoryModel, GetByIdCategoryResponse>
    {
        public GetByIdCategoryResponse Convert(CategoryModel source, GetByIdCategoryResponse destination, ResolutionContext context)
        {
            return new GetByIdCategoryResponse(source.Id, source.Title, source.ParentCategoryId, source.UpdatedAt, source.CreatedAt);
        }
    }
}