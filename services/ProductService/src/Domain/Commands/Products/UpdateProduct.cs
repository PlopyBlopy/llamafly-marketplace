using MediatoR.Alternative.Lite;

namespace Domain.Commands.Products
{
    public record UpdateProductRequest(Guid Id, string? Title, string? Description, decimal? Price, Guid? CategoryId);
    public record UpdateProductResponse(Guid Id, string Title, string Description, decimal Price, Guid CategoryId, Guid SellerId);
    public record UpdateProductCommand(Guid Id, string? Title, string? Description, decimal? Price, Guid? CategoryId) : ICommand<UpdateProductResponse>;
}