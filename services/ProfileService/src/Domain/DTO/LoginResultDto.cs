using static Domain.Models.Role.RoleModelConstraints;

namespace Domain.DTO
{
    public sealed record LoginResultDto(Guid UserId, RoleVariants UserRole);
}