namespace Domain.DTO
{
    public sealed record CategoryWithIdDTO(Guid Id, string Title, Guid? ParentCategoryId, List<CategoryWithIdDTO> SubCategories);
}