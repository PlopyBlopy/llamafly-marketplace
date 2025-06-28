using AutoMapper;
using Domain.Commands.Products.Remove;
using Domain.Interfaces.Repositories;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Products.Commands
{
    internal sealed class RemoveProductCommandHandler : ICommandHandler<RemoveProductCommand, RemoveProductResponse>
    {
        private readonly IRemoveProductRepository _repository;
        private readonly IMapper _mapper;

        public RemoveProductCommandHandler(IRemoveProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<RemoveProductResponse>> Handle(RemoveProductCommand request, CancellationToken ct)
        {
            var result = await _repository.RemoveAsync(request, ct);

            var response = _mapper.Map<RemoveProductResponse>(result.Value);

            return response;
        }
    }
}