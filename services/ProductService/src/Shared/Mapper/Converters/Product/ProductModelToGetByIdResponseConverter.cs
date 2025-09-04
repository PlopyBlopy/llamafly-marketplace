using AutoMapper;
using Domain.Product;
using Domain.Queries.Products;

namespace Shared.Mapper.Converters.Product
{
    internal sealed class ProductModelToGetByIdResponseConverter : ITypeConverter<ProductModel, GetByIdProductResponse>
    {
        public GetByIdProductResponse Convert(ProductModel source, GetByIdProductResponse destination, ResolutionContext context)
        {
            return new GetByIdProductResponse(source.Id, source.Title, source.Description, source.Price, source.Rating, source.UpdatedAt, source.CreatedAt);
        }
    }
}