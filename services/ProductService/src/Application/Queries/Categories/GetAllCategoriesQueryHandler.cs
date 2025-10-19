using AutoMapper;
using Domain.Interfaces.Repositories.Categories;
using Domain.Queries.Categories;
using FluentResults;
using MediatoR.Alternative.Lite;
using Shared.Helpers;

namespace Application.Queries.Categories
{
    internal sealed class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, GetAllCategoriesResponse>
    {
        private readonly IGetAllCategoriesRepository _repository;
        private readonly IMapper _mapper;
        private readonly CategoriesHierarchyFormatter _categoriesHierarchyFormatter;

        public GetAllCategoriesQueryHandler(IGetAllCategoriesRepository repository, IMapper mapper, CategoriesHierarchyFormatter categoriesHierarchyFormatter)
        {
            _repository = repository;
            _mapper = mapper;
            _categoriesHierarchyFormatter = categoriesHierarchyFormatter;
        }

        public async Task<Result<GetAllCategoriesResponse>> Handle(GetAllCategoriesQuery query, CancellationToken ct)
        {
            var hierarchyResult = await _repository.GetAllAsync(ct);

            return Result.Ok(_mapper.Map<GetAllCategoriesResponse>(hierarchyResult.Value));
        }
    }
}