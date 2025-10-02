using Domain.Models.AccessToken;
using Domain.Models.Password;
using Domain.Models.RefreshToken;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Abstractions
{
    public interface IDatabaseContext
    {
        DbSet<PasswordModel> Passwords { get; set; }
        DbSet<RefreshTokenModel> RefreshTokens { get; set; }
        DbSet<AccessTokenModel> AccessTokens { get; set; }

        Task<int> SaveChangesAsync(CancellationToken ct = default);

        void Detach<TEntity>(TEntity entity) where TEntity : class;
    }
}