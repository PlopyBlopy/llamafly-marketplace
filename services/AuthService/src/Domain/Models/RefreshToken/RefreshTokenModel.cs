namespace Domain.Models.RefreshToken
{
    public class RefreshTokenModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AccessTokenId { get; set; }
        public string TokenRefresh { get; set; }
        public bool IsRevorked { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public RefreshTokenModel(Guid id, Guid userId, Guid accessTokenId, string tokenRefresh, bool isRevorked, DateTime expiresAt, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            AccessTokenId = accessTokenId;
            TokenRefresh = tokenRefresh;
            IsRevorked = isRevorked;
            ExpiresAt = expiresAt;
            CreatedAt = createdAt;
        }
    }
}