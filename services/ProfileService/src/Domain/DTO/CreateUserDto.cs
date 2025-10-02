namespace Domain.DTO
{
    public sealed record CreateUserDto(string Login, string? PhoneNumber, string? Email);
}