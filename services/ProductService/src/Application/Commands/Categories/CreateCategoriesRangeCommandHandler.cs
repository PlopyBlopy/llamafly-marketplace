using AutoMapper;
using Domain.Commands.Categories;
using Domain.DTO;
using Domain.Interfaces.Repositories.Categories;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Commands.Categories
{
    internal class CreateCategoriesRangeCommandHandler : ICommandHandler<CreateCategoriesRangeCommand, CreateCategoriesRangeResponse>
    {
        private readonly ICreateCategoriesRangeRepository _repository;
        private readonly IMapper _mapper;

        public CreateCategoriesRangeCommandHandler(ICreateCategoriesRangeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CreateCategoriesRangeResponse>> Handle(CreateCategoriesRangeCommand command, CancellationToken ct)
        {
            var modelDto = _mapper.Map<CreateCategoriesRangeModelDto>(command);

            await _repository.CreateRangeAsync(modelDto, ct);

            return Result.Ok(new CreateCategoriesRangeResponse(modelDto.Categories));
        }
    }
}