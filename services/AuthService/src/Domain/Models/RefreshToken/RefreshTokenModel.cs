namespace Domain.Models.RefreshToken
{
    public class RefreshTokenModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string TokenRefresh { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public RefreshTokenModel(Guid id, Guid userId, string tokenRefresh, bool isRevoked, DateTime expiresAt, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            TokenRefresh = tokenRefresh;
            IsRevoked = isRevoked;
            ExpiresAt = expiresAt;
            CreatedAt = createdAt;
        }
    }
}