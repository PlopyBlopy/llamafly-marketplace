using AutoMapper;
using Domain.Commands.Products;

namespace Shared.Mapper.Converters.Product
{
    internal sealed class CreateProductRequestToCommandConverter : ITypeConverter<CreateProductRequest, CreateProductCommand>
    {
        public CreateProductCommand Convert(CreateProductRequest source, CreateProductCommand destination, ResolutionContext context)
        {
            return new CreateProductCommand(source.Title, source.Description, source.Price, source.SellerId, source.CategoryId);
        }
    }
}