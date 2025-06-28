using AutoMapper;
using Domain.Commands.Products.Update;
using Domain.Product;

namespace Shared.Mapper.Converters
{
    internal sealed class ProductModelToUpdateProductResponseConverter : ITypeConverter<ProductModel, UpdateProductResponse>
    {
        public UpdateProductResponse Convert(ProductModel source, UpdateProductResponse destination, ResolutionContext context)
        {
            return new UpdateProductResponse(source.Id, source.Title, source.Description, source.Price, source.CategoryId, source.SellerId);
        }
    }
}