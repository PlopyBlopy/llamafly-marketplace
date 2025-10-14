using AutoMapper;
using Domain.Queries;
using Domain.Queries.Services;
using static Domain.Models.CommonConstraints;

namespace Shared.Mapper.Profiles
{
    internal sealed class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<(string loginValue, LoginVariants loginType, string password), LoginUserQuery>().ConstructUsing(src => new LoginUserQuery(src.loginValue, src.loginType, src.password));
            CreateMap<LoginUserQuery, LoginRequest>().ConstructUsing(src => new LoginRequest(src.LoginValue, src.LoginType));
            //CreateMap<LoginResponse, LoginUserResponse>().ConstructUsing(src => new LoginUserResponse());

            CreateMap<(string accessToken, string refreshToken, DateTime accessTokenExpiresAt, DateTime refreshTokenExpiresAt), LoginUserResponse>().ConstructUsing(src => new LoginUserResponse(src.accessToken, src.refreshToken, src.accessTokenExpiresAt, src.refreshTokenExpiresAt));
        }
    }
}