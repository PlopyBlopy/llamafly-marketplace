using Domain.DTO;
using FluentValidation;
using Shared.Validation.Properties;

namespace Shared.Validation.Models
{
    internal sealed class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.PhoneNumber).SetValidator(new PhoneNumberPropValidator());
            RuleFor(x => x.Email).SetValidator(new EmailPropValidator());
        }
    }
}