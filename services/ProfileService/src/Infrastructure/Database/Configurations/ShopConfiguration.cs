using Domain.Models.Seller;
using Domain.Models.Shop;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal sealed class ShopConfiguration : IEntityTypeConfiguration<ShopModel>
    {
        public void Configure(EntityTypeBuilder<ShopModel> builder)
        {
            builder.ToTable("shops")
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.SellerId)
                .HasColumnName("seller_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("description")
                .HasColumnType("text")
                .IsRequired(false);

            builder.Property(p => p.Rating)
                .HasColumnName("rating")
                .HasColumnType("numeric(2, 1)")
                .IsRequired();

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.HasOne<SellerModel>()
                .WithOne()
                .HasForeignKey<ShopModel>(p => p.SellerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_name_length", $"LENGTH(name) >={ShopModelConstraints.MIN_NAME_LENGTH} AND LENGTH(name) <= {ShopModelConstraints.MAX_NAME_LENGTH}");

                t.HasCheckConstraint("CK_description_length", $"LENGTH(description) >={ShopModelConstraints.MIN_DESCRIPTION_LENGTH} AND LENGTH(description) <= {ShopModelConstraints.MAX_DESCRIPTION_LENGTH}");

                t.HasCheckConstraint("CK_rating_range", $"rating BETWEEN {ShopModelConstraints.MIN_RATING} AND {ShopModelConstraints.MAX_RATING}");

                t.HasCheckConstraint("CK_updatedat_more_createdat", "updated_at >= created_at");
            });

            builder.HasIndex(p => p.Id).IsUnique();
            builder.HasIndex(p => p.SellerId).IsUnique();
        }
    }
}