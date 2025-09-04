using AutoMapper;
using Domain.Commands.Products;
using Domain.Interfaces.Repositories.Products;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Commands.Products
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

            return result.Map(src => _mapper.Map<RemoveProductResponse>(src));
        }
    }
}