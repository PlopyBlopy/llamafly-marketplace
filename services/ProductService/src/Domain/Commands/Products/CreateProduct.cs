using MediatoR.Alternative.Lite;

namespace Domain.Commands.Products
{
    public sealed record CreateProductRequest(string Title, string Description, decimal Price, Guid CategoryId, Guid ShopId);
    public sealed record CreateProductResponse(Guid Id);
    public sealed record CreateProductCommand(string Title, string Description, decimal Price, Guid ShopId, Guid CategoryId) : ICommand<CreateProductResponse>;
}