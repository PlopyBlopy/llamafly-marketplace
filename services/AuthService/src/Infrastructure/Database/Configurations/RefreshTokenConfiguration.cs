using Domain.Models.Password;
using Domain.Models.RefreshToken;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshTokenModel>
    {
        public void Configure(EntityTypeBuilder<RefreshTokenModel> builder)
        {
            builder.ToTable("refresh_tokens")
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(x => x.TokenRefresh)
                .HasColumnName("token_refresh")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.IsRevoked)
                .HasColumnName("is_revoked")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(x => x.ExpiresAt)
                .HasColumnName("expires_at")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.HasOne<PasswordModel>()
                .WithOne()
                .HasForeignKey<RefreshTokenModel>(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasIndex(x => x.UserId).IsUnique(false);
        }
    }
}