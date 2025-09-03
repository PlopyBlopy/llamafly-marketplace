namespace Domain.DTO
{
    public sealed record ProductCardFiltersDto(string? Search, Guid? CategoryId, decimal Price, double Rating);
}