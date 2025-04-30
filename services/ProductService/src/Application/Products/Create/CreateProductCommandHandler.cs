using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Products.Create
{
    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
    {
        public async Task<Result<CreateProductResponse>> Handle(CreateProductCommand request, CancellationToken ct)
        {
            CreateProductResponse response = new CreateProductResponse(Guid.NewGuid());

            return Result.Ok(response);
        }
    }
}