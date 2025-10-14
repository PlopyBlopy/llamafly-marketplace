using Domain.Queries;
using FluentValidation;
using Shared.Extensions;
using Shared.Validation.Properties;
using static Domain.Models.CommonConstraints;

namespace Shared.Validation.Models
{
    internal sealed class LoginValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginValidator()
        {
            RuleFor(p => p.Password).SetValidator(new UserPasswordPropValidator());
            RuleFor(p => p.LoginType)
                .NotNull().WithMessage(ErrorsMessages.NotNull)
                .NotEmpty().WithMessage(ErrorsMessages.NotEmpty)
                .Equal(LoginVariants.Login | LoginVariants.PhoneNumber | LoginVariants.Email);
        }
    }
}