using AutoMapper;
using Domain.DTO;
using Domain.Queries;
using static Domain.Models.User.UserModelConstraints;

namespace Shared.Mapper.Profiles
{
    internal class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<(string loginValue, LoginVariants loginType), LoginQuery>().ConstructUsing(src => new LoginQuery(src.loginValue, src.loginType));
            CreateMap<LoginQuery, LoginDto>().ConstructUsing(src => new LoginDto(src.LoginValue, src.LoginType));
            CreateMap<(bool isVerified, LoginResultDto dto), LoginResponse>().ConstructUsing(src => new LoginResponse(src.isVerified, src.dto.UserId, src.dto.UserRole));
        }
    }
}