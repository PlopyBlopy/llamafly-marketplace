using AutoMapper;
using Domain.Interfaces.Repositories.Categories;
using Domain.Queries.Categories;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Queries.Categories
{
    internal sealed class GetByIdCategoryQueryHandler : IQueryHandler<GetByIdCategoryQuery, GetByIdCategoryResponse>
    {
        private readonly IGetByIdCategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdCategoryQueryHandler(IGetByIdCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<GetByIdCategoryResponse>> Handle(GetByIdCategoryQuery query, CancellationToken ct)
        {
            var result = await _repository.GetByIdAsync(query.Id, ct);

            return result.Map(src => _mapper.Map<GetByIdCategoryResponse>(src));
        }
    }
}