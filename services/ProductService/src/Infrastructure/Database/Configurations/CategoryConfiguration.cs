using Domain.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories")
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(x => x.Title)
                .HasColumnName("title")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.ParentCategoryId)
                .HasColumnName("parent_category_id")
                .HasColumnType("uuid")
                .IsRequired(false);

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
                .HasForeignKey(x => x.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("CK_Title_Length", $"LENGTH(title) > {CategoryConstraints.MIN_TITLE_LENGTH} AND LENGTH(title) < {CategoryConstraints.MAX_TITLE_LENGTH}");
                tb.HasCheckConstraint("CK_Category_Parent", "parent_category_id != id");
                tb.HasCheckConstraint("CK_Updated_At_Length", $"created_at <= updated_at");
            });

            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasIndex(x => x.Title);
        }
    }
}