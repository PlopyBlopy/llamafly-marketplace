using Domain.Product;
using FluentValidation;
using Shared.Extensions;

namespace Shared.Validation.Properties.Product
{
    internal sealed class ProductPricePropValidator : AbstractValidator<decimal>
    {
        public readonly decimal minPrice = ProductConstraints.MIN_PRICE;
        public readonly decimal maxPrice = ProductConstraints.MAX_PRICE;

        public ProductPricePropValidator()
        {
            RuleFor(price => price)
                .InclusiveBetween(minPrice, maxPrice).WithMessage(ErrorsMessages.ValueBetween(minPrice, maxPrice));
        }
    }
}