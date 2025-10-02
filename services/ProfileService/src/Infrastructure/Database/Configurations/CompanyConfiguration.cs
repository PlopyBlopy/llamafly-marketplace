using Domain.Models;
using Domain.Models.Companies;
using Domain.Models.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal sealed class CompanyConfiguration : IEntityTypeConfiguration<CompanyModel>
    {
        public void Configure(EntityTypeBuilder<CompanyModel> builder)
        {
            builder.ToTable("companies")
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(p => p.PhoneContact)
                .HasColumnName("phone_contact")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(p => p.EmailContact)
                .HasColumnName("email_contact")
                .HasColumnType("text")
                .IsRequired();

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
                t.HasCheckConstraint("CK_name_length", $"LENGTH(name) >={CompanyModelConstraints.MIN_NAME_LENGTH} AND LENGTH(name) <= {ProfileModelConstraints.MAX_NAME_LENGTH}");

                t.HasCheckConstraint("CK_phone_contact_length", $"LENGTH(phone_contact) = {CommonModelConstraints.PHONE_NUMBER_LENGHT}");

                t.HasCheckConstraint("CK_phone_contact_text_digits", $"phone_contact ~ '^[0-9]*$'");

                t.HasCheckConstraint("CK_email_contact_format", $"email_contact ~ '^[^@]+@[^@]+\\.[^@]+$'");

                t.HasCheckConstraint("CK_updatedat_more_createdat", "updated_at >= created_at");
            });

            builder.HasIndex(p => p.Id).IsUnique();
        }
    }
}