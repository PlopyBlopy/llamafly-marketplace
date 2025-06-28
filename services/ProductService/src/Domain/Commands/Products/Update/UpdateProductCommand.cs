using MediatoR.Alternative.Lite;

namespace Domain.Commands.Products.Update
{
    public record UpdateProductCommand(Guid Id, string? Title, string? Description, decimal? Price, Guid? CategoryId) : ICommand<UpdateProductResponse>;
}