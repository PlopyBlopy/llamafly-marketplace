using AutoMapper;
using Domain.Interfaces.Repositories.Products;
using Domain.Queries.Products;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Queries.Products
{
    internal sealed class GetByIdProductQueryHandler : IQueryHandler<GetByIdProductQuery, GetByIdProductResponse>
    {
        private readonly IGetByIdProductRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IGetByIdProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<GetByIdProductResponse>> Handle(GetByIdProductQuery request, CancellationToken ct)
        {
            var result = await _repository.GetByIdAsync(request, ct);

            return result.Map(src => _mapper.Map<GetByIdProductResponse>(src));
        }
    }
}