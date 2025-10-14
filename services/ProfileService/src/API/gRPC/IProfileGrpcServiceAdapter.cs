using Domain.Commands;
using Domain.DTO;
using Domain.Queries;
using ProfileServiceGrpc;

namespace Infrastructure.gRPCServices
{
    public interface IProfileGrpcServiceAdapter
    {
        LoginGrpcWithErrorResponse AdaptToGrpc(LoginResponse response);

        RegisterUserGrpcWithErrorResponse AdaptToGrpc(CreateUserResponse response);

        LoginQuery AdaptFromGrpc(LoginGrpcRequest request);

        CreateUserCommand AdaptFromGrpc(RegisterUserGrpcRequest request);

        CreateUserDto AdaptFromGrpc(RegisterUserGrpcDto request);

        CreateProfileDto AdaptFromGrpc(RegisterProfileGrpcDto request);
    }
}