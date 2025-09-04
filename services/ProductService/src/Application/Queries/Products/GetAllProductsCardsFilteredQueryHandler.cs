using AutoMapper;
using Domain.Interfaces.Repositories.Products;
using Domain.Queries.Products;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Queries.Products
{
    internal sealed class GetAllProductsCardsFilteredQueryHandler : IQueryHandler<GetAllProductsCardsFilteredQuery, GetAllProductsCardsFilteredResponse>
    {
        private readonly IGetAllProductsCardsFilteredRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductsCardsFilteredQueryHandler(IGetAllProductsCardsFilteredRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<GetAllProductsCardsFilteredResponse>> Handle(GetAllProductsCardsFilteredQuery query, CancellationToken ct)
        {
            var result = await _repository.GetAllCardsFilteredAsync(query.Filters, ct);

            return result.Map(src => _mapper.Map<GetAllProductsCardsFilteredResponse>(src));
        }
    }
}