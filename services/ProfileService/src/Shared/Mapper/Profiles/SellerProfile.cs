namespace Shared.Mapper.Profiles
{
    internal class SellerProfile : ProfileDtoProfile
    {
        public SellerProfile()
        {
            //CreateMap<CreateSellerRequest, CreateSellerCommand>().ConstructUsing(src => new CreateSellerCommand(src.User, src.Profile, src.Seller));
        }
    }
}