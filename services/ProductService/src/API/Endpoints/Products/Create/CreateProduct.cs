using API.Infrastructure;
using AutoMapper;
using Domain.Commands.Products.Create;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Products.Create
{
    internal sealed class CreateProduct : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(Routes.PRODUCTS, static async ([FromBody] CreateProductRequest request, ISender sender, IMapper mapper, CancellationToken ct) =>
            {
                var command = mapper.Map<CreateProductCommand>(request);

                Result<CreateProductResponse> result = await sender.Send(command, ct);

                return result.Match(
                    (response) => Results.Ok(response),
                    (errorResult) => CustomResults.Problem(errorResult)
                );
            })
            .WithTags(Tags.PRODUCTS);
        }
    }
}