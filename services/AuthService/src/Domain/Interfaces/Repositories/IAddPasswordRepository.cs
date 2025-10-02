using Domain.Models.Password;
using FluentResults;

namespace Domain.Interfaces.Repositories
{
    public interface IAddPasswordRepository : IRepository
    {
        Task<Result> AddAsync(PasswordModel model, CancellationToken ct);
    }
}