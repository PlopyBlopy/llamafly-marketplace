using AutoMapper;
using Domain.Commands.Products;

namespace Shared.Mapper.Converters.Product
{
    internal sealed class UpdateProductRequestToCommandConverter : ITypeConverter<UpdateProductRequest, UpdateProductCommand>
    {
        public UpdateProductCommand Convert(UpdateProductRequest source, UpdateProductCommand destination, ResolutionContext context)
        {
            return new UpdateProductCommand(source.Id, source.Title, source.Description, source.Price, source.CategoryId);
        }
    }
}