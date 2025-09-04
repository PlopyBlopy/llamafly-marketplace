using Domain.Product;
using FluentValidation;
using Shared.Extensions;

namespace Shared.Validation.Properties.Product
{
    internal sealed class ProductTitlePropValidator : AbstractValidator<string>
    {
        public readonly int minLength = ProductConstraints.MIN_TITLE_LENGTH;
        public readonly int maxLength = ProductConstraints.MAX_TITLE_LENGTH;

        public ProductTitlePropValidator()
        {
            RuleFor(title => title)
                .NotEmpty().WithMessage(ErrorsMessages.NotEmpty)
                .Length(minLength, maxLength).WithMessage(ErrorsMessages.CharactersLength(minLength, maxLength));
        }
    }
}