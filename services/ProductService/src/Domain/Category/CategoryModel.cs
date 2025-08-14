namespace Domain.Category
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public CategoryModel()
        {
        }

        public CategoryModel(Guid id, string title, Guid? parentCategoryId, DateTime updatedAt, DateTime createdAt)
        {
            Id = id;
            Title = title;
            ParentCategoryId = parentCategoryId;
            UpdatedAt = updatedAt;
            CreatedAt = createdAt;
        }
    }
}