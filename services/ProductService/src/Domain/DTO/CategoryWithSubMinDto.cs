namespace Domain.DTO
{
    public sealed record CategoryWithSubMinDto(Guid Id, string Title, Guid? ParentCategoryId)
    {
        public List<CategoryWithSubMinDto> SubCategories { get; set; } = new List<CategoryWithSubMinDto>();
    }
}