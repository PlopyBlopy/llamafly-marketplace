using AutoMapper;
using Domain.Commands.Categories;
using Domain.DTO;
using Domain.Interfaces.Repositories.Categories;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Commands.Categories
{
    internal class CreateCategoriesRangeWithIdCommandHandler : ICommandHandler<CreateCategoriesRangeWithIdCommand, CreateCategoriesRangeWithIdResponse>
    {
        private readonly ICreateCategoriesRangeRepository _repository;
        private readonly IMapper _mapper;

        public CreateCategoriesRangeWithIdCommandHandler(ICreateCategoriesRangeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CreateCategoriesRangeWithIdResponse>> Handle(CreateCategoriesRangeWithIdCommand command, CancellationToken ct)
        {
            var dto = _mapper.Map<CreateCategoriesRangeModelDto>(command);

            await _repository.CreateRangeAsync(dto, ct);

            return Result.Ok(new CreateCategoriesRangeWithIdResponse());
        }
    }
}