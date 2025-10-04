using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Password;
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

        public LoginQueryHandler(IProfileService profileService, ICheckPasswordRepository repository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _profileService = profileService;
            _repository = repository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result<LoginUserResponse>> Handle(LoginUserQuery command, CancellationToken ct)
        {
            var request = _mapper.Map<LoginRequest>(command);

            var response = await _profileService.LoginAsync(request, ct);

            if (response.IsFailed || !response.Value.IsVerified)
                return response.Map(src => new LoginUserResponse());

            var result = await _repository.CheckPasswordAsync(response.Value.UserId, ct);

            if (result.IsFailed || result.Value == null)
                return result.Map(src => new LoginUserResponse());

            var verifiedPassword = _passwordHasher.Verify(command.Password, result.Value);

            return verifiedPassword
                ? Result.Ok(new LoginUserResponse())
                : Result.Fail<LoginUserResponse>(PasswordModelErrors.IS_NOT_VERIFIED);
        }
    }
}