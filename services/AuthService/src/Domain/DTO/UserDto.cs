namespace Domain.DTO
{
    public sealed record UserDto(string Password, string Login, string? PhoneNumber, string? Email);
}