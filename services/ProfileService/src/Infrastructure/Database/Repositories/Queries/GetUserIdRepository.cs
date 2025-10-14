using Domain.DTO;
using Domain.Interfaces.Repositories;
using Domain.Models.User;
using FluentResults;
using FluentResults.Errors;
using Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using static Domain.Models.Role.RoleModelConstraints;
using static Domain.Models.User.UserModelConstraints;

namespace Infrastructure.Database.Repositories.Queries
{
    internal sealed class GetUserIdRepository : IGetUserIdRepository
    {
        private readonly IDatabaseContext _context;

        public GetUserIdRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Result<LoginResultDto>> GetAsync(LoginDto dto, CancellationToken ct)
        {
            IQueryable<UserModel> query = _context.Users;

            query = dto.LoginType switch
            {
                LoginVariants.Login => query.Where(e => e.Login == dto.LoginValue),
                LoginVariants.PhoneNumber => query.Where(e => e.PhoneNumber == dto.LoginValue),
                LoginVariants.Email => query.Where(e => e.Email == dto.LoginValue),
                _ => throw new ArgumentException("Incorrect login type.")
            };

            var result = await query
                .Join(
                    _context.UsersRoles,
                    user => user.Id,
                    userRole => userRole.UserId,
                    (user, userRole) => new
                    {
                        User = user,
                        UserRole = userRole
                    }
                )
                .Join
                (
                    _context.Roles,
                    combined => combined.UserRole.RoleId,
                    role => role.Id,
                    (combined, role) => new
                    {
                        UserId = combined.User.Id,
                        Role = role.Role
                    }
                )
                .FirstOrDefaultAsync(ct);

            if (result is null)
                Result.Fail<LoginResultDto>(new NotFoundError(nameof(LoginDto), nameof(UserModel)));

            if (!Enum.TryParse<RoleVariants>(result.Role, out var enumRole))
                return Result.Fail<LoginResultDto>(new Error("Invalid role value"));

            var loginResult = new LoginResultDto(result.UserId, enumRole);

            return Result.Ok(loginResult);
        }

        public async Task<Result<LoginResultDto>> GetQueryAsync(LoginDto dto, CancellationToken ct)
        {
            var result = await (from user in _context.Users
                                join userRoles in _context.UsersRoles
                                on user.Id equals userRoles.UserId
                                join role in _context.Roles
                                on userRoles.RoleId equals role.Id
                                where
                                    (dto.LoginType == LoginVariants.Login && user.Login == dto.LoginValue)
                                    || (dto.LoginType == LoginVariants.PhoneNumber && user.PhoneNumber == dto.LoginValue)
                                    || (dto.LoginType == LoginVariants.Email && user.Email == dto.LoginValue)
                                select new
                                {
                                    UserId = user.Id,
                                    Role = role.Role
                                })
                            .FirstOrDefaultAsync(ct);

            if (result is null)
                Result.Fail<LoginResultDto>(new NotFoundError(nameof(LoginDto), nameof(UserModel)));

            if (!Enum.TryParse<RoleVariants>(result.Role, out var enumRole))
                return Result.Fail<LoginResultDto>(new Error("Invalid role value"));

            var loginResult = new LoginResultDto(result.UserId, enumRole);

            return Result.Ok(loginResult);
        }

        public async Task<Result<LoginResultDto>> GetSqlAsync(LoginDto dto, CancellationToken ct)
        {
            string loginTypeFieldName = dto.LoginType switch
            {
                LoginVariants.Login => "login",
                LoginVariants.PhoneNumber => "phone_number",
                LoginVariants.Email => "email",
                _ => throw new ArgumentException("Incorrect login type.")
            };

            var result = await _context.Database.SqlQueryRaw<RawLoginResult>(
                $"""
                SELECT
                    u.id AS "{nameof(RawLoginResult.UserId)}",
                    r.role AS "{nameof(RawLoginResult.UserRole)}"
                FROM
                    users AS u
                INNER JOIN
                    users_roles AS ur
                    ON ur.user_id = u.id
                INNER JOIN
                    roles AS r
                    ON r.id = ur.role_id
                WHERE
                    u.{loginTypeFieldName} = @p0
                """, dto.LoginValue)
                .FirstOrDefaultAsync(ct);

            if (result is null)
                Result.Fail<LoginResultDto>(new NotFoundError(nameof(LoginDto), nameof(UserModel)));

            if (!Enum.TryParse<RoleVariants>(result.UserRole, out var enumRole))
                return Result.Fail<LoginResultDto>(new Error("Invalid role value"));

            var loginResult = new LoginResultDto(result.UserId, enumRole);

            return Result.Ok(loginResult);
        }
    }
}