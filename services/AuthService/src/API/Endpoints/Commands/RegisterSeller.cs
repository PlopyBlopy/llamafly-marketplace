using API.Infrastructure;
using AutoMapper;
using Domain.Commands;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Commands
{
    public class RegisterSeller : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(Routes.REGISTER_SELLER,
                async ([FromBody] RegisterSellerRequest request,
                       ISender sender,
                       IMapper mapper,
                       CancellationToken cancellationToken) =>
                {
                    var command = mapper.Map<RegisterSellerCommand>(request);
                    Result<RegisterSellerResponse> result = await sender.Send(command, cancellationToken);

                    return result.Match(
                        success => Results.Ok(),
                        error => CustomResults.Problem(error)
                    );
                })
                .WithTags(Tags.SELLER);
        }
    }
}