using MediatoR.Alternative.Lite;

namespace Domain.Commands.Products
{
    public record RemoveProductRequest(Guid Id);
    public record RemoveProductResponse(Guid Id);
    public record RemoveProductCommand(Guid Id) : ICommand<RemoveProductResponse>;
}