using API.Infrastructure;
using AutoMapper;
using Domain.Commands.Categories;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Commands.Categories
{
    internal sealed class CreateCategoriesRangeWithId : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(Routes.CREATE_CATEGORIES_RANGE_WITH_ID, static async ([FromBody] CreateCategoriesRangeWithIdRequest request, ISender sender, IMapper mapper, CancellationToken ct) =>
            {
                var command = mapper.Map<CreateCategoriesRangeWithIdCommand>(request);

                Result<CreateCategoriesRangeWithIdResponse> response = await sender.Send(command, ct);

                return response.Match(
                    (response) => Results.Created(Routes.CREATE_CATEGORIES_RANGE_WITH_ID, null),
                    (errorResponse) => CustomResults.Problem(errorResponse)
                );
            }).WithTags(Tags.CATEGORIES);
        }
    }
}