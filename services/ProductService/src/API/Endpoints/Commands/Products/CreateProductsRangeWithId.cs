using API.Infrastructure;
using AutoMapper;
using Domain.Commands.Products;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Commands.Products
{
    internal sealed class CreateProductsRangeWithId : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(Routes.CREATE_PRODUCTS_RANGE_WITH_ID, static async ([FromBody] CreateProductsRangeWithIdRequest request, ISender sender, IMapper mapper, CancellationToken ct) =>
            {
                var command = mapper.Map<CreateProductsRangeWithIdCommand>(request);

                Result<CreateProductsRangeWithIdResponse> response = await sender.Send(command, ct);

                return response.Match(
                    (response) => Results.Created(Routes.CREATE_PRODUCTS_RANGE_WITH_ID, null),
                    (errorResponse) => CustomResults.Problem(errorResponse)
                );
            })
            .WithTags(Tags.PRODUCTS);
        }
    }
}