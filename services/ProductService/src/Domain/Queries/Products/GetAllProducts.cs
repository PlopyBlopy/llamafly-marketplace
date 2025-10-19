using Domain.Product;
using MediatoR.Alternative.Lite;

namespace Domain.Queries.Products
{
    public sealed record GetAllProductsRequest(int? Limit);
    public record GetAllProductsResponse(List<ProductModel> Products);
    public sealed record GetAllProductsQuery(int? Limit) : IQuery<GetAllProductsResponse>;
}