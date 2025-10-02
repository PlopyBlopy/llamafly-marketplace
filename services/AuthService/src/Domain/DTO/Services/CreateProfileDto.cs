using Domain.DTO;

namespace Domain.DTO.Services
{
    public sealed record CreateProfileDto(string Name, string Surname, string? Patronymic, int Age, bool IsMale);
}