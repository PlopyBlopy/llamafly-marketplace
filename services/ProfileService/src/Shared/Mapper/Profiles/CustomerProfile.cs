using AutoMapper;
using Domain.Commands;
using Domain.DTO;
using Domain.Models.Customer;
using Shared.Mapper.Converters;

namespace Shared.Mapper.Profiles
{
    internal class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerRequest, CreateCustomerCommand>().ConstructUsing(src => new CreateCustomerCommand(src.User, src.Profile, src.Customer));
            CreateMap<CreateCustomerDto, CustomerModel>().ConvertUsing<CreateCustomerDtoToModelConverter>();

            CreateMap<CreateCustomerCommand, CreateCustomerModelDto>().ConvertUsing<CreateCustomerCommandToCreateDtoConverter>();
            CreateMap<Guid, CreateCustomerResponse>().ConstructUsing(src => new CreateCustomerResponse(src));
        }
    }
}