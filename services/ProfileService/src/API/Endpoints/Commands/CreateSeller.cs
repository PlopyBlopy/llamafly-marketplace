using API.Infrastructure;
using AutoMapper;
using Domain.Commands;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Commands
{
    public class CreateSeller : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(Routes.CREATE_SELLER,
                async ([FromBody] CreateSellerRequest request,
                       ISender sender,
                       IMapper mapper,
                       CancellationToken cancellationToken) =>
                {
                    var command = mapper.Map<CreateSellerCommand>(request);

                    Result<CreateSellerResponse> result = await sender.Send(command, cancellationToken);

                    return result.Match(
                        success => Results.Created(Routes.CREATE_SELLER, success),
                        error => CustomResults.Problem(error)
                    );
                }).WithTags(Tags.PROFILE);
        }
    }
}