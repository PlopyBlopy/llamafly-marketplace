using AutoMapper;
using Domain.Commands.Products;
using Domain.Interfaces.Repositories.Products;
using Domain.Product;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Commands.Products
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

            var result = await _repository.CreateAsync(model, ct);

            return result.Map(src => _mapper.Map<CreateProductResponse>(src));
        }
    }
}