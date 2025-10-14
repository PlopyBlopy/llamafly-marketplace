using Domain.Commands;
using Domain.Commands.Services;
using Domain.DTO;
using Domain.Queries.Services;
using ProfileServiceGrpc;

namespace Infrastructure.gRPCServices
{
    public interface IProfileGrpcServiceAdapter
    {
        LoginGrpcRequest AdaptToGrpc(LoginRequest request);

        RegisterUserGrpcRequest AdaptToGrpc(RegisterUserRequest request);

        RegisterUserGrpcDto AdaptToGrpc(UserDto dto);

        RegisterProfileGrpcDto AdaptToGrpc(ProfileDto dto);

        RegisterUserResponse AdaptFromGrpc(RegisterUserGrpcResponse grpcResponse);

        LoginResponse AdaptFromGrpc(LoginGrpcResponse grpcResponse);
    }
}