using Domain.Interfaces;
using Domain.Options;
using FluentResults;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Domain.Models.CommonConstraints;

namespace Application.Extensions.JwtToken
{
    internal sealed class AccessToken : IAccessToken
    {
        private readonly IOptionsSnapshot<JwtOptions> _options;

        public AccessToken(IOptionsSnapshot<JwtOptions> options)
        {
            _options = options;
        }

        public Result<(string accessToken, DateTime expiresAt)> GenerateAccessToken(Guid userId, RoleVariants userRole)
        {
            if (string.IsNullOrEmpty(_options.Value.SecredKey))
                throw new ArgumentException("Jwt:SecretKey is not configured");

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(ClaimTypes.Role, Enum.GetName(typeof(RoleVariants), userRole))
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.SecredKey));
            var creditals = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenExpiresAt = DateTime.Now.AddHours(1);

            var token = new JwtSecurityToken(
                issuer: _options.Value.Issuer,
                audience: _options.Value.Audience,
                claims: claims,
                expires: tokenExpiresAt,
                signingCredentials: creditals
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return string.IsNullOrEmpty(accessToken)
                ? Result.Fail<(string, DateTime)>("Token is null.")
                : Result.Ok((accessToken, tokenExpiresAt));
        }

        public Result<bool> ValidateAccessToken(string token)
        {
            return Result.Ok(true);
        }
    }
}