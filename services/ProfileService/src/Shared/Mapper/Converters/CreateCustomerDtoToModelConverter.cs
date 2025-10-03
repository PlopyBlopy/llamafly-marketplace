using AutoMapper;
using Domain.DTO;
using Domain.Models.Customer;
using Shared.Extensions;

namespace Shared.Mapper.Converters
{
    internal class CreateCustomerDtoToModelConverter : ITypeConverter<CreateCustomerDto, CustomerModel>
    {
        public CustomerModel Convert(CreateCustomerDto source, CustomerModel destination, ResolutionContext context)
        {
            var userId = context.GetRequiredItem<Guid>(ContextKeys.UserId);

            return new CustomerModel(Guid.NewGuid(), userId, 0.0, DateTime.Now);
        }
    }
}