namespace Domain.DTO
{
    public sealed record UpdateProductDto(Guid Id, string? Title, string? Description, decimal? Price, Guid? CategoryId);
}