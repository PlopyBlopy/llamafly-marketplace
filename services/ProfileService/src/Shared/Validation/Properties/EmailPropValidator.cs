using Domain.Models;
using FluentValidation;

namespace Shared.Validation.Properties
{
    internal sealed class EmailPropValidator : AbstractValidator<string>
    {
        public EmailPropValidator()
        {
            When(email => !string.IsNullOrEmpty(email), () =>
            {
                RuleFor(email => email)
                    .Matches("^[^@]+@[^@]+\\.[^@]+$").WithMessage(CommonModelErrors.INCORRECT_EMAIL_FORMAT);
            });
        }
    }
}