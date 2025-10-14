using API.Infrastructure;
using AutoMapper;
using Domain.Commands;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Commands
{
    public class CreateUser : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(Routes.REGISTER_USER,
                async ([FromBody] CreateUserRequest request,
                       ISender sender,
                       IMapper mapper,
                       CancellationToken cancellationToken) =>
                {
                    var command = mapper.Map<CreateUserCommand>(request);

                    Result<CreateUserResponse> result = await sender.Send(command, cancellationToken);

                    return result.Match(
                        success => Results.Created(Routes.CREATE_SELLER, success),
                        error => CustomResults.Problem(error)
                    );
                }).WithTags(Tags.USER);
        }
    }
}