using Domain.Queries;
using FluentValidation;
using Shared.Extensions;
using Shared.Validation.Properties;

namespace Shared.Validation.Models
{
    internal sealed class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(p => p.LoginType)
                .NotNull().WithMessage(ErrorsMessages.NotNull)
                .NotEmpty().WithMessage(ErrorsMessages.NotEmpty)
                .Equal(LoginType.Login | LoginType.PhoneNumber | LoginType.Email);

            RuleFor(p => p.LoginValue)
                .NotNull().WithMessage(ErrorsMessages.NotNull)
                .NotEmpty().WithMessage(ErrorsMessages.NotEmpty);

            When(p => p.LoginType == LoginType.Login, () =>
            {
                RuleFor(p => p.LoginValue).SetValidator(new LoginPropValidator());
            });

            When(p => p.LoginType == LoginType.PhoneNumber, () =>
            {
                RuleFor(p => p.LoginValue).SetValidator(new PhoneNumberPropValidator());
            });

            When(p => p.LoginType == LoginType.Email, () =>
            {
                RuleFor(p => p.LoginValue).SetValidator(new EmailPropValidator());
            });
        }
    }
}