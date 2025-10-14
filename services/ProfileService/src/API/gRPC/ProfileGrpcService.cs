using Domain.Commands;
using Domain.Queries;
using FluentResults;
using Grpc.Core;
using Infrastructure.gRPCServices;
using MediatoR.Alternative.Lite;
using ProfileServiceGrpc;

namespace API.gRPC
{
    public class ProfileGrpcService : ProfileService.ProfileServiceBase
    {
        private readonly ISender _sender;
        private readonly IProfileGrpcServiceAdapter _adapter;

        public ProfileGrpcService(ISender sender, IProfileGrpcServiceAdapter adapter)
        {
            _sender = sender;
            _adapter = adapter;
        }

        public override async Task<LoginGrpcWithErrorResponse> Login(LoginGrpcRequest request, ServerCallContext context)
        {
            var query = _adapter.AdaptFromGrpc(request);

            Result<LoginResponse> response = await _sender.Send(query);

            return _adapter.AdaptToGrpc(response.Value);
        }

        public override async Task<RegisterUserGrpcWithErrorResponse> RegisterUser(RegisterUserGrpcRequest request, ServerCallContext context)
        {
            var command = _adapter.AdaptFromGrpc(request);

            Result<CreateUserResponse> response = await _sender.Send(command);

            return _adapter.AdaptToGrpc(response.Value);
        }
    }
}