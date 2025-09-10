namespace Domain.DTO
{
    public sealed record ProductCardFiltersDto(string? Search, Guid? CategoryId, string? SortProp, string? SortOrder);
}