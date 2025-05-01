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
            app.MapPost($"{Routes.PRODUCTS}", async (Request request, ISender sender, CancellationToken ct) =>
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

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.PRODUCTS);
        }
    }
}

//return result.Match(Results.Ok, CustomResults.Problem);

//public void MapEndpoint(IEndpointRouteBuilder app)
//{
//    app.MapPost($"{Routes.PRODUCTS}", async (Request request, IRequestHandler<CreateProductCommand, CreateProductResponse> handler, CancellationToken ct) =>
//    {
//        var command = new CreateProductCommand
//        {
//            Title = request.Title,
//            Description = request.Description,
//            Price = request.Price,
//            SellerId = request.SellerId,
//            CategoryId = request.CategoryId
//        };

//        var result = await handler.Handle(command, ct);

//        return result.IsFailed ? Results.Problem(result.ToString(), result.Errors.ToString()) : Results.Ok(result);
//    })
//    .WithTags(Tags.PRODUCTS);
//}