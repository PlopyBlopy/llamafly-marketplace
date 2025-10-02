namespace Domain.Models.Admin
{
    public class AdminModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime UpdatedAt { get; set; }

        public AdminModel(Guid id, Guid userId, DateTime updatedAt)
        {
            Id = id;
            UserId = userId;
            UpdatedAt = updatedAt;
        }
    }
}