using AutoMapper;
using Domain.Interfaces.Repositories.Products;
using Domain.Queries.Products;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Queries.Products
{
    internal sealed class GetAllProductsCardsQueryHandler : IQueryHandler<GetAllProductsCardsQuery, GetAllProductsCardsResponse>
    {
        private readonly IGetAllProductsCardsRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductsCardsQueryHandler(IGetAllProductsCardsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<GetAllProductsCardsResponse>> Handle(GetAllProductsCardsQuery request, CancellationToken ct)
        {
            var result = await _repository.GetAllCardsAsync(request.Limit, ct);

            return result.Map(src => _mapper.Map<GetAllProductsCardsResponse>(src));
        }
    }
}