namespace Domain.Product
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SellerId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public Product()
        {
        }

        public Product(Guid id, string title, string description, decimal price, decimal rating, Guid categoryId, Guid sellerId, DateTime updatedAt, DateTime createAt)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Rating = rating;
            CategoryId = categoryId;
            SellerId = sellerId;
            UpdatedAt = updatedAt;
            CreatedAt = createAt;
        }
    }
}