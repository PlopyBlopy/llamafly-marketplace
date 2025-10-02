using Domain.Models.Role;
using Domain.Models.User;
using Domain.Models.UserRole;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleModel>
    {
        public void Configure(EntityTypeBuilder<UserRoleModel> builder)
        {
            builder.ToTable("users_roles")
                .HasKey(p => p.UserId);

            builder.Property(p => p.UserId)
                .HasColumnName("user_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.RoleId)
                .HasColumnName("role_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.HasOne<RoleModel>()
                .WithOne()
                .HasForeignKey<UserRoleModel>(p => p.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne<UserModel>()
                .WithOne()
                .HasForeignKey<UserRoleModel>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasIndex(p => p.UserId).IsUnique();
            builder.HasIndex(p => p.RoleId).IsUnique();
        }
    }
}