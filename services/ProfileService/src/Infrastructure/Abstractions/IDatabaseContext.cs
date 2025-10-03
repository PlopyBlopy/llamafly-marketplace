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
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.Abstractions
{
    public interface IDatabaseContext
    {
        DatabaseFacade Database { get; }
        DbSet<UserModel> Users { get; set; }
        DbSet<ProfileModel> Profiles { get; set; }
        DbSet<RoleModel> Roles { get; set; }
        DbSet<UserRoleModel> UsersRoles { get; set; }
        DbSet<AdminModel> Admins { get; set; }
        DbSet<SellerModel> Sellers { get; set; }
        DbSet<CustomerModel> Customers { get; set; }
        DbSet<ShopModel> Shops { get; set; }
        DbSet<CompanyModel> Companies { get; set; }

        Task<int> SaveChangesAsync(CancellationToken ct = default);

        void Detach<TEntity>(TEntity entity) where TEntity : class;
    }
}