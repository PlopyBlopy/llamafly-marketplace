using Domain.Models;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("users")
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.Login)
               .HasColumnName("login")
               .HasColumnType("text")
               .IsRequired();

            builder.Property(p => p.PhoneNumber)
               .HasColumnName("phone_number")
               .HasColumnType("text")
               .IsRequired(false);

            builder.Property(p => p.Email)
               .HasColumnName("email")
               .HasColumnType("text")
               .IsRequired(false);

            builder.Property(p => p.UpdatedAt)
               .HasColumnName("updated_at")
               .HasColumnType("timestamp")
               .IsRequired();

            builder.Property(p => p.CreatedAt)
               .HasColumnName("created_at")
               .HasColumnType("timestamp")
               .IsRequired();

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_login_length", $"LENGTH(login) >={UserModelConstraints.MIN_LOGIN_LENGTH} AND LENGTH(login) <= {UserModelConstraints.MAX_LOGIN_LENGTH}");

                t.HasCheckConstraint("CK_phone_number_length", $"LENGTH(phone_number) = {CommonModelConstraints.PHONE_NUMBER_LENGHT}");

                t.HasCheckConstraint("CK_phone_number_text_digits", $"phone_number ~ '^[0-9]*$'");

                t.HasCheckConstraint("CK_email_format", $"email ~ '^[^@]+@[^@]+\\.[^@]+$'");

                t.HasCheckConstraint("CK_updatedat_more_createdat", "updated_at >= created_at");
            });

            builder.HasIndex(p => p.Id).IsUnique();
            builder.HasIndex(p => p.Login);
        }
    }
}