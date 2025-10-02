namespace Domain.Models.AccessToken
{
    public class AccessTokenModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string TokenAccess { get; set; }
        public bool IsRevorked { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public AccessTokenModel(Guid id, Guid userId, string tokenAccess, bool isRevorked, DateTime expiresAt, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            TokenAccess = tokenAccess;
            IsRevorked = isRevorked;
            ExpiresAt = expiresAt;
            CreatedAt = createdAt;
        }
    }
}