namespace Domain.Models.Shop
{
    public class ShopModel
    {
        public Guid Id { get; set; }
        public Guid SellerId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Rating { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public ShopModel(Guid id, Guid sellerId, string name, string? description, double rating, DateTime updatedAt, DateTime createdAt)
        {
            Id = id;
            SellerId = sellerId;
            Name = name;
            Description = description;
            Rating = rating;
            UpdatedAt = updatedAt;
            CreatedAt = createdAt;
        }
    }
}