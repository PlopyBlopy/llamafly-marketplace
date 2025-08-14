using MediatoR.Alternative.Lite;

namespace Domain.Queries.Products
{
    public record GetAllProductsQuery() : IQuery<GetAllProductsResponse>;
    public record GetAllProductsResponse(List<GetByIdProductResponse> Products);
}