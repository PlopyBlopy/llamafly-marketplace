using API.Infrastructure;
using AutoMapper;
using Domain.Queries.Categories;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Queries.Categories
{
    public class CategoryExist : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(Routes.CATEGORY_EXIST, static async ([FromRoute] Guid id, ISender sender, IMapper mapper, CancellationToken ct) =>
            {
                var query = mapper.Map<CategoryExistQuery>(id);

                var response = await sender.Send(query, ct);

                return response.Match(
                    (response) => Results.Ok(response),
                    (errorResponse) => CustomResults.Problem(errorResponse)
                );
            }).WithTags(Tags.CATEGORIES);
        }
    }
}