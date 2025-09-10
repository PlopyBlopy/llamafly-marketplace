using Domain.Product;

namespace Domain.DTO
{
    public sealed record CreateProductsRangeModelDto(List<ProductModel> Products);
}