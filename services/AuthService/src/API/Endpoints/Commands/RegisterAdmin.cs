using API.Infrastructure;
using AutoMapper;
using Domain.Commands;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Commands
{
    public class RegisterAdmin : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(Routes.REGISTER_ADMIN,
                async ([FromBody] RegisterAdminRequest request,
                       ISender sender,
                       IMapper mapper,
                       CancellationToken cancellationToken) =>
                {
                    var command = mapper.Map<RegisterAdminCommand>(request);
                    Result<RegisterAdminResponse> result = await sender.Send(command, cancellationToken);

                    return result.Match(
                        success => Results.Created(),
                        error => CustomResults.Problem(error)
                    );
                })
                .WithTags(Tags.ADMIN);
        }
    }
}