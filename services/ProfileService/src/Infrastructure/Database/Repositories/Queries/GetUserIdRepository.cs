using Domain.DTO;
using Domain.Interfaces.Repositories;
using Domain.Models.User;
using FluentResults;
using FluentResults.Errors;
using Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.Queries
{
    internal sealed class GetUserIdRepository : IGetUserIdRepository
    {
        private readonly IDatabaseContext _context;

        public GetUserIdRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Result<Guid>> GetAsync(LoginDto dto, CancellationToken ct)
        {
            var result = await _context.Users.Where(e => e.Login == dto.LoginValue).Select(x => x.Id).FirstOrDefaultAsync(ct);

            return result == Guid.Empty
                ? Result.Fail<Guid>(new NotFoundError(nameof(LoginDto), nameof(UserModel)))
                : Result.Ok(result);
        }

        public async Task<Result<Guid>> GetQueryAsync(LoginDto dto, CancellationToken ct)
        {
            var result = await (from user in _context.Users
                                where user.Login == dto.LoginValue
                                select user.Id)
                            .FirstOrDefaultAsync(ct);

            return result == Guid.Empty
                ? Result.Fail<Guid>(new NotFoundError(nameof(LoginDto), nameof(UserModel)))
                : Result.Ok(result);
        }

        public async Task<Result<Guid>> GetSqlAsync(LoginDto dto, CancellationToken ct)
        {
            var result = await _context.Database.SqlQueryRaw<Guid>(
                """
                SELECT
                    id
                FROM
                    users AS u
                WHERE
                    u.login = {0}
                """, dto.LoginValue)
                .FirstOrDefaultAsync(ct);

            return result == Guid.Empty
                ? Result.Fail<Guid>(new NotFoundError(nameof(LoginDto), nameof(UserModel)))
                : Result.Ok(result);
        }
    }
}