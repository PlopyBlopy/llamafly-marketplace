using API.Infrastructure;
using AutoMapper;
using Domain.Commands;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Commands
{
    public class CreateAdminEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(Routes.CREATE_ADMIN,
                async ([FromBody] CreateAdminRequest request,
                       ISender sender,
                       IMapper mapper,
                       CancellationToken cancellationToken) =>
                {
                    var command = mapper.Map<CreateAdminCommand>(request);
                    Result<CreateAdminResponse> result = await sender.Send(command, cancellationToken);

                    return result.Match(
                        success => Results.Created(Routes.CREATE_ADMIN, success),
                        error => CustomResults.Problem(error)
                    );
                }).WithTags(Tags.PROFILE);
        }
    }
}