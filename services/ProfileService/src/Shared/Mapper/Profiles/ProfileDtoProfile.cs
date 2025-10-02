using AutoMapper;

namespace Shared.Mapper.Profiles
{
    internal class ProfileDtoProfile : Profile
    {
        public ProfileDtoProfile()
        {
            //CreateMap<ProfileDto, CreateProfileDto>().ConvertUsing(src => new CreateProfileDto(src.Name, src.Surname, src.Patronymic, src.Age, src.IsMale));
        }
    }
}