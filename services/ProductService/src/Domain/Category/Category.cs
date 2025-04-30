namespace Domain.Category
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public Category()
        {
        }

        public Category(Guid id, string title, Guid? parentCategoryId, DateTime updatedAt, DateTime createdAt)
        {
            Id = id;
            Title = title;
            ParentCategoryId = parentCategoryId;
            UpdatedAt = updatedAt;
            CreatedAt = createdAt;
        }
    }
}