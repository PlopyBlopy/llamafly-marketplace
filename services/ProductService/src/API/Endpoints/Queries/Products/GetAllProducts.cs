using API.Infrastructure;
using AutoMapper;
using Domain.Queries.Products;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Queries.Products
{
    public class GetAllProducts : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(Routes.GET_ALL_PRODUCTS, static async ([FromQuery] int? limit, ISender sender, IMapper mapper, CancellationToken ct) =>
            {
                var query = new GetAllProductsQuery(limit);
                Result<GetAllProductsResponse> response = await sender.Send(query, ct);

                return response.Match(
                    (response) => Results.Ok(response.Products),
                    (errorResponse) => CustomResults.Problem(errorResponse)
                );
            }).WithTags(Tags.PRODUCTS);
        }
    }
}