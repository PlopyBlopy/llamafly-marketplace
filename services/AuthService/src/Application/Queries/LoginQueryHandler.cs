using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Queries;
using Domain.Queries.Services;
using FluentResults;
using MediatoR.Alternative.Lite;

namespace Application.Queries
{
    internal sealed class LoginQueryHandler : IQueryHandler<LoginUserQuery, LoginUserResponse>
    {
        private readonly IProfileService _profileService;
        private readonly ICheckPasswordRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAccessToken _accessToken;
        private readonly IRefreshToken _refreshToken;

        public LoginQueryHandler(IProfileService profileService, ICheckPasswordRepository repository, IMapper mapper, IPasswordHasher passwordHasher, IAccessToken accessToken, IRefreshToken refreshToken)
        {
            _profileService = profileService;
            _repository = repository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _accessToken = accessToken;
            _refreshToken = refreshToken;
        }

        public async Task<Result<LoginUserResponse>> Handle(LoginUserQuery query, CancellationToken ct)
        {
            var request = _mapper.Map<LoginRequest>(query);

            var response = await _profileService.LoginAsync(request, ct);

            if (response.IsFailed || !response.Value.IsVerified)
                return Result.Fail<LoginUserResponse>(response.Errors);

            var result = await _repository.CheckPasswordAsync(response.Value.UserId, ct);

            if (result.IsFailed)
                return Result.Fail<LoginUserResponse>(result.Errors);

            var verifiedPassword = _passwordHasher.Verify(query.Password, result.Value);

            if (verifiedPassword.IsFailed)
                return Result.Fail<LoginUserResponse>(verifiedPassword.Errors);

            var accessToken = _accessToken.GenerateAccessToken(response.Value.UserId, response.Value.UserRole);

            if (accessToken.IsFailed)
                return Result.Fail<LoginUserResponse>(accessToken.Errors);

            var refreshTokenResult = await _refreshToken.GenerateRefreshTokenAsync(response.Value.UserId, ct);

            if (refreshTokenResult.IsFailed)
                return Result.Fail<LoginUserResponse>(refreshTokenResult.Errors);

            return Result.Ok(_mapper.Map<LoginUserResponse>((accessToken.Value.accessToken, refreshTokenResult.Value.refreshToken, accessToken.Value.expiresAt, refreshTokenResult.Value.expiresAt)));
        }
    }
}