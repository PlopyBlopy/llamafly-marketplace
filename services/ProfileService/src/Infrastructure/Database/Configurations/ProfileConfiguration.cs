using Domain.Models.Profile;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal sealed class ProfileConfiguration : IEntityTypeConfiguration<ProfileModel>
    {
        public void Configure(EntityTypeBuilder<ProfileModel> builder)
        {
            builder.ToTable("profiles")
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.UserId)
                .HasColumnName("user_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(p => p.Surname)
                .HasColumnName("surname")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(p => p.Patronymic)
                .HasColumnName("patronymic")
                .HasColumnType("text")
                .IsRequired(false);

            builder.Property(p => p.Age)
                .HasColumnName("age")
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(p => p.Gender)
                .HasColumnName("gender")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.HasOne<UserModel>()
                .WithOne()
                .HasForeignKey<ProfileModel>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_name_length", $"LENGTH(name) >={ProfileModelConstraints.MIN_NAME_LENGTH} AND LENGTH(name) <= {ProfileModelConstraints.MAX_NAME_LENGTH}");

                t.HasCheckConstraint("CK_surname_length", $"LENGTH(surname) >={ProfileModelConstraints.MIN_SURNAME_LENGTH} AND LENGTH(surname) <= {ProfileModelConstraints.MAX_SURNAME_LENGTH}");

                t.HasCheckConstraint("CK_patronymic_length", $"LENGTH(patronymic) >={ProfileModelConstraints.MIN_PATRONYMIC_LENGTH} AND LENGTH(patronymic) <= {ProfileModelConstraints.MAX_PATRONYMIC_LENGTH}");

                t.HasCheckConstraint("CK_age_range", $"age BETWEEN {ProfileModelConstraints.MIN_AGE} AND {ProfileModelConstraints.MAX_AGE}");
            });

            builder.HasIndex(p => p.Id).IsUnique();
            builder.HasIndex(p => p.UserId).IsUnique();
        }
    }
}