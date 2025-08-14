using Domain.Commands.Products;
using FluentResults;

namespace Domain.Interfaces.Repositories
{
    public interface IRemoveProductRepository
    {
        Task<Result<Guid>> RemoveAsync(RemoveProductCommand command, CancellationToken ct);
    }
}