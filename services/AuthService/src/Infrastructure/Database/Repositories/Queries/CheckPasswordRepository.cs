using Domain.Interfaces.Repositories;
using FluentResults;
using FluentResults.Errors;
using Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.Queries
{
    internal sealed class CheckPasswordRepository : ICheckPasswordRepository
    {
        private readonly IDatabaseContext _context;

        public CheckPasswordRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> CheckPasswordAsync(Guid userId, CancellationToken ct)
        {
            var password = await _context.Passwords.Where(e => e.UserId == userId).Select(e => e.PasswordHash).FirstOrDefaultAsync();

            return password is null
                ? Result.Fail<string>(new NotFoundError("passwordHash", "password"))
                : Result.Ok(password);
        }

        public async Task<Result<string>> CheckPasswordQueryAsync(Guid userId, CancellationToken ct)
        {
            var passwordHash = await (from password in _context.Passwords
                                      where password.UserId == userId
                                      select password.PasswordHash)
                                .FirstOrDefaultAsync(ct);

            return passwordHash is null
                ? Result.Fail<string>(new NotFoundError("passwordHash", "password"))
                : Result.Ok(passwordHash);
        }

        public async Task<Result<string>> CheckPasswordSqlAsync(Guid userId, CancellationToken ct)
        {
            var password = await _context.Database.SqlQueryRaw<string>(
                """
                SELECT
                    password_hash
                FROM
                    users
                WHERE
                    user_id = {0}
                """, userId)
                .FirstOrDefaultAsync(ct);

            return password is null
                ? Result.Fail<string>(new NotFoundError("passwordHash", "password"))
                : Result.Ok(password);
        }
    }
}