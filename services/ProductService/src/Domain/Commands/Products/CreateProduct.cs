using MediatoR.Alternative.Lite;

namespace Domain.Commands.Products
{
    public sealed record CreateProductRequest(string Title, string Description, decimal Price, Guid SellerId, Guid CategoryId);
    public sealed record CreateProductResponse(Guid ProductId);
    public sealed record CreateProductCommand(string Title, string Description, decimal Price, Guid SellerId, Guid CategoryId) : ICommand<CreateProductResponse>;
}