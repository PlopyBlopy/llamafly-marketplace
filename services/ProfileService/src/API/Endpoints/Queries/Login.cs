using API.Infrastructure;
using AutoMapper;
using Domain.Queries;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;
using static Domain.Models.User.UserModelConstraints;

namespace API.Endpoints.Queries
{
    public class Login : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(Routes.LOGIN,
                async ([FromQuery] string LoginValue, LoginVariants LoginType,
                       ISender sender,
                       IMapper mapper,
                       CancellationToken cancellationToken) =>
                {
                    var query = mapper.Map<LoginQuery>((LoginValue, LoginType));
                    Result<LoginResponse> result = await sender.Send(query, cancellationToken);

                    return result.Match(
                        success => Results.Ok(success),
                        error => CustomResults.Problem(error)
                    );
                })
                .WithTags(Tags.USER);
        }
    }
}