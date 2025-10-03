using AutoMapper;
using Domain.Commands;
using Domain.DTO;
using Domain.Models.Admin;
using Shared.Mapper.Converters;

namespace Shared.Mapper.Profiles
{
    internal class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<CreateAdminRequest, CreateAdminCommand>().ConstructUsing(src => new CreateAdminCommand(src.User, src.Profile, src.Admin));
            CreateMap<CreateAdminDto, AdminModel>().ConvertUsing<CreateAdminDtoToModelConverter>();

            CreateMap<CreateAdminCommand, CreateAdminModelDto>().ConvertUsing<CreateAdminCommandToCreateDtoConverter>();
            CreateMap<Guid, CreateAdminResponse>().ConstructUsing(src => new CreateAdminResponse(src));
        }
    }
}