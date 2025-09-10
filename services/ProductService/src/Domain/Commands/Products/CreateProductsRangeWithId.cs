using Domain.DTO;
using MediatoR.Alternative.Lite;

namespace Domain.Commands.Products
{
    public sealed record CreateProductsRangeWithIdRequest(List<ProductWithIdDto> Products);
    public sealed record CreateProductsRangeWithIdResponse();
    public sealed record CreateProductsRangeWithIdCommand(List<ProductWithIdDto> Products) : ICommand<CreateProductsRangeWithIdResponse>;
}