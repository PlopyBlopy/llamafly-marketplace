using AutoMapper;
using Domain.Commands.Products;
using Domain.DTO;
using Domain.Interfaces.Repositories.Products;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Commands.Products
{
    internal sealed class CreateProductsRangeWithIdCommandHandler : ICommandHandler<CreateProductsRangeWithIdCommand, CreateProductsRangeWithIdResponse>
    {
        private readonly ICreateProductsRangeRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductsRangeWithIdCommandHandler(ICreateProductsRangeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CreateProductsRangeWithIdResponse>> Handle(CreateProductsRangeWithIdCommand command, CancellationToken ct)
        {
            var dto = _mapper.Map<CreateProductsRangeModelDto>(command);

            await _repository.CreateRangeAsync(dto, ct);

            return Result.Ok(new CreateProductsRangeWithIdResponse());
        }
    }
}