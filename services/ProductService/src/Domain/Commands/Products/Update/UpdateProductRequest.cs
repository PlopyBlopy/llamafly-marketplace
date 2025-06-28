namespace Domain.Commands.Products.Update
{
    public record UpdateProductRequest(Guid Id, string? Title, string? Description, decimal? Price, Guid? CategoryId);
}