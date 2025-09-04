using API.Infrastructure;
using AutoMapper;
using Domain.Commands.Categories;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Commands.Categories
{
    /// <summary>
    /// Creates categories where the parent categories are defined relative to the nesting of the child categories.
    /// </summary>
    public class CreateCategoriesRange : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(Routes.CREATE_CATEGORIES_RANGE, static async ([FromBody] CreateCategoriesRangeRequest request, ISender sender, IMapper mapper, CancellationToken ct) =>
            {
                var command = mapper.Map<CreateCategoriesRangeCommand>(request);

                Result<CreateCategoriesRangeResponse> response = await sender.Send(command, ct);

                return response.Match(
                    (response) => Results.Created(),
                    (errorResponse) => CustomResults.Problem(errorResponse)
                );
            }).WithTags(Tags.CATEGORIES);
        }
    }
}