namespace Domain.DTO
{
    public sealed record CreateCategoryDto(string Title, List<CreateCategoryDto> SubCategories);
}