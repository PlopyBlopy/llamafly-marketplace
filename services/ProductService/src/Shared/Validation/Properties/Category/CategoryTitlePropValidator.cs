using Domain.Category;
using FluentValidation;
using Shared.Extensions;

namespace Shared.Validation.Properties.Category
{
    internal sealed class CategoryTitlePropValidator : AbstractValidator<string>
    {
        private readonly int minLength = CategoryConstraints.MIN_TITLE_LENGTH;
        private readonly int maxLength = CategoryConstraints.MAX_TITLE_LENGTH;

        public CategoryTitlePropValidator()
        {
            RuleFor(title => title)
                    .NotNull().WithMessage(ErrorsMessages.NotNull)
                    .NotEmpty().WithMessage(ErrorsMessages.NotEmpty)
                    .Length(minLength, maxLength).WithMessage(ErrorsMessages.CharactersLength(minLength, maxLength));
        }
    }
}