using Domain.Models.Customer;
using Domain.Models.Shop;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal sealed class CustomerConfiguration : IEntityTypeConfiguration<CustomerModel>
    {
        public void Configure(EntityTypeBuilder<CustomerModel> builder)
        {
            builder.ToTable("customers")
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.UserId)
                .HasColumnName("user_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.Rating)
                .HasColumnName("rating")
                .HasColumnType("numeric(2, 1)")
                .IsRequired();

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.HasOne<UserModel>()
                .WithOne()
                .HasForeignKey<CustomerModel>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_rating_range", $"rating BETWEEN {ShopModelConstraints.MIN_RATING} AND {ShopModelConstraints.MAX_RATING}");
            });

            builder.HasIndex(p => p.Id).IsUnique();
            builder.HasIndex(p => p.UserId).IsUnique();
        }
    }
}