using AutoMapper;
using Domain.DTO;
using Domain.Product;

namespace Shared.Mapper.Converters.Product
{
    internal sealed class ProductModelToCardDtoConverter : ITypeConverter<ProductModel, ProductCardDto>
    {
        public ProductCardDto Convert(ProductModel source, ProductCardDto destination, ResolutionContext context)
        {
            return new ProductCardDto(source.Id, source.Title, source.Price, (double)source.Rating);
        }
    }
}