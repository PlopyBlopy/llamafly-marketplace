using MediatoR.Alternative.Lite;

namespace Domain.Queries.Categories
{
    public sealed record CategoryExistResponse(bool isExist);
    public sealed record CategoryExistQuery(Guid Id) : IQuery<CategoryExistResponse>;
}