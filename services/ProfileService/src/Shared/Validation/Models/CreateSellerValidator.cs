using Domain.Commands;
using FluentValidation;

namespace Shared.Validation.Models
{
    internal sealed class CreateSellerValidator : AbstractValidator<CreateSellerCommand>
    {
        public CreateSellerValidator()
        {
            RuleFor(x => x.User).SetValidator(new CreateUserDtoValidator());
            RuleFor(x => x.Profile).SetValidator(new CreateProfileDtoValidator());
            //RuleFor(x => x.Admin).SetValidator(new CreateAdminDtoValidator());
        }
    }
}