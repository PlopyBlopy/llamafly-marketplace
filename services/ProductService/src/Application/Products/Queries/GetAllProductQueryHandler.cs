using Domain.Interfaces.Repositories;
using Domain.Queries.Products.GetAll;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Products.Queries
{
    internal class GetAllProductQueryHandler : IQueryHandler<GetAllProductQuery, GetAllProductResponse>
    {
        private readonly IGetAllProductRepository _repository;

        public GetAllProductQueryHandler(IGetAllProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<GetAllProductResponse>> Handle(GetAllProductQuery request, CancellationToken ct)
        {
            var response = await _repository.GetAllAsync(ct);

            return response;
        }
    }
}