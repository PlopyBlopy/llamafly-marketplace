using AutoMapper;
using Domain.Interfaces.Repositories.Categories;
using Domain.Queries.Categories;
using Domain.Queries.Products;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Queries.Categories
{
    internal sealed class CategoryExistQueryHandler : IQueryHandler<CategoryExistQuery, CategoryExistResponse>
    {
        private readonly ICategoryExistRepository _repository;
        private readonly IMapper _mapper;

        public CategoryExistQueryHandler(ICategoryExistRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CategoryExistResponse>> Handle(CategoryExistQuery query, CancellationToken ct)
        {
            var result = await _repository.IsExistAsync(query.Id, ct);

            return result.Map(src => _mapper.Map<CategoryExistResponse>(src));
        }
    }
}