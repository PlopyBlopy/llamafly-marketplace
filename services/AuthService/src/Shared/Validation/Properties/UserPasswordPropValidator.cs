using Domain.Models.Password;
using FluentValidation;
using Shared.Extensions;

namespace Shared.Validation.Properties
{
    internal sealed class UserPasswordPropValidator : AbstractValidator<string>
    {
        private readonly int minLength = PasswordModelConstraints.MIN_LENGTH;
        private readonly int maxLength = PasswordModelConstraints.MAX_LENGTH;

        public UserPasswordPropValidator()
        {
            RuleFor(password => password)
                .NotNull().WithMessage(ErrorsMessages.NotNull)
                .NotEmpty().WithMessage(ErrorsMessages.NotEmpty)
                .Length(minLength, maxLength).WithMessage(ErrorsMessages.CharactersLength(minLength, maxLength));
        }
    }
}