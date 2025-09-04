using Domain.Product;
using FluentValidation;
using Shared.Extensions;

namespace Shared.Validation.Properties.Product
{
    internal sealed class ProductDescriptionPropValidator : AbstractValidator<string>
    {
        public readonly int minLength = ProductConstraints.MIN_Description_LENGTH;
        public readonly int maxLength = ProductConstraints.MAX_Description_LENGTH;

        public ProductDescriptionPropValidator()
        {
            RuleFor(description => description)
                .NotEmpty().WithMessage(ErrorsMessages.NotEmpty)
                .Length(minLength, maxLength).WithMessage(ErrorsMessages.CharactersLength(minLength, maxLength));
        }
    }
}