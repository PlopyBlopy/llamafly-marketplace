using Domain.Models.Admin;
using Domain.Models.Companies;
using Domain.Models.Customer;
using Domain.Models.Profile;
using Domain.Models.Role;
using Domain.Models.Seller;
using Domain.Models.Shop;
using Domain.Models.User;
using Domain.Models.UserRole;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Abstractions
{
    public interface IDatabaseContext
    {
        public DbSet<UserModel> Products { get; }
        public DbSet<ProfileModel> Profiles { get; }
        public DbSet<RoleModel> Roles { get; }
        public DbSet<UserRoleModel> UsersRoles { get; }
        public DbSet<AdminModel> Admins { get; }
        public DbSet<SellerModel> Sellers { get; }
        public DbSet<CustomerModel> Customers { get; }
        public DbSet<ShopModel> Shops { get; }
        public DbSet<CompanyModel> Companies { get; }

        Task<int> SaveChangesAsync(CancellationToken ct = default);

        void Detach<TEntity>(TEntity entity) where TEntity : class;
    }
}