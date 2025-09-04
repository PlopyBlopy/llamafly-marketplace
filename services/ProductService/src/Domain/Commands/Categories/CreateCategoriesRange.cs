using Domain.Category;
using Domain.DTO;
using MediatoR.Alternative.Lite;

namespace Domain.Commands.Categories
{
    public sealed record CreateCategoriesRangeRequest(List<CreateCategoryDto> Categories);
    public sealed record CreateCategoriesRangeResponse(List<CategoryModel> Categories);
    public sealed record CreateCategoriesRangeCommand(List<CreateCategoryDto> Categories) : ICommand<CreateCategoriesRangeResponse>;
}