using Domain.Commands;
using FluentValidation;
using Shared.Validation.Properties;

namespace Shared.Validation.Models
{
    internal class RegisterAdminValidator : AbstractValidator<RegisterAdminCommand>
    {
        public RegisterAdminValidator()
        {
            RuleFor(x => x.User.Password).SetValidator(new UserPasswordPropValidator());
        }
    }
}