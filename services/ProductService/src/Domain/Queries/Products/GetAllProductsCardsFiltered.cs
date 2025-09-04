using Domain.DTO;
using MediatoR.Alternative.Lite;

namespace Domain.Queries.Products
{
    public sealed record GetAllProductsCardsFilteredRequest(ProductCardFiltersDto Filters);

    public sealed record GetAllProductsCardsFilteredResponse(List<ProductCardDto> ProductsCards);
    public sealed record GetAllProductsCardsFilteredQuery(ProductCardFiltersDto Filters) : IQuery<GetAllProductsCardsFilteredResponse>;
}