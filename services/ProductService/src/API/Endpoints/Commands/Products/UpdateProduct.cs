using API.Infrastructure;
using AutoMapper;
using Domain.Commands.Products;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Commands.Products
{
    public class UpdateProduct : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPatch(Routes.UPDATE_PRODUCT, static async ([FromBody] UpdateProductRequest request, ISender sender, IMapper mapper, CancellationToken ct) =>
            {
                var query = mapper.Map<UpdateProductCommand>(request);

                Result<UpdateProductResponse> response = await sender.Send(query, ct);

                return response.Match(
                    (response) => Results.Ok(response),
                    (errorResponse) => CustomResults.Problem(errorResponse)
                );
            })
            .WithTags(Tags.PRODUCTS);
        }
    }
}