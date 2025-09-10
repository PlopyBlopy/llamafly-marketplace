using AutoMapper;
using Domain.Commands.Products;
using Domain.DTO;
using Domain.Product;

namespace Shared.Mapper.Converters.Product
{
    internal sealed class CreateProductsRangeWithIdCommandToModelDtoConverter : ITypeConverter<CreateProductsRangeWithIdCommand, CreateProductsRangeModelDto>
    {
        public CreateProductsRangeModelDto Convert(CreateProductsRangeWithIdCommand source, CreateProductsRangeModelDto destination, ResolutionContext context)
        {
            List<ProductModel> products = new List<ProductModel>();

            foreach (var product in source.Products)
            {
                DateTime currentDateTime = DateTime.Now;
                products.Add(new ProductModel(
                    product.Id,
                    product.Title,
                    product.Description,
                    product.Price,
                    product.Rating,
                    product.CategoryId,
                    product.ShopId,
                    currentDateTime,
                    currentDateTime
                ));
            }

            return new CreateProductsRangeModelDto(products);
        }
    }
}