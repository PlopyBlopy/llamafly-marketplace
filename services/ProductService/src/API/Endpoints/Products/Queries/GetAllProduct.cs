using API.Infrastructure;
using AutoMapper;
using Domain.Queries.Products.GetAll;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace API.Endpoints.Products.Queries
{
    public class GetAllProduct : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(Routes.GET_ALL_PRODUCTS, static async (ISender sender, IMapper mapper, CancellationToken ct) =>
            {
                var query = new GetAllProductQuery();
                Result<GetAllProductResponse> response = await sender.Send(query, ct);

                return response.Match(
                    (response) => Results.Ok(response.Products),
                    (errorResponse) => CustomResults.Problem(errorResponse)
                );
            }).WithTags(Tags.PRODUCTS);
        }
    }
}