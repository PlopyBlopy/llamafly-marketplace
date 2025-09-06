using API.Infrastructure;
using Domain.Queries.Categories;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace API.Endpoints.Queries.Categories
{
    public class GetAllCategoriesMin : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(Routes.GET_ALL_CATEGORIES_MIN, static async (ISender sender, CancellationToken ct) =>
            {
                var query = new GetAllCategoriesMinQuery();

                Result<GetAllCategoriesMinResponse> response = await sender.Send(query, ct);

                return response.Match(
                    (response) => Results.Ok(response.Categories),
                    (errorResponse) => CustomResults.Problem(errorResponse)
                );
            }).WithTags(Tags.CATEGORIES);
        }
    }
}