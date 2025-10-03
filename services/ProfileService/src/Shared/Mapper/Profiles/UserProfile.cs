using AutoMapper;
using Domain.DTO;
using Domain.Models.User;
using Shared.Mapper.Converters;

namespace Shared.Mapper.Profiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, UserModel>().ConvertUsing<CreateUserDtoToModelConverter>();
        }
    }
}