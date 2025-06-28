using AutoMapper;
using Domain.Commands.Products.Create;
using Domain.Interfaces.Repositories;
using Domain.Product;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Products.Commands
{
    internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResponse>
    {
        private readonly ICreateProductRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(ICreateProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CreateProductResponse>> Handle(CreateProductCommand request, CancellationToken ct)
        {
            var model = _mapper.Map<ProductModel>(request);

            var productId = await _repository.CreateAsync(model, ct);

            return Result.Ok(new CreateProductResponse(productId.Value));
        }
    }
}