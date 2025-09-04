using MediatoR.Alternative.Lite;

namespace Domain.Commands.Categories
{
    public sealed record CreateCategoryRequest(string Title, Guid? ParentCategoryId);
    public sealed record CreateCategoryResponse(Guid Id);
    public sealed record CreateCategoryCommand(string Title, Guid? ParentCategoryId) : ICommand<CreateCategoryResponse>;
}