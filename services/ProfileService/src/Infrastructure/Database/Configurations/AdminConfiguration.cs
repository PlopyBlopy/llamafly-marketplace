using Domain.Models.Admin;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal sealed class AdminConfiguration : IEntityTypeConfiguration<AdminModel>
    {
        public void Configure(EntityTypeBuilder<AdminModel> builder)
        {
            builder.ToTable("admins")
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.UserId)
                .HasColumnName("user_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.HasOne<UserModel>()
                .WithOne()
                .HasForeignKey<AdminModel>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasIndex(p => p.Id).IsUnique();
            builder.HasIndex(p => p.UserId).IsUnique();
        }
    }
}