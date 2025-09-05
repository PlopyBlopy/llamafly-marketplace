namespace Domain.Product
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ShopId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public ProductModel(Guid id, string title, string description, decimal price, double rating, Guid categoryId, Guid shopId, DateTime updatedAt, DateTime createdAt)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Rating = rating;
            CategoryId = categoryId;
            ShopId = shopId;
            UpdatedAt = updatedAt;
            CreatedAt = createdAt;
        }
    }
}