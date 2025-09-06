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
            var flatListResult = await _repository.GetAllAsync(ct);

            var hierarchyList = _categoriesHierarchyFormatter.Formate(flatListResult.Value);

            return Result.Ok(_mapper.Map<GetAllCategoriesResponse>(hierarchyList));
        }
    }
}