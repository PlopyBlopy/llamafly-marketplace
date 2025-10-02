using Domain.Interfaces.Repositories;
using Domain.Models.Password;
using FluentResults;
using Infrastructure.Abstractions;

namespace Infrastructure.Database.Repositories.Commands
{
    internal sealed class AddPasswordRepository : IAddPasswordRepository
    {
        private readonly IDatabaseContext _context;

        public AddPasswordRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Result> AddAsync(PasswordModel model, CancellationToken ct)
        {
            await _context.Passwords.AddAsync(model, ct);

            await _context.SaveChangesAsync(ct);

            return Result.Ok();
        }
    }
}