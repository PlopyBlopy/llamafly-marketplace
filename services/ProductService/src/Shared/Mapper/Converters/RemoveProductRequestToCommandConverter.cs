using AutoMapper;
using Domain.Commands.Products.Remove;

namespace Shared.Mapper.Converters
{
    internal sealed class RemoveProductRequestToCommandConverter : ITypeConverter<RemoveProductRequest, RemoveProductCommand>
    {
        public RemoveProductCommand Convert(RemoveProductRequest source, RemoveProductCommand destination, ResolutionContext context)
        {
            return new RemoveProductCommand(source.Id);
        }
    }
}