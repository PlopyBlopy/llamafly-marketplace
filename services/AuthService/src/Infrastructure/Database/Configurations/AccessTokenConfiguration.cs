using Domain.Models.AccessToken;
using Domain.Models.Password;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal sealed class AccessTokenConfiguration : IEntityTypeConfiguration<AccessTokenModel>
    {
        public void Configure(EntityTypeBuilder<AccessTokenModel> builder)
        {
            builder.ToTable("access_tokens")
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(x => x.TokenAccess)
                .HasColumnName("token_access")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.IsRevorked)
                .HasColumnName("is_revorked")
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
                .HasForeignKey<AccessTokenModel>(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasIndex(x => x.UserId).IsUnique();
        }
    }
}