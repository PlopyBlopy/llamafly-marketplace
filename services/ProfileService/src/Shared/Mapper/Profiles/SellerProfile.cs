using AutoMapper;
using Domain.Commands;
using Domain.DTO;
using Domain.Models.Seller;
using Shared.Mapper.Converters;

namespace Shared.Mapper.Profiles
{
    internal class SellerProfile : Profile
    {
        public SellerProfile()
        {
            CreateMap<CreateSellerRequest, CreateSellerCommand>().ConstructUsing(src => new CreateSellerCommand(src.User, src.Profile, src.Seller));
            CreateMap<CreateSellerDto, SellerModel>().ConvertUsing<CreateSellerDtoToModelConverter>();

            CreateMap<CreateSellerCommand, CreateSellerModelDto>().ConvertUsing<CreateSellerCommandToCreateDtoConverter>();
            CreateMap<Guid, CreateSellerResponse>().ConstructUsing(src => new CreateSellerResponse(src));
        }
    }
}