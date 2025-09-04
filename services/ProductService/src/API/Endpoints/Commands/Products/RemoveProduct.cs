using API.Infrastructure;
using AutoMapper;
using Domain.Commands.Products;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Commands.Products
{
    public class RemoveProduct : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete(Routes.REMOVE_PRODUCT, async static ([FromBody] RemoveProductRequest request, ISender sender, IMapper mapper, CancellationToken ct) =>
            {
                var command = mapper.Map<RemoveProductCommand>(request);

                Result<RemoveProductResponse> response = await sender.Send(command, ct);

                return response.Match(
                    (response) => Results.Ok(response),
                    (errorResponse) => CustomResults.Problem(errorResponse)
                );
            }).WithTags(Tags.PRODUCTS);
        }
    }
}