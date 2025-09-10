namespace Domain.DTO
{
    public sealed record ProductWithIdDto(Guid Id, string Title, string Description, decimal Price, double Rating, Guid CategoryId, Guid ShopId);
}