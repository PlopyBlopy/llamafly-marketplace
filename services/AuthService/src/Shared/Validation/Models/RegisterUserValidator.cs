using Domain.Commands;
using FluentValidation;
using Shared.Validation.Properties;

namespace Shared.Validation.Models
{
    internal class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.User.Password).SetValidator(new UserPasswordPropValidator());
        }
    }
}