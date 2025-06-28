using API.Infrastructure;
using AutoMapper;
using Domain.Commands.Products.Create;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Products.Commands
{
    internal sealed class CreateProduct : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(Routes.PRODUCTS, static async ([FromBody] CreateProductRequest request, ISender sender, IMapper mapper, CancellationToken ct) =>
            {
                var command = mapper.Map<CreateProductCommand>(request);

                Result<CreateProductResponse> response = await sender.Send(command, ct);

                return response.Match(
                    (response) => Results.Ok(response),
                    (errorResponse) => CustomResults.Problem(errorResponse)
                );
            })
            .WithTags(Tags.PRODUCTS);
        }
    }
}