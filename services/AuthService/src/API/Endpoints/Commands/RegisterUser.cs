using API.Infrastructure;
using AutoMapper;
using Domain.Commands;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Commands
{
    public class RegisterUser : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(Routes.REGISTER,
                async ([FromBody] RegisterUserRequest request,
                       ISender sender,
                       IMapper mapper,
                       CancellationToken cancellationToken) =>
                {
                    var command = mapper.Map<RegisterUserCommand>(request);
                    Result<RegisterUserResponse> result = await sender.Send(command, cancellationToken);

                    return result.Match(
                        success => Results.Created(),
                        error => CustomResults.Problem(error)
                    );
                })
                .WithTags(Tags.USER);
        }
    }
}