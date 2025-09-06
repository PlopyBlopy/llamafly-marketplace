using Domain.DTO;
using MediatoR.Alternative.Lite;

namespace Domain.Queries.Categories
{
    public sealed record GetAllCategoriesMinResponse(List<CategoryWithSubMinDto> Categories);
    public sealed record GetAllCategoriesMinQuery() : IQuery<GetAllCategoriesMinResponse>;
}