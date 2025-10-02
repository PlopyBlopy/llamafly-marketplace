using Domain.DTO;
using Domain.Models.Profile;
using FluentValidation;
using Shared.Extensions;

namespace Shared.Validation.Models
{
    internal sealed class CreateProfileDtoValidator : AbstractValidator<CreateProfileDto>
    {
        private readonly int minNameLength = ProfileModelConstraints.MIN_NAME_LENGTH;
        private readonly int maxNameLength = ProfileModelConstraints.MAX_NAME_LENGTH;
        private readonly int minSurnameLength = ProfileModelConstraints.MIN_SURNAME_LENGTH;
        private readonly int maxSurnameLength = ProfileModelConstraints.MAX_SURNAME_LENGTH;
        private readonly int minPatronymicLength = ProfileModelConstraints.MIN_PATRONYMIC_LENGTH;
        private readonly int maxPatronymicLength = ProfileModelConstraints.MAX_PATRONYMIC_LENGTH;
        private readonly int minAgeValue = ProfileModelConstraints.MIN_AGE;
        private readonly int maxAgeValue = ProfileModelConstraints.MAX_AGE;

        public CreateProfileDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ErrorsMessages.NotEmpty)
                .Length(minNameLength, maxNameLength).WithMessage(ErrorsMessages.CharactersLength(minNameLength, maxNameLength));

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage(ErrorsMessages.NotEmpty)
                .Length(minSurnameLength, maxSurnameLength).WithMessage(ErrorsMessages.CharactersLength(minSurnameLength, maxSurnameLength));

            RuleFor(x => x.Patronymic)
                .NotEmpty().WithMessage(ErrorsMessages.NotEmpty)
                .Length(minPatronymicLength, maxPatronymicLength).WithMessage(ErrorsMessages.CharactersLength(minPatronymicLength, maxPatronymicLength));

            RuleFor(x => x.Age)
                .InclusiveBetween(minAgeValue, maxAgeValue).WithMessage(ErrorsMessages.ValueBetween(minAgeValue, maxAgeValue));
        }
    }
}