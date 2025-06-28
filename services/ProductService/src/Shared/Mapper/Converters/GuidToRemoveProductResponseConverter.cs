using AutoMapper;
using Domain.Commands.Products.Remove;

namespace Shared.Mapper.Converters
{
    internal sealed class GuidToRemoveProductResponseConverter : ITypeConverter<Guid, RemoveProductResponse>
    {
        public RemoveProductResponse Convert(Guid source, RemoveProductResponse destination, ResolutionContext context)
        {
            return new RemoveProductResponse(source);
        }
    }
}