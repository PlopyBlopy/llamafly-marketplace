using MediatoR.Alternative.Lite;

namespace Application.Products.Create
{
    public sealed record CreateProductCommand() : IRequest<CreateProductResponse>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid SellerId { get; set; }
        public Guid CategoryId { get; set; }
    }
}