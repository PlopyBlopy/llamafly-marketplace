using Domain.Commands.Products.Create;
using FluentValidation;
using Shared.Validation.Properties;

namespace Shared.Validation.Models
{
    internal sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Title).SetValidator(new ProductTitlePropValidator());
            RuleFor(x => x.Description).SetValidator(new ProductDescriptionPropValidator());
            RuleFor(x => x.Price).SetValidator(new ProductPricePropValidator());
        }
    }
}