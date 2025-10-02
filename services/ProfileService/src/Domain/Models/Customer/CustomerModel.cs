namespace Domain.Models.Customer
{
    public class CustomerModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double Rating { get; set; }
        public DateTime UpdatedAt { get; set; }

        public CustomerModel(Guid id, Guid userId, double rating, DateTime updatedAt)
        {
            Id = id;
            UserId = userId;
            Rating = rating;
            UpdatedAt = updatedAt;
        }
    }
}