using API.Infrastructure;
using AutoMapper;
using Domain.Queries.Categories;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Queries.Categories
{
    public class GetByIdCategory : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(Routes.GET_BY_ID_CATEGORY, static async ([FromRoute] Guid id, ISender sender, IMapper mapper, CancellationToken ct) =>
            {
                var query = mapper.Map<GetByIdCategoryQuery>(id);

                var response = await sender.Send(query, ct);

                return response.Match(
                    (response) => Results.Ok(response),
                    (errorResult) => CustomResults.Problem(errorResult)
                );
            }).WithTags(Tags.CATEGORIES);
        }
    }
}