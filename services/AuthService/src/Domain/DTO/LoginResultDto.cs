using static Domain.Models.CommonConstraints;
using Domain.DTO;

namespace Domain.DTO
{
    public sealed record LoginResultDto(Guid UserId, RoleVariants UserRole);
}