using MediatoR.Alternative.Lite;

namespace Domain.Commands.Products.Remove
{
    public record RemoveProductCommand(Guid Id) : ICommand<RemoveProductResponse>;
}