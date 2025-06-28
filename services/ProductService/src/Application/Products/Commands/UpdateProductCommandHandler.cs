using AutoMapper;
using Domain.Commands.Products.Update;
using Domain.Interfaces.Repositories;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Products.Commands
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

        public async Task<Result<UpdateProductResponse>> Handle(UpdateProductCommand query, CancellationToken ct)
        {
            var result = await _repository.UpdateAsync(query, ct);

            var response = _mapper.Map<UpdateProductResponse>(result.Value);

            return response;
        }
    }
}