using Domain.Commands.Products;
using FluentResults;

namespace Domain.Interfaces.Repositories.Products
{
    public interface IRemoveProductRepository : IRepository
    {
        Task<Result<Guid>> RemoveAsync(RemoveProductCommand command, CancellationToken ct);
    }
}