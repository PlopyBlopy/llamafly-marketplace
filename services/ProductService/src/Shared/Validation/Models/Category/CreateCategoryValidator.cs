using Domain.Commands.Categories;
using FluentValidation;
using Shared.Validation.Properties.Category;

namespace Shared.Validation.Models.Category
{
    internal sealed class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Title).SetValidator(new CategoryTitlePropValidator());
        }
    }
}