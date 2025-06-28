namespace Domain.Queries.Products.GetById
{
    public sealed record GetByIdProductResponse(Guid Id, string Title, string Description, decimal Price, decimal Rating, DateTime UpdatedAt, DateTime CreatedAt);
}