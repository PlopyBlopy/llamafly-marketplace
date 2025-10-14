using Domain.Models.Password;
using Domain.Models.RefreshToken;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.Abstractions
{
    public interface IDatabaseContext
    {
        DatabaseFacade Database { get; }
        DbSet<PasswordModel> Passwords { get; set; }
        DbSet<RefreshTokenModel> RefreshTokens { get; set; }

        Task<int> SaveChangesAsync(CancellationToken ct = default);

        void Detach<TEntity>(TEntity entity) where TEntity : class;
    }
}