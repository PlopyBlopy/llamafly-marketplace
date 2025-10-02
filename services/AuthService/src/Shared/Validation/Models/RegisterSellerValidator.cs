using Domain.Commands;
using FluentValidation;
using Shared.Validation.Properties;

namespace Shared.Validation.Models
{
    internal class RegisterSellerValidator : AbstractValidator<RegisterSellerCommand>
    {
        public RegisterSellerValidator()
        {
            RuleFor(x => x.User.Password).SetValidator(new UserPasswordPropValidator());
        }
    }
}