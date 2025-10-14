using API.Infrastructure;
using AutoMapper;
using Domain.Queries;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;
using static Domain.Models.CommonConstraints;

namespace API.Endpoints.Queries
{
    public class LoginUser : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(Routes.LOGIN,
                async ([FromQuery] string loginValue, LoginVariants loginType, string password,
                       ISender sender,
                       IMapper mapper,
                       HttpContext httpContext,
                       CancellationToken cancellationToken) =>
                {
                    var command = mapper.Map<LoginUserQuery>((loginValue, loginType, password));
                    Result<LoginUserResponse> result = await sender.Send(command, cancellationToken);

                    if (result.IsFailed)
                        return CustomResults.Problem(result);

                    httpContext.Response.Cookies.Append("X-Access-Token", result.Value.AccessToken, new CookieOptions()
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = result.Value.AccessTokenExpiresAt
                    });
                    httpContext.Response.Cookies.Append("X-Refresh-Token", result.Value.RefreshToken, new CookieOptions()
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = result.Value.RefreshTokenExpiresAt
                    });

                    return Results.Ok();
                })
                .WithTags(Tags.AUTH);
        }
    }
}

//.RequireAuthorization(Enum.GetName(RolesVariants.Admin))