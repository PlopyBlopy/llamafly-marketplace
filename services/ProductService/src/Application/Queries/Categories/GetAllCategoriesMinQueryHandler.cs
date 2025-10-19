using AutoMapper;
using Domain.Interfaces.Repositories.Categories;
using Domain.Queries.Categories;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Queries.Categories
{
    internal sealed class GetAllCategoriesMinQueryHandler : IQueryHandler<GetAllCategoriesMinQuery, GetAllCategoriesMinResponse>
    {
        private readonly IGetAllCategoriesMinRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCategoriesMinQueryHandler(IGetAllCategoriesMinRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<GetAllCategoriesMinResponse>> Handle(GetAllCategoriesMinQuery query, CancellationToken ct)
        {
            var hierarchyResult = await _repository.GetAllMinAsync(ct);

            return Result.Ok(_mapper.Map<GetAllCategoriesMinResponse>(hierarchyResult.Value));
        }
    }
}