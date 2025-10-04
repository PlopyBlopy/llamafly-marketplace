using Domain.Queries;
using Domain.Queries.Services;
using FluentValidation;
using Shared.Extensions;
using Shared.Validation.Properties;

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
                .Equal(LoginType.Login | LoginType.PhoneNumber | LoginType.Email);
        }
    }
}