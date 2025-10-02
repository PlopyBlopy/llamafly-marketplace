namespace Domain.DTO
{
    public sealed record ProfileDto(string Name, string Surname, string? Patronymic, int Age, bool IsMale);
}