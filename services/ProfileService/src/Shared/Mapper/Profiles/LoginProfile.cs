using AutoMapper;
using Domain.DTO;
using Domain.Queries;

namespace Shared.Mapper.Profiles
{
    internal class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<(string loginValue, LoginType loginType), LoginQuery>().ConstructUsing(src => new LoginQuery(src.loginValue, src.loginType));
            CreateMap<LoginQuery, LoginDto>().ConstructUsing(src => new LoginDto(src.LoginValue, src.LoginType));
            CreateMap<(bool isVerified, Guid userId), LoginResponse>().ConstructUsing(src => new LoginResponse(src.isVerified, src.userId));
        }
    }
}