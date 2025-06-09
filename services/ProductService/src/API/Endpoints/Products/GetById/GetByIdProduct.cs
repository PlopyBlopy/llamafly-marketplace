using Domain.Commands.Products.GetById;
using Microsoft.AspNetCore.Mvc;
using API.Endpoints;

namespace API.Endpoints.Products.GetById
{
    public class GetByIdProduct : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(Routes.GET_BY_ID_PRODUCTS, static async ([FromBody] GetByIdProductRequest request, CancellationToken ct) =>
            {
                return Results.Ok("All is ok");
            })
            .WithTags(Tags.PRODUCTS);
        }
    }
}
