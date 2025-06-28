using API.Infrastructure;
using AutoMapper;
using Domain.Queries.Products.GetById;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Products.Queries
{
    public class GetByIdProduct : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(Routes.GET_BY_ID_PRODUCTS, static async ([FromBody] GetByIdProductRequest request, ISender sender, IMapper mapper, CancellationToken ct) =>
            {
                var query = mapper.Map<GetByIdProductQuery>(request);

                Result<GetByIdProductResponse> response = await sender.Send(query, ct);

                return response.Match(
                    (response) => Results.Ok(response),
                    (errorResponse) => CustomResults.Problem(errorResponse)
                );
            })
            .WithTags(Tags.PRODUCTS);
        }
    }
}