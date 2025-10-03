using Domain.DTO;
using FluentResults;

namespace Domain.Interfaces.Repositories
{
    public interface ICreateCustomerRepository : IRepository
    {
        Task<Result<Guid>> AddAsync(CreateCustomerModelDto model, CancellationToken ct);
    }
}