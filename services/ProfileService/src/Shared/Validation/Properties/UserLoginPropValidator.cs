using Domain.Models.User;
using FluentValidation;
using Shared.Extensions;

namespace Shared.Validation.Properties
{
    internal sealed class UserLoginPropValidator : AbstractValidator<string>
    {
        private const int minLength = UserModelConstraints.MIN_LOGIN_LENGTH;
        private const int maxLength = UserModelConstraints.MAX_LOGIN_LENGTH;

        public UserLoginPropValidator()
        {
            RuleFor(login => login)
                .NotNull().WithMessage(ErrorsMessages.NotNull)
                .NotEmpty().WithMessage(ErrorsMessages.NotEmpty)
                .Length(minLength, maxLength).WithMessage(ErrorsMessages.CharactersLength(minLength, maxLength));
        }
    }
}