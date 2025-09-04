using API.Infrastructure;
using AutoMapper;
using Domain.Queries.Products;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Queries.Products
{
    public class GetAllProductsCards : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(Routes.GET_ALL_PRODUCTS_CARDS, static async ([FromQuery] int? Limit, ISender sender, IMapper mapper, CancellationToken ct) =>
            {
                var query = mapper.Map<GetAllProductsCardsQuery>(new GetAllProductsCardsRequest(Limit));

                Result<GetAllProductsCardsResponse> response = await sender.Send(query, ct);

                return response.Match(
                    (response) => Results.Ok(response.ProductsCards),
                    (errorResponse) => CustomResults.Problem(errorResponse)
                );
            }).WithTags(Tags.PRODUCTS_CARDS);
        }
    }
}