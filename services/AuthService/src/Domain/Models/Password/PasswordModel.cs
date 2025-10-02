namespace Domain.Models.Password
{
    public class PasswordModel
    {
        public Guid UserId { get; set; }
        public string PasswordHash { get; set; }

        public PasswordModel(Guid userId, string passwordHash)
        {
            UserId = userId;
            PasswordHash = passwordHash;
        }
    }
}