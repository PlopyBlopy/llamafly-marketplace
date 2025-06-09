using FluentValidation;
using Application.Products.Create;
using Domain.Commands.Products.Create;

namespace Application.Products.Create
{
    internal sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}