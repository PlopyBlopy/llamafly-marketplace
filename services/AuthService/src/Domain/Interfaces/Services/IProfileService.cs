using Domain.Commands.Services;
using FluentResults;
using Domain.Queries.Services;

namespace Domain.Interfaces.Services
{
    public interface IProfileService
    {
        Task<Result<CreateAdminResponse>> CreateAdminAsync(CreateAdminRequest request, CancellationToken ct);

        Task<Result<CreateSellerResponse>> CreateSellerAsync(CreateSellerRequest request, CancellationToken ct);

        Task<Result<CreateCustomerResponse>> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken ct);

        Task<Result<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken ct);
    }
}