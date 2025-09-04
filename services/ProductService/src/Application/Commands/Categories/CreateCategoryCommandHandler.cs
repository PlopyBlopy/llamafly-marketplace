using AutoMapper;
using Domain.Category;
using Domain.Commands.Categories;
using Domain.Interfaces.Repositories.Categories;
using FluentResults;
using FluentResults.Extensions;
using MediatoR.Alternative.Lite;

namespace Application.Commands.Categories
{
    internal sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, CreateCategoryResponse>
    {
        private readonly ICreateCategoryRepository _repository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICreateCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<Result<CreateCategoryResponse>> Handle(CreateCategoryCommand command, CancellationToken ct)
        {
            var model = _mapper.Map<CategoryModel>(command);

            var result = _repository.CreateAsync(model, ct);

            return result.Map(src => _mapper.Map<CreateCategoryResponse>(src));
        }
    }
}