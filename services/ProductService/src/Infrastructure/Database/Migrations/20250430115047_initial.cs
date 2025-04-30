using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    parent_category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                    table.CheckConstraint("CK_Category_Parent", "parent_category_id != id");
                    table.CheckConstraint("CK_Title_Length", "LENGTH(title) > 4 AND LENGTH(title) < 60");
                    table.CheckConstraint("CK_Updated_At_Length", "created_at <= updated_at");
                    table.ForeignKey(
                        name: "FK_categories_categories_parent_category_id",
                        column: x => x.parent_category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric(8,0)", nullable: false),
                    rating = table.Column<decimal>(type: "numeric(2,1)", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    seller_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.CheckConstraint("CK_Description_Length", "LENGTH(description) > 0 AND LENGTH(description) < 6000");
                    table.CheckConstraint("CK_Product_Price_Range", "price BETWEEN 50 AND 10000000");
                    table.CheckConstraint("CK_Product_Rating_Range", "rating BETWEEN 0 AND 5");
                    table.CheckConstraint("CK_Title_Length", "LENGTH(title) > 5 AND LENGTH(title) < 200");
                    table.CheckConstraint("CK_Updated_At_Length", "created_at <= updated_at");
                    table.ForeignKey(
                        name: "FK_products_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_id",
                table: "categories",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_categories_parent_category_id",
                table: "categories",
                column: "parent_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_categories_title",
                table: "categories",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_created_at",
                table: "products",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "IX_products_id",
                table: "products",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_price",
                table: "products",
                column: "price");

            migrationBuilder.CreateIndex(
                name: "IX_products_rating",
                table: "products",
                column: "rating");

            migrationBuilder.CreateIndex(
                name: "IX_products_title",
                table: "products",
                column: "title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
