using MediatoR.Alternative.Lite;

namespace Domain.Queries.Products.GetById
{
    public sealed record GetByIdProductQuery(Guid Id) : IQuery<GetByIdProductResponse>;
}