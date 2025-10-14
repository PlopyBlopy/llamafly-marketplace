using Domain.Commands;
using Domain.Commands.Services;
using Domain.Interfaces.Services;
using Domain.Queries.Services;
using FluentResults;
using Infrastructure.Extensions;

namespace Infrastructure.gRPCServices
{
    internal class ProfileGrpcService : IProfileService
    {
        private readonly ProfileServiceGrpc.ProfileService.ProfileServiceClient _profileClient;
        private readonly IProfileGrpcServiceAdapter _adapter;

        public ProfileGrpcService(ProfileServiceGrpc.ProfileService.ProfileServiceClient profileServiceClient, IProfileGrpcServiceAdapter adapter)
        {
            _profileClient = profileServiceClient;
            _adapter = adapter;
        }

        public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken ct)
        {
            var requestMessage = _adapter.AdaptToGrpc(request);
            var responseMessage = await _profileClient.LoginAsync(requestMessage);

            if (responseMessage.ErrorResponse is not null)
                return responseMessage.ErrorResponse.HandleErrorsAsync<LoginResponse>();

            var response = _adapter.AdaptFromGrpc(responseMessage.Response);

            return Result.Ok(response);
        }

        public async Task<Result<RegisterUserResponse>> RegisterUserAsync(RegisterUserRequest request, CancellationToken ct)
        {
            var requestMessage = _adapter.AdaptToGrpc(request);
            var responseMessage = await _profileClient.RegisterUserAsync(requestMessage);

            if (responseMessage.ErrorResponse is not null)
                return responseMessage.ErrorResponse.HandleErrorsAsync<RegisterUserResponse>();

            var response = _adapter.AdaptFromGrpc(responseMessage.Response);

            return Result.Ok(response);
        }
    }
}