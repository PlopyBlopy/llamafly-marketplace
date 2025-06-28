using Domain.Commands.Products.Remove;
using FluentResults;

namespace Domain.Interfaces.Repositories
{
    public interface IRemoveProductRepository
    {
        Task<Result<Guid>> RemoveAsync(RemoveProductCommand command, CancellationToken ct);
    }
}