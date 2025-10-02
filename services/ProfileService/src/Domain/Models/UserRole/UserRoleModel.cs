namespace Domain.Models.UserRole
{
    public class UserRoleModel
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public UserRoleModel(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}