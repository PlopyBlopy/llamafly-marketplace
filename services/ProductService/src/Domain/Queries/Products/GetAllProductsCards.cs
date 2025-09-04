using Domain.DTO;
using MediatoR.Alternative.Lite;

namespace Domain.Queries.Products
{
    public sealed record GetAllProductsCardsRequest(int? Limit);
    public sealed record GetAllProductsCardsResponse(List<ProductCardDto> ProductsCards);
    public sealed record GetAllProductsCardsQuery(int? Limit) : IQuery<GetAllProductsCardsResponse>;
}