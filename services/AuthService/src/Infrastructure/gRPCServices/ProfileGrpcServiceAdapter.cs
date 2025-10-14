using Domain.Commands;
using Domain.Commands.Services;
using Domain.DTO;
using Domain.Queries.Services;
using ProfileServiceGrpc;
using static Domain.Models.CommonConstraints;

namespace Infrastructure.gRPCServices
{
    internal sealed class ProfileGrpcServiceAdapter : IProfileGrpcServiceAdapter
    {
        public LoginGrpcRequest AdaptToGrpc(LoginRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return new LoginGrpcRequest
            {
                LoginValue = request.LoginValue ?? string.Empty,
                LoginVariant = (LoginVariantsGrpc)request.LoginType
            };
        }

        public RegisterUserGrpcRequest AdaptToGrpc(RegisterUserRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return new RegisterUserGrpcRequest
            {
                User = AdaptToGrpc(request.User),
                Profile = AdaptToGrpc(request.Profile),
            };
        }

        public RegisterUserGrpcDto AdaptToGrpc(UserDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new RegisterUserGrpcDto
            {
                Login = dto.Login,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
            };
        }

        public RegisterProfileGrpcDto AdaptToGrpc(ProfileDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new RegisterProfileGrpcDto
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Patronymic = dto.Patronymic,
                Age = dto.Age,
                IsMale = dto.IsMale
            };
        }

        public LoginResponse AdaptFromGrpc(LoginGrpcResponse grpcResponse)
        {
            if (grpcResponse == null) throw new ArgumentNullException(nameof(grpcResponse));

            return new LoginResponse(
                IsVerified: grpcResponse.IsVerified,
                UserId: ParseGuidSafely(grpcResponse.UserId),
                UserRole: (RoleVariants)grpcResponse.UserRoleVariant
            );
        }

        public RegisterUserResponse AdaptFromGrpc(RegisterUserGrpcResponse grpcResponse)
        {
            if (grpcResponse == null) throw new ArgumentNullException(nameof(grpcResponse));

            return new RegisterUserResponse(ParseGuidSafely(grpcResponse.UserId));
        }

        private Guid ParseGuidSafely(string guidString)
        {
            if (Guid.TryParse(guidString, out Guid result))
                return result;

            throw new FormatException($"Invalid GUID format: {guidString}");
        }
    }
}