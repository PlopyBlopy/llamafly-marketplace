namespace Domain.DTO
{
    public sealed record ProductCardDto(Guid Id, string Title, decimal Price, double Rating);
}