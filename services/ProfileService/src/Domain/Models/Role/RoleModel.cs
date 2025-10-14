using static Domain.Models.Role.RoleModelConstraints;

namespace Domain.Models.Role
{
    public class RoleModel
    {
        public Guid Id { get; set; }
        public string Role { get; set; }

        public RoleModel(Guid id, string role)
        {
        }

        public RoleModel(Guid id, RoleVariants role)
        {
            Id = id;
            Role = Enum.GetName(role);
        }
    }
}