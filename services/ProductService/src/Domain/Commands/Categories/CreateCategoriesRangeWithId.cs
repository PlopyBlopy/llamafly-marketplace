using Domain.DTO;
using MediatoR.Alternative.Lite;

namespace Domain.Commands.Categories
{
    public sealed record CreateCategoriesRangeWithIdRequest(List<CategoryWithIdDTO> Categories);
    public sealed record CreateCategoriesRangeWithIdResponse();
    public sealed record CreateCategoriesRangeWithIdCommand(List<CategoryWithIdDTO> Categories) : ICommand<CreateCategoriesRangeWithIdResponse>;
}