using Domain.Commands.Categories;
using FluentValidation;
using Shared.Extensions;
using Shared.Validation.Properties.Category;

namespace Shared.Validation.Models.Category
{
    internal sealed class CreateCategoriesRangeValidator : AbstractValidator<CreateCategoriesRangeCommand>
    {
        public CreateCategoriesRangeValidator()
        {
            RuleFor(categories => categories)
                .NotNull().WithMessage(ErrorsMessages.NotNull)
                .NotEmpty().WithMessage(ErrorsMessages.NotEmpty);

            RuleFor(x => x.Categories).SetValidator(new CategoriesRangeTitlePropValidator());
        }
    }
}