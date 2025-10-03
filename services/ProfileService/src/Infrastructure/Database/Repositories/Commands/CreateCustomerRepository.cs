using Domain.DTO;
using Domain.Interfaces.Repositories;
using FluentResults;
using Infrastructure.Abstractions;

namespace Infrastructure.Database.Repositories.Commands
{
    internal sealed class CreateCustomerRepository : ICreateCustomerRepository
    {
        private readonly IDatabaseContext _context;

        public CreateCustomerRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Result<Guid>> AddAsync(CreateCustomerModelDto model, CancellationToken ct)
        {
            _context.Users.Add(model.User);
            _context.Profiles.Add(model.Profile);
            _context.Customers.Add(model.Customer);
            _context.Roles.Add(model.Role);
            _context.UsersRoles.Add(model.UserRole);

            await _context.SaveChangesAsync(ct);

            return Result.Ok(model.User.Id);
        }
    }
}