using MediatoR.Alternative.Lite;

namespace Domain.Queries.Products
{
    public sealed record GetByIdProductRequest(Guid Id);
    public sealed record GetByIdProductResponse(Guid Id, string Title, string Description, decimal Price, decimal Rating, DateTime UpdatedAt, DateTime CreatedAt);
    public sealed record GetByIdProductQuery(Guid Id) : IQuery<GetByIdProductResponse>;
}