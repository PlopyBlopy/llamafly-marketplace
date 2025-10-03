using Domain.Models.Admin;
using Domain.Models.Companies;
using Domain.Models.Customer;
using Domain.Models.Profile;
using Domain.Models.Role;
using Domain.Models.Seller;
using Domain.Models.Shop;
using Domain.Models.User;
using Domain.Models.UserRole;
using Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context
{
    internal sealed class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProfileModel> Profiles { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<UserRoleModel> UsersRoles { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<SellerModel> Sellers { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<ShopModel> Shops { get; set; }
        public DbSet<CompanyModel> Companies { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return await base.SaveChangesAsync(ct);
        }

        public void Detach<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Detached;
        }
    }
}