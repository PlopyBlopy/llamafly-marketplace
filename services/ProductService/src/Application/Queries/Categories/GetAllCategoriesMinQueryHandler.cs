using AutoMapper;
using Domain.Interfaces.Repositories.Categories;
using Domain.Queries.Categories;
using FluentResults;
using MediatoR.Alternative.Lite;
using Shared.Helpers;

namespace Application.Queries.Categories
{
    internal sealed class GetAllCategoriesMinQueryHandler : IQueryHandler<GetAllCategoriesMinQuery, GetAllCategoriesMinResponse>
    {
        private readonly IGetAllCategoriesMinRepository _repository;
        private readonly IMapper _mapper;
        private readonly CategoriesHierarchyFormatter _categoriesHierarchyFormatter;

        public GetAllCategoriesMinQueryHandler(IGetAllCategoriesMinRepository repository, IMapper mapper, CategoriesHierarchyFormatter categoriesHierarchyFormatter)
        {
            _repository = repository;
            _mapper = mapper;
            _categoriesHierarchyFormatter = categoriesHierarchyFormatter;
        }

        public async Task<Result<GetAllCategoriesMinResponse>> Handle(GetAllCategoriesMinQuery query, CancellationToken ct)
        {
            var flatListResult = await _repository.GetAllMinAsync(ct);

            var hierarchyList = _categoriesHierarchyFormatter.Formate(flatListResult.Value);

            return Result.Ok(_mapper.Map<GetAllCategoriesMinResponse>(hierarchyList));
        }
    }
}