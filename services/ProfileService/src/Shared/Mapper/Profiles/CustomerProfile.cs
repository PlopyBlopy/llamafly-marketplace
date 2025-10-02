namespace Shared.Mapper.Profiles
{
    internal class CustomerProfile : ProfileDtoProfile
    {
        public CustomerProfile()
        {
            //CreateMap<CreateCustomerRequest, CreateCustomerCommand>().ConstructUsing(src => new CreateCustomerCommand(src.User, src.Profile, src.Customer));
        }
    }
}