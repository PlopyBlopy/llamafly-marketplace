using Domain.Commands;
using Domain.Commands.Services;
using Domain.DTO;
using Domain.DTO.Services;

namespace Shared.Mapper.Profiles
{
    internal class SellerProfile : ProfileDtoProfile
    {
        public SellerProfile()
        {
            CreateMap<SellerDto, CreateSellerDto>().ConstructUsing(src => new CreateSellerDto(src.PhoneContact, src.EmailContact));

            CreateMap<RegisterSellerRequest, RegisterSellerCommand>().ConstructUsing(src => new RegisterSellerCommand(src.User, src.Profile, src.Seller));
            CreateMap<RegisterSellerCommand, CreateSellerRequest>()
                .ConvertUsing((src, dest, context) => new CreateSellerRequest(
                    context.Mapper.Map<CreateUserDto>(src.User),
                    context.Mapper.Map<CreateProfileDto>(src.Profile),
                    context.Mapper.Map<CreateSellerDto>(src.Seller)
                ));
        }
    }
}