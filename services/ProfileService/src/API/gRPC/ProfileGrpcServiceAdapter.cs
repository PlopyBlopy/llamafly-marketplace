using Domain.Commands;
using Domain.DTO;
using Domain.Queries;
using ProfileServiceGrpc;
using static Domain.Models.User.UserModelConstraints;

namespace Infrastructure.gRPCServices
{
    internal sealed class ProfileGrpcServiceAdapter : IProfileGrpcServiceAdapter
    {
        public LoginGrpcWithErrorResponse AdaptToGrpc(LoginResponse response)
        {
            if (response == null) throw new ArgumentNullException(nameof(response));

            return new LoginGrpcWithErrorResponse
            {
                ErrorResponse = null,
                Response = new LoginGrpcResponse
                {
                    IsVerified = response.IsVerified,
                    UserId = response.UserId.ToString(),
                    UserRoleVariant = (RoleVariantsGrpc)response.UserRole
                }
            };
        }

        public RegisterUserGrpcWithErrorResponse AdaptToGrpc(CreateUserResponse response)
        {
            if (response == null) throw new ArgumentNullException(nameof(response));

            return new RegisterUserGrpcWithErrorResponse
            {
                ErrorResponse = null,
                Response = new RegisterUserGrpcResponse
                {
                    UserId = response.UserId.ToString(),
                }
            };
        }

        public LoginQuery AdaptFromGrpc(LoginGrpcRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return new LoginQuery(request.LoginValue, (LoginVariants)request.LoginVariant);
        }

        public CreateUserCommand AdaptFromGrpc(RegisterUserGrpcRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return new CreateUserCommand(AdaptFromGrpc(request.User), AdaptFromGrpc(request.Profile));
        }

        public CreateUserDto AdaptFromGrpc(RegisterUserGrpcDto request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return new CreateUserDto(request.Login, request.PhoneNumber, request.Email);
        }

        public CreateProfileDto AdaptFromGrpc(RegisterProfileGrpcDto request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return new CreateProfileDto(request.Name, request.Surname, request.Patronymic, request.Age, request.IsMale);
        }
    }
}