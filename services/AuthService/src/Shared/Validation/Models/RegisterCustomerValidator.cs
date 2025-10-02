using Domain.Commands;
using FluentValidation;
using Shared.Validation.Properties;

namespace Shared.Validation.Models
{
    internal class RegisterCustomerValidator : AbstractValidator<RegisterCustomerCommand>
    {
        public RegisterCustomerValidator()
        {
            RuleFor(x => x.User.Password).SetValidator(new UserPasswordPropValidator());
        }
    }
}