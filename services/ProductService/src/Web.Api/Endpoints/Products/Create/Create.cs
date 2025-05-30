using Application.Products.Create;
using AutoMapper;
using FluentResults;
using MediatoR.Alternative.Lite;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Products.Create
{
    internal sealed class Create : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost($"{Routes.PRODUCTS}", static async (CreateProductRequest request, ISender sender, IMapper mapper, CancellationToken ct) =>
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