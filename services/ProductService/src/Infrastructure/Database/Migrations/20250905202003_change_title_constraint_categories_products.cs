using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class change_title_constraint_categories_products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Title_Length",
                table: "products");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Title_Length",
                table: "categories");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Title_Length",
                table: "products",
                sql: "LENGTH(title) >= 5 AND LENGTH(title) <= 200");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Title_Length",
                table: "categories",
                sql: "LENGTH(title) >= 4 AND LENGTH(title) <= 60");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Title_Length",
                table: "products");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Title_Length",
                table: "categories");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Title_Length",
                table: "products",
                sql: "LENGTH(title) > 5 AND LENGTH(title) < 200");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Title_Length",
                table: "categories",
                sql: "LENGTH(title) > 4 AND LENGTH(title) < 60");
        }
    }
}
