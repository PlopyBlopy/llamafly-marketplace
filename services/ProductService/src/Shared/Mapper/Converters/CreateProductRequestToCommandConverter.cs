using AutoMapper;
using Domain.Commands.Products.Create;

namespace Shared.Mapper.Converters
{
    internal sealed class CreateProductRequestToCommandConverter : ITypeConverter<CreateProductRequest, CreateProductCommand>
    {
        public CreateProductCommand Convert(CreateProductRequest source, CreateProductCommand destination, ResolutionContext context)
        {
            return new CreateProductCommand(source.Title, source.Description, source.Price, source.SellerId, source.CategoryId);
        }
    }
}