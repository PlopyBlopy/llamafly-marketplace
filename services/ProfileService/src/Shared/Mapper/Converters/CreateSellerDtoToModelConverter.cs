using AutoMapper;
using Domain.DTO;
using Domain.Models.Seller;
using Shared.Extensions;

namespace Shared.Mapper.Converters
{
    internal class CreateSellerDtoToModelConverter : ITypeConverter<CreateSellerDto, SellerModel>
    {
        public SellerModel Convert(CreateSellerDto source, SellerModel destination, ResolutionContext context)
        {
            var userId = context.GetRequiredItem<Guid>(ContextKeys.UserId);

            return new SellerModel(Guid.NewGuid(), userId, null, null, source.PhoneContact, source.EmailContact, DateTime.Now);
        }
    }
}