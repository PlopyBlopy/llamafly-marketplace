using Domain.Commands.Products;
using FluentValidation;
using Shared.Validation.Properties.Product;

namespace Shared.Validation.Models.Product
{
    internal sealed class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Title).SetValidator(new ProductTitlePropValidator());
            RuleFor(x => x.Description).SetValidator(new ProductDescriptionPropValidator());
            RuleFor(x => x.Price).SetValidator(new ProductPricePropValidator());
        }
    }
}
