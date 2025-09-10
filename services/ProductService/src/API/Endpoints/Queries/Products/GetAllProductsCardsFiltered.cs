using API.Infrastructure;
using AutoMapper;
using Domain.DTO;
using Domain.Queries.Products;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Queries.Products
{
    public class GetAllProductsCardsFiltered : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(Routes.GET_ALL_PRODUCTS_CARDS_FILTERED, static async ([FromQuery] string? search, string? categoryId, string? sortProp, string? sortOrder, ISender sender, IMapper mapper, CancellationToken ct) =>
            {
                var query = mapper.Map<GetAllProductsCardsFilteredQuery>(
                    new GetAllProductsCardsFilteredRequest(
                        new ProductCardFiltersDto(
                            Search: search,
                            CategoryId: string.IsNullOrEmpty(categoryId) ? Guid.Empty : Guid.Parse(categoryId),
                            SortProp: sortProp,
                            SortOrder: sortOrder
                        )
                    )
                );

                Result<GetAllProductsCardsFilteredResponse> response = await sender.Send(query, ct);

                return response.Match(
                    (response) => Results.Ok(response.ProductsCards),
                    (errorResponse) => CustomResults.Problem(errorResponse)
                );
            }).WithTags(Tags.PRODUCTS_CARDS);
        }
    }
}