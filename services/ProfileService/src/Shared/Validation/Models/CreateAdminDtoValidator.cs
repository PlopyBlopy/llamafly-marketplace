using Domain.DTO;
using FluentValidation;

namespace Shared.Validation.Models
{
    internal sealed class CreateAdminDtoValidator : AbstractValidator<CreateAdminDto>
    {
        public CreateAdminDtoValidator()
        {
        }
    }
}