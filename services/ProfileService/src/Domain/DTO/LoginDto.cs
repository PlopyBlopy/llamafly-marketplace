using Domain.Queries;

namespace Domain.DTO
{
    public sealed record LoginDto(string LoginValue, LoginType LoginType);
}