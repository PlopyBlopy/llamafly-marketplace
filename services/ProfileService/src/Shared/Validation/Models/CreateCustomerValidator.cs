using Domain.Commands;
using FluentValidation;

namespace Shared.Validation.Models
{
    internal sealed class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.User).SetValidator(new CreateUserDtoValidator());
            RuleFor(x => x.Profile).SetValidator(new CreateProfileDtoValidator());
            //RuleFor(x => x.Admin).SetValidator(new CreateAdminDtoValidator());
        }
    }
}