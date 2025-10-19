using AutoMapper;
using Domain.Commands.Products;
using Domain.Interfaces.Repositories.Products;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Commands.Products
{
    internal sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, UpdateProductResponse>
    {
        private readonly IUpdateProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUpdateProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<UpdateProductResponse>> Handle(UpdateProductCommand command, CancellationToken ct)
        {
            var result = await _repository.UpdateAsync(command, ct);

            return result.Map(src => _mapper.Map<UpdateProductResponse>(src));
        }
    }
}