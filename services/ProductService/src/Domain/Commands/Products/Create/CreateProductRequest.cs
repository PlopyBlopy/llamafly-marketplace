namespace Domain.Commands.Products.Create
{
    public sealed record CreateProductRequest(string Title, string Description, decimal Price, Guid SellerId, Guid CategoryId);
}