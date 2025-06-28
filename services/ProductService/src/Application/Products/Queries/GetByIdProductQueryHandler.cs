using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Queries.Products.GetById;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Products.Queries
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
            var model = await _repository.GetByIdAsync(request, ct);

            var response = _mapper.Map<GetByIdProductResponse>(model.Value);

            return response;
        }
    }
}