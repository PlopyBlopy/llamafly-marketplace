using Domain.DTO;
using FluentResults;

namespace Domain.Interfaces.Repositories
{
    public interface ICreateUserRepository : IRepository
    {
        Task<Result<Guid>> AddAsync(CreateUserModelDto model, CancellationToken ct);
    }
}