using Application.Abstractions;
using Domain.Category;
using Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context
{
    internal sealed class DataBaseContext : DbContext, IDataBaseContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataBaseContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return await base.SaveChangesAsync(ct);
        }
    }
}