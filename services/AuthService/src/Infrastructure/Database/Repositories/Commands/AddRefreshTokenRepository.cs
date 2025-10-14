using Domain.Interfaces.Repositories;
using Domain.Models.RefreshToken;
using FluentResults;
using Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.Commands
{
    internal sealed class AddRefreshTokenRepository : IAddRefreshTokenRepository
    {
        private readonly IDatabaseContext _context;

        public AddRefreshTokenRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Result> AddAsync(RefreshTokenModel model, CancellationToken ct)
        {
            _context.RefreshTokens.Add(model);
            await _context.SaveChangesAsync(ct);

            return Result.Ok();
        }

        public async Task<Result> AddSqlAsync(RefreshTokenModel model, CancellationToken ct)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"""
                INSERT INTO refresh_tokens (id, user_id, token_refresh, is_revoked, expires_at, created_at)
                VALUES({model.Id}, {model.UserId}, {model.TokenRefresh}, {model.IsRevoked}, {model.ExpiresAt}, {model.CreatedAt})
                """, ct);

            //await _context.Database.ExecuteSqlRawAsync(
            //    """
            //    INSERT INTO refresh_tokens (id, user_id, token_refresh, is_revoked, expires_at, created_at)
            //    VALUES("@p0", "@p1", "@p2",@p3, @p4, @p5)
            //    """, [model.Id, model.UserId, model.TokenRefresh, model.IsRevoked, model.ExpiresAt, model.CreatedAt], ct);

            await _context.SaveChangesAsync(ct);

            return Result.Ok();
        }
    }
}