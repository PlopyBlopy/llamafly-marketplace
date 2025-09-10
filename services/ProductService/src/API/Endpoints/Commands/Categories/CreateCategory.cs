using API.Infrastructure;
using AutoMapper;
using Domain.Commands.Categories;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Commands.Categories
{
    internal sealed class CreateCategory : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(Routes.CREATE_CATEGORY, static async ([FromBody] CreateCategoryRequest request, ISender sender, IMapper mapper, CancellationToken ct) =>
            {
                var command = mapper.Map<CreateCategoryCommand>(request);

                Result<CreateCategoryResponse> response = await sender.Send(command, ct);

                return response.Match(
                    (response) => Results.Created(Routes.CREATE_CATEGORY, response.Id),
                    (errorResponse) => CustomResults.Problem(errorResponse)
                );
            }).WithTags(Tags.CATEGORIES).WithOpenApi();
        }
    }
}