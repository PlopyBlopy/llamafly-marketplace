using Domain.Category;
using Domain.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products")
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(x => x.Title)
                .HasColumnName("title")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnName("price")
                .IsRequired()
                .HasColumnType("numeric(8, 0)");

            builder.Property(x => x.Rating)
                .HasColumnName("rating")
                .IsRequired()
                .HasColumnType("numeric(2, 1)");

            builder.Property(x => x.CategoryId)
                .HasColumnName("category_id")
                .IsRequired()
                .HasColumnType("uuid");

            builder.Property(x => x.SellerId)
                .HasColumnName("seller_id")
                .IsRequired()
                .HasColumnType("uuid");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired()
                .HasColumnType("timestamp");

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasColumnType("timestamp");

            builder.HasOne<Category>()
                .WithMany()
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("CK_Title_Length", $"LENGTH(title) > {ProductConstraints.MIN_TITLE_LENGTH} AND LENGTH(title) < {ProductConstraints.MAX_TITLE_LENGTH}");
                tb.HasCheckConstraint("CK_Description_Length", $"LENGTH(description) > {ProductConstraints.MIN_Description_LENGTH} AND LENGTH(description) < {ProductConstraints.MAX_Description_LENGTH}");
                tb.HasCheckConstraint("CK_Product_Price_Range", $"price BETWEEN {ProductConstraints.MIN_PRICE} AND {ProductConstraints.MAX_PRICE}");
                tb.HasCheckConstraint("CK_Product_Rating_Range", $"rating BETWEEN {ProductConstraints.MIN_RATING} AND {ProductConstraints.MAX_RATING}");
                tb.HasCheckConstraint("CK_Updated_At_Length", $"created_at <= updated_at");
            });

            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasIndex(x => x.Title);
            builder.HasIndex(x => x.Price);
            builder.HasIndex(x => x.Rating);
            builder.HasIndex(x => x.CategoryId);
            builder.HasIndex(x => x.CreatedAt);
        }
    }
}