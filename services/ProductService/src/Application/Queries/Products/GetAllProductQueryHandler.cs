using Domain.Interfaces.Repositories.Products;
using Domain.Queries.Products;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Queries.Products
{
    internal class GetAllProductQueryHandler : IQueryHandler<GetAllProductsQuery, GetAllProductsResponse>
    {
        private readonly IGetAllProductRepository _repository;

        public GetAllProductQueryHandler(IGetAllProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<GetAllProductsResponse>> Handle(GetAllProductsQuery request, CancellationToken ct)
        {
            var response = await _repository.GetAllAsync(ct);

            return response;
        }
    }
}