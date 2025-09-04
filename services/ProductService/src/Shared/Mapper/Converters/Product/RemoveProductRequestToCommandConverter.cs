using AutoMapper;
using Domain.Commands.Products;

namespace Shared.Mapper.Converters.Product
{
    internal sealed class RemoveProductRequestToCommandConverter : ITypeConverter<RemoveProductRequest, RemoveProductCommand>
    {
        public RemoveProductCommand Convert(RemoveProductRequest source, RemoveProductCommand destination, ResolutionContext context)
        {
            return new RemoveProductCommand(source.Id);
        }
    }
}