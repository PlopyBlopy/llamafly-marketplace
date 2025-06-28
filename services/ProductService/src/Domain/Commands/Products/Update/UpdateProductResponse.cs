namespace Domain.Commands.Products.Update
{
    public record UpdateProductResponse(Guid Id, string Title, string Description, decimal Price, Guid CategoryId, Guid SellerId);
}