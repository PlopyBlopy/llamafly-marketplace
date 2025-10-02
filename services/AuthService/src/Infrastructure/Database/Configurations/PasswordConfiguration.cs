using Domain.Models.Password;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal sealed class PasswordConfiguration : IEntityTypeConfiguration<PasswordModel>
    {
        public void Configure(EntityTypeBuilder<PasswordModel> builder)
        {
            builder.ToTable("passwords")
                .HasKey(x => x.UserId);

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(x => x.PasswordHash)
                .HasColumnName("password_hash")
                .HasColumnType("text")
                .IsRequired();

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_password_length", $"LENGTH(password_hash) >= {PasswordModelConstraints.MIN_LENGTH} AND LENGTH(password_hash) <= {PasswordModelConstraints.MAX_LENGTH}");
            });

            builder.HasIndex(x => x.UserId).IsUnique();
        }
    }
}