using API.Infrastructure;
using AutoMapper;
using Domain.Queries;
using Domain.Queries.Services;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Queries
{
    public class LoginUser : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(Routes.LOGIN,
                async ([FromQuery] string loginValue, LoginType loginType, string password,
                       ISender sender,
                       IMapper mapper,
                       CancellationToken cancellationToken) =>
                {
                    var command = mapper.Map<LoginUserQuery>((loginValue, loginType, password));
                    Result<LoginUserResponse> result = await sender.Send(command, cancellationToken);

                    return result.Match(
                        success => Results.Ok(success),
                        error => CustomResults.Problem(error)
                    );
                })
                .WithTags(Tags.AUTH);
        }
    }
}