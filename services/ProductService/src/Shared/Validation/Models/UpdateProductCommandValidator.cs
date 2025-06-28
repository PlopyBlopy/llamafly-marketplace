using Domain.Commands.Products.Update;
using FluentValidation;
using Shared.Validation.Properties;

namespace Shared.Validation.Models
{
    internal sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Title).SetValidator(new ProductTitlePropValidator()).When(x => x.Title != null);
            RuleFor(x => x.Description).SetValidator(new ProductDescriptionPropValidator()).When(x => x.Description != null);
            RuleFor(x => x.Price.Value).SetValidator(new ProductPricePropValidator()).When(x => x.Price != null);
        }
    }
}