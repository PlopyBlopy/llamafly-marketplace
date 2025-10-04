using AutoMapper;
using Domain.Queries;
using Domain.Queries.Services;

namespace Shared.Mapper.Profiles
{
    internal sealed class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<(string loginValue, LoginType loginType, string password), LoginUserQuery>().ConstructUsing(src => new LoginUserQuery(src.loginValue, src.loginType, src.password));
            CreateMap<LoginUserQuery, LoginRequest>().ConstructUsing(src => new LoginRequest(src.LoginValue, src.LoginType));
            CreateMap<(bool isVerified, Guid userId), LoginResponse>().ConstructUsing(src => new LoginResponse(src.isVerified, src.userId));
        }
    }
}