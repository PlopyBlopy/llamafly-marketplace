using Domain.Queries.Products.GetById;

namespace Domain.Queries.Products.GetAll
{
    public record GetAllProductResponse(List<GetByIdProductResponse> Products);
}