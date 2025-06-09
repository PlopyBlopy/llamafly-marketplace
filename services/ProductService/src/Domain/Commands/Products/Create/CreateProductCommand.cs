using MediatoR.Alternative.Lite;

namespace Domain.Commands.Products.Create
{
    public sealed record CreateProductCommand(string Title, string Description, decimal Price, Guid SellerId, Guid CategoryId) : ICommand<CreateProductResponse>
    {
    }
}