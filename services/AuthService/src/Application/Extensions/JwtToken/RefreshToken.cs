using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Models.RefreshToken;
using Domain.Options;
using FluentResults;
using Microsoft.Extensions.Options;

namespace Application.Extensions.JwtToken
{
    internal sealed class RefreshToken : IRefreshToken
    {
        private readonly IOptionsSnapshot<JwtOptions> _options;
        private readonly IAddRefreshTokenRepository _repository;
        private readonly IMapper _mapper;

        public RefreshToken(IOptionsSnapshot<JwtOptions> options, IAddRefreshTokenRepository repository, IMapper mapper)
        {
            _options = options;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<(string refreshToken, DateTime expiresAt)>> GenerateRefreshTokenAsync(Guid userId, CancellationToken ct)
        {
            var refreshToken = Guid.NewGuid();
            var expiresAt = DateTime.Now.AddDays(14);

            var model = _mapper.Map<RefreshTokenModel>((userId, refreshToken, expiresAt));

            var result = await _repository.AddAsync(model, ct);

            return result.IsSuccess
                ? Result.Ok((refreshToken.ToString(), expiresAt))
                : Result.Fail<(string, DateTime)>(result.Errors);
        }

        public Result<bool> ValidateRefreshToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}