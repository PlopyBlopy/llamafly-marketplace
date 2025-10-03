using AutoMapper;
using Domain.DTO;
using Domain.Models.Profile;
using Shared.Mapper.Converters;

namespace Shared.Mapper.Profiles
{
    internal class ProfileDtoProfile : Profile
    {
        public ProfileDtoProfile()
        {
            CreateMap<CreateProfileDto, ProfileModel>().ConvertUsing<CreateProfileDtoToModelConverter>();
        }
    }
}