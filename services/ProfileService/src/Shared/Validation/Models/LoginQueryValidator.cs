using Domain.Queries;
using FluentValidation;
using Shared.Extensions;
using Shared.Validation.Properties;
using static Domain.Models.User.UserModelConstraints;

namespace Shared.Validation.Models
{
    internal sealed class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(p => p.LoginType)
                .NotNull().WithMessage(ErrorsMessages.NotNull)
                .NotEmpty().WithMessage(ErrorsMessages.NotEmpty)
                .Equal(LoginVariants.Login | LoginVariants.PhoneNumber | LoginVariants.Email);

            RuleFor(p => p.LoginValue)
                .NotNull().WithMessage(ErrorsMessages.NotNull)
                .NotEmpty().WithMessage(ErrorsMessages.NotEmpty);

            When(p => p.LoginType == LoginVariants.Login, () =>
            {
                RuleFor(p => p.LoginValue).SetValidator(new LoginPropValidator());
            });

            When(p => p.LoginType == LoginVariants.PhoneNumber, () =>
            {
                RuleFor(p => p.LoginValue).SetValidator(new PhoneNumberPropValidator());
            });

            When(p => p.LoginType == LoginVariants.Email, () =>
            {
                RuleFor(p => p.LoginValue).SetValidator(new EmailPropValidator());
            });
        }
    }
}