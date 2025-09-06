namespace Domain.DTO
{
    public sealed record CategoryWithSubDto(Guid Id, string Title, Guid? ParentCategoryId, DateTime UpdatedAt, DateTime CreatedAt)
    {
        public List<CategoryWithSubDto> SubCategories { get; set; } = new List<CategoryWithSubDto>();
    }
}