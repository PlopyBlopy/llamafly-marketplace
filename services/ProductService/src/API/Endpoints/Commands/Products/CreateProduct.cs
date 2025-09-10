using API.Infrastructure;
using AutoMapper;
using Domain.Commands.Products;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Commands.Products
{
    internal sealed class CreateProduct : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(Routes.CREATE_PRODUCTS, static async ([FromBody] CreateProductRequest request, ISender sender, IMapper mapper, CancellationToken ct) =>
            {
                var command = mapper.Map<CreateProductCommand>(request);

                Result<CreateProductResponse> response = await sender.Send(command, ct);

                return response.Match(
                    (response) => Results.Created(Routes.PRODUCTS, response.Id),
                    (errorResponse) => CustomResults.Problem(errorResponse)
                );
            })
            .WithTags(Tags.PRODUCTS);
        }
    }
}