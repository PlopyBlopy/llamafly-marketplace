using Domain.Models.Companies;
using Domain.Models.Seller;
using Domain.Models.Shop;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal sealed class SellerConfiguration : IEntityTypeConfiguration<SellerModel>
    {
        public void Configure(EntityTypeBuilder<SellerModel> builder)
        {
            builder.ToTable("sellers")
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.UserId)
                .HasColumnName("user_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.ShopId)
                .HasColumnName("shop_id")
                .HasColumnType("uuid")
                .IsRequired(false);

            builder.Property(p => p.CompanyId)
                .HasColumnName("company_id")
                .HasColumnType("uuid")
                .IsRequired(false);

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

            builder.HasOne<UserModel>()
                .WithOne()
                .HasForeignKey<SellerModel>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne<ShopModel>()
                .WithOne()
                .HasForeignKey<SellerModel>(p => p.ShopId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasOne<CompanyModel>()
                .WithOne()
                .HasForeignKey<SellerModel>(p => p.CompanyId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_phone_contact_text_digits", $"phone_contact ~ '^[0-9]*$'");

                t.HasCheckConstraint("CK_email_contact_format", $"email_contact ~ '^[^@]+@[^@]+\\.[^@]+$'");
            });

            builder.HasIndex(p => p.Id).IsUnique();
            builder.HasIndex(p => p.UserId).IsUnique();
            builder.HasIndex(p => p.ShopId).IsUnique();
            builder.HasIndex(p => p.CompanyId).IsUnique();
        }
    }
}