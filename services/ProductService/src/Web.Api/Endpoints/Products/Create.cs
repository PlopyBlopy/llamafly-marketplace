using Application.Products.Create;
using FluentResults;
using MediatoR.Alternative.Lite;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Products
{
    internal sealed class Create : IEndpoint
    {
        public sealed record Request(string Title, string Description, decimal Price, Guid SellerId, Guid CategoryId);

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost($"{Routes.PRODUCTS}", static async (Request request, ISender sender, CancellationToken ct) =>
            {
                var command = new CreateProductCommand
                {
                    Title = request.Title,
                    Description = request.Description,
                    Price = request.Price,
                    SellerId = request.SellerId,
                    CategoryId = request.CategoryId
                };

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