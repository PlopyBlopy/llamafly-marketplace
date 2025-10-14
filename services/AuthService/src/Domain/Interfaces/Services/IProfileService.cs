using Domain.Commands;
using Domain.Commands.Services;
using Domain.Queries.Services;
using FluentResults;

namespace Domain.Interfaces.Services
{
    public interface IProfileService
    {
        Task<Result<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken ct);

        Task<Result<RegisterUserResponse>> RegisterUserAsync(RegisterUserRequest request, CancellationToken ct);
    }
}