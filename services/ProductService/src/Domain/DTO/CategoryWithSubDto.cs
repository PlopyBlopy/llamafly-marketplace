namespace Domain.DTO
{
    public sealed record CategoryWithSubDto(Guid Id, string Title, Guid ParentCategoryId, DateTime UpdatedAt, DateTime CreatedAt, List<CategoryWithSubDto> SubCategories);
}