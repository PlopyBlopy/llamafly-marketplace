using Domain.Models;
using FluentValidation;
using Shared.Extensions;

namespace Shared.Validation.Properties
{
    internal sealed class PhoneNumberPropValidator : AbstractValidator<string>
    {
        private readonly int phoneNumberLength = CommonModelConstraints.PHONE_NUMBER_LENGHT;

        public PhoneNumberPropValidator()
        {
            When(phoneNumber => !string.IsNullOrEmpty(phoneNumber), () =>
            {
                RuleFor(phoneNumber => phoneNumber)
                    .Matches("^[0-9]*$'").WithMessage(CommonModelErrors.INCORRECT_PHONE_NUMBER_FORMAT)
                    .Length(phoneNumberLength).WithMessage(ErrorsMessages.CharactersLength(phoneNumberLength));
            });
        }
    }
}