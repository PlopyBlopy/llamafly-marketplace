using Application.Products.Create;
using AutoMapper;
using Web.Api.Endpoints.Products;

namespace Shared.Mappings.Converters
{
    internal sealed class CreateProductRequestToCommandConverter : ITypeConverter<CreateProductRequest, CreateProductCommand>
    {
        public CreateProductCommand Convert(CreateProductRequest source, CreateProductCommand destination, ResolutionContext context)
        {
            return new CreateProductCommand(source.Title, source.Description, source.Price, source.SellerId, source.CategoryId);
        }
    }
}