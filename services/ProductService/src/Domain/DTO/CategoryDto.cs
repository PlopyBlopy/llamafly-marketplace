namespace Domain.DTO
{
    public sealed record CategoryDto(Guid Id, string Title, Guid ParentCategoryId, DateTime UpdatedAt, DateTime CreatedAt);
}