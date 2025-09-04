using MediatoR.Alternative.Lite;

namespace Domain.Queries.Categories
{
    public sealed record GetByIdCategoryResponse(Guid Id, string Title, Guid? ParentCategoryId, DateTime UpdatedAt, DateTime CreatedAt);
    public sealed record GetByIdCategoryQuery(Guid Id) : IQuery<GetByIdCategoryResponse>;
}