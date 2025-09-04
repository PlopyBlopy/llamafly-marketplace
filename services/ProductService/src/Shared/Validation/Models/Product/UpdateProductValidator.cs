using Domain.Commands.Products;
using FluentValidation;
using Shared.Validation.Properties.Product;

namespace Shared.Validation.Models.Products
{
    internal sealed class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Title).SetValidator(new ProductTitlePropValidator()).When(x => x.Title != null);
            RuleFor(x => x.Description).SetValidator(new ProductDescriptionPropValidator()).When(x => x.Description != null);
            RuleFor(x => x.Price.Value).SetValidator(new ProductPricePropValidator()).When(x => x.Price != null);
        }
    }
}