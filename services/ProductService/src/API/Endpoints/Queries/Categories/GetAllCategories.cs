using API.Infrastructure;
using Domain.Queries.Categories;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace API.Endpoints.Queries.Categories
{
    public class GetAllCategories : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(Routes.GET_ALL_CATEGORIES, static async (ISender sender, CancellationToken ct) =>
            {
                var query = new GetAllCategoriesQuery();

                Result<GetAllCategoriesResponse> response = await sender.Send(query, ct);

                return response.Match(
                    (response) => Results.Ok(response.Categories),
                    (errorResponse) => CustomResults.Problem(errorResponse)
                );
            }).WithTags(Tags.CATEGORIES);
        }
    }
}