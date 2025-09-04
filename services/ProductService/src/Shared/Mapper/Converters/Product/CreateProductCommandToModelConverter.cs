using AutoMapper;
using Domain.Commands.Products;
using Domain.Product;

namespace Shared.Mapper.Converters.Product
{
    internal sealed class CreateProductCommandToModelConverter : ITypeConverter<CreateProductCommand, ProductModel>
    {
        public ProductModel Convert(CreateProductCommand source, ProductModel destination, ResolutionContext context)
        {
            DateTime createdDateTime = DateTime.Now;

            return new ProductModel(Guid.NewGuid(), source.Title, source.Description, source.Price, ProductConstraints.MIN_RATING, source.CategoryId, source.SellerId, createdDateTime, createdDateTime);
        }
    }
}