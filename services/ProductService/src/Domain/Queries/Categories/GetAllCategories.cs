using Domain.DTO;
using MediatoR.Alternative.Lite;

namespace Domain.Queries.Categories
{
    public sealed record GetAllCategoriesResponse(List<CategoryWithSubDto> Categories);
    public sealed record GetAllCategoriesQuery() : IQuery<GetAllCategoriesResponse>;
}