using Domain.Commands;
using Domain.Commands.Services;
using Domain.DTO;
using Domain.DTO.Services;

namespace Shared.Mapper.Profiles
{
    internal class CustomerProfile : ProfileDtoProfile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, CreateCustomerDto>().ConstructUsing(src => new CreateCustomerDto());

            CreateMap<RegisterCustomerRequest, RegisterCustomerCommand>().ConstructUsing(src => new RegisterCustomerCommand(src.User, src.Profile, src.Customer));
            CreateMap<RegisterCustomerCommand, CreateCustomerRequest>()
                .ConvertUsing((src, dest, context) => new CreateCustomerRequest(
                    context.Mapper.Map<CreateUserDto>(src.User),
                    context.Mapper.Map<CreateProfileDto>(src.Profile),
                    context.Mapper.Map<CreateCustomerDto>(src.Customer)
                ));
        }
    }
}