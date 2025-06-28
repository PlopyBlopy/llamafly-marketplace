using Domain.Commands.Products.Remove;
using Domain.Interfaces.Repositories;
using FluentResults;
using Infrastructure.Database.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.Products.Commands
{
    internal sealed class RemoveProductRepository : IRemoveProductRepository
    {
        private readonly IDataBaseContext _context;

        public RemoveProductRepository(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<Result<Guid>> RemoveAsync(RemoveProductCommand command, CancellationToken ct)
        {
            await _context.Products.Where(e => e.Id == command.Id).ExecuteDeleteAsync(ct);

            return Result.Ok(command.Id);
        }
    }
}