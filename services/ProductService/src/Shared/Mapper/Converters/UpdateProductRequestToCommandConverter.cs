using AutoMapper;
using Domain.Commands.Products.Update;

namespace Shared.Mapper.Converters
{
    internal sealed class UpdateProductRequestToCommandConverter : ITypeConverter<UpdateProductRequest, UpdateProductCommand>
    {
        public UpdateProductCommand Convert(UpdateProductRequest source, UpdateProductCommand destination, ResolutionContext context)
        {
            return new UpdateProductCommand(source.Id, source.Title, source.Description, source.Price, source.CategoryId);
        }
    }
}